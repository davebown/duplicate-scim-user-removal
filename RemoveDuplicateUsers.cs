using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Collabco.Myday.Scim;
using Polly;

namespace Remove_duplicate_groups
{
    public partial class RemoveDuplicateUsers : Form
    {
        private readonly SynchronizationContext synchronizationContext;

        public RemoveDuplicateUsers()
        {
            InitializeComponent();
            synchronizationContext = SynchronizationContext.Current;
        }

        //Dictionary of users by externalId
        Dictionary<string, Collabco.Myday.Scim.v2.Model.ScimUser2> users = new Dictionary<string, Collabco.Myday.Scim.v2.Model.ScimUser2>();

        //List of duplicate user ids
        List<string> duplicateUserIds = new List<string>();

        private async void btn_IdentityDuplicates_Click(object sender, EventArgs e)
        {
            try
            {
                users.Clear();
                duplicateUserIds.Clear();
                var scimClient = CreateScimClient();

                await Task.Run(() => FindDuplicateScimUsers(scimClient));

                MessageBox.Show("Duplicate search completed", "Operation complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Operation failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task FindDuplicateScimUsers(ScimClient scimClient)
        {
            var errorCount = 0;
            var totalUserCount = 0;
            Collabco.Myday.Scim.v2.Model.ScimListResponse2<Collabco.Myday.Scim.v2.Model.ScimUser2> usersPage = null;
            var startIndex = 1;
            while (usersPage == null || usersPage.TotalResults > totalUserCount)
            {
                usersPage = await Policy
                 .Handle<Exception>(e => !(e is ArgumentNullException || e is ArgumentException))
                 .WaitAndRetryAsync(
                   DecorrelatedJitter(5, TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(30)),
                   (exception, timeSpan, context) =>
                   {
                       errorCount++;
                       UpdateErrorCount(errorCount);
                       Debug.WriteLine($"Scim search error: {exception.Message}");
                   }
                 )
                 .ExecuteAsync(() =>
                 {
                     return scimClient.Search<Collabco.Myday.Scim.v2.Model.ScimUser2>(
                         new Collabco.Myday.Scim.Query.ScimQueryOptions
                         {
                             Attributes = new List<string> { "id", "externalId", "meta.created", "meta.lastModified" },
                             StartIndex = startIndex,
                             //SortBy = "meta.created",
                            // SortOrder = Collabco.Myday.Scim.Core.Model.SortOrder.Ascending,
                             Count = 100
                         }
                     );
                 });

                totalUserCount += usersPage.Resources.Count();                
                startIndex += usersPage.ItemsPerPage;

                foreach(var group in usersPage.Resources.Where(g => !string.IsNullOrEmpty(g.ExternalId)))
                {
                    if(users.ContainsKey(group.ExternalId))
                    {
                        duplicateUserIds.Add(group.Id);
                    }
                    else
                    {
                        users.Add(group.ExternalId, group);
                    }
                }

                UpdateDuplicateCounts(totalUserCount);
            }
        }


        private void UpdateDuplicateCounts(int totalGroupCount)
        {
            synchronizationContext.Post(new SendOrPostCallback(o =>
            {
                lbl_TotalUsers.Text = o.ToString();
                lbl_NoDuplicates.Text = duplicateUserIds.Count.ToString();
                lbl_NoUniqueUsers.Text = users.Count.ToString();
            }), totalGroupCount);
        }

        private async void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                var scimClient = CreateScimClient();

                await Task.Run(async () =>
                {
                    var deleteCount = 0;

                    foreach (var groupId in duplicateUserIds)
                    {
                        await Policy
                         .Handle<Exception>(ex => !(ex is ArgumentNullException || ex is ArgumentException))
                         .WaitAndRetryAsync(
                           DecorrelatedJitter(5, TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(30)),
                           (exception, timeSpan, context) =>
                           {
                               Debug.WriteLine($"Scim delete error: {exception.Message}");
                           }
                         )
                         .ExecuteAsync(() =>
                         {
                             return scimClient.Delete<Collabco.Myday.Scim.v2.Model.ScimUser2>(groupId);
                         });

                        deleteCount++;
                        UpdateDeleteCount(deleteCount);
                    }
                });

                MessageBox.Show("Delete duplicates completed", "Operation complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Operation failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateErrorCount(int deleteCount)
        {
            synchronizationContext.Post(new SendOrPostCallback(o =>
            {
                lbl_NoError.Text = o.ToString();
            }), deleteCount);
        }

        private void UpdateDeleteCount(int deleteCount)
        {
            synchronizationContext.Post(new SendOrPostCallback(o =>
            {
                lbl_NoDeleted.Text = o.ToString();
            }), deleteCount);
        }

        private ScimClient CreateScimClient()
        {
            var scimConfig = new Collabco.Myday.Scim.Configuration.ScimConfiguration
            {
                BaseUrl = $"https://scim.myday.cloud/{txt_TenantId.Text}/v2",
                DefaultSearchPageSize = 100
            };

            scimConfig.AddDefaultScimResourceTypes();
            scimConfig.AddMydayScimResourceTypes();

            return new ScimClient(scimConfig, txt_Token.Text);
        }

        /// <summary>
        /// Implementation of Decorrelated Jitter strategy
        /// </summary>
        /// <param name="maxRetries">Max imum number of retries</param>
        /// <param name="seedDelay">Initial minimum delay for a retry</param>
        /// <param name="maxDelay">Maximum delay for a retry</param>
        /// <returns>TimeSpan of the delay</returns>
        private static IEnumerable<TimeSpan> DecorrelatedJitter(int maxRetries, TimeSpan seedDelay, TimeSpan maxDelay)
        {
            Random jitterer = new Random();
            int retries = 0;

            double seed = seedDelay.TotalMilliseconds;
            double max = maxDelay.TotalMilliseconds;
            double current = seed;

            while (++retries <= maxRetries)
            {
                current = Math.Min(max, Math.Max(seed, current * 3 * jitterer.NextDouble())); // adopting the 'Decorrelated Jitter' formula from https://www.awsarchitectureblog.com/2015/03/backoff.html.  Can be between seed and previous * 3.  Mustn't exceed max.
                yield return TimeSpan.FromMilliseconds(current);
            }
        }
    }
}
