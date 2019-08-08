namespace Remove_duplicate_users
{
    partial class RemoveDuplicateUsers
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_TenantId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Token = new System.Windows.Forms.TextBox();
            this.btn_IdentityDuplicates = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_NoDuplicates = new System.Windows.Forms.Label();
            this.lbl_TotalUsers = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_NoUniqueUsers = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.lbl_NoDeleted = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_NoError = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_ScimUrl = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_TenantId
            // 
            this.txt_TenantId.Location = new System.Drawing.Point(69, 45);
            this.txt_TenantId.Name = "txt_TenantId";
            this.txt_TenantId.Size = new System.Drawing.Size(453, 20);
            this.txt_TenantId.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tenant Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Token";
            // 
            // txt_Token
            // 
            this.txt_Token.Location = new System.Drawing.Point(69, 71);
            this.txt_Token.Name = "txt_Token";
            this.txt_Token.Size = new System.Drawing.Size(453, 20);
            this.txt_Token.TabIndex = 2;
            // 
            // btn_IdentityDuplicates
            // 
            this.btn_IdentityDuplicates.Location = new System.Drawing.Point(12, 144);
            this.btn_IdentityDuplicates.Name = "btn_IdentityDuplicates";
            this.btn_IdentityDuplicates.Size = new System.Drawing.Size(192, 32);
            this.btn_IdentityDuplicates.TabIndex = 4;
            this.btn_IdentityDuplicates.Text = "Identify Duplicates";
            this.btn_IdentityDuplicates.UseVisualStyleBackColor = true;
            this.btn_IdentityDuplicates.Click += new System.EventHandler(this.btn_IdentityDuplicates_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(144, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "No Duplicates:";
            // 
            // lbl_NoDuplicates
            // 
            this.lbl_NoDuplicates.AutoSize = true;
            this.lbl_NoDuplicates.Location = new System.Drawing.Point(227, 112);
            this.lbl_NoDuplicates.Name = "lbl_NoDuplicates";
            this.lbl_NoDuplicates.Size = new System.Drawing.Size(13, 13);
            this.lbl_NoDuplicates.TabIndex = 6;
            this.lbl_NoDuplicates.Text = "0";
            // 
            // lbl_TotalUsers
            // 
            this.lbl_TotalUsers.AutoSize = true;
            this.lbl_TotalUsers.Location = new System.Drawing.Point(95, 112);
            this.lbl_TotalUsers.Name = "lbl_TotalUsers";
            this.lbl_TotalUsers.Size = new System.Drawing.Size(13, 13);
            this.lbl_TotalUsers.TabIndex = 8;
            this.lbl_TotalUsers.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Total Users:";
            // 
            // lbl_NoUniqueUsers
            // 
            this.lbl_NoUniqueUsers.AutoSize = true;
            this.lbl_NoUniqueUsers.Location = new System.Drawing.Point(382, 112);
            this.lbl_NoUniqueUsers.Name = "lbl_NoUniqueUsers";
            this.lbl_NoUniqueUsers.Size = new System.Drawing.Size(13, 13);
            this.lbl_NoUniqueUsers.TabIndex = 10;
            this.lbl_NoUniqueUsers.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(278, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "No Unique Users:";
            // 
            // btn_Delete
            // 
            this.btn_Delete.Location = new System.Drawing.Point(247, 144);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(192, 32);
            this.btn_Delete.TabIndex = 11;
            this.btn_Delete.Text = "Delete Duplicates";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // lbl_NoDeleted
            // 
            this.lbl_NoDeleted.AutoSize = true;
            this.lbl_NoDeleted.Location = new System.Drawing.Point(509, 112);
            this.lbl_NoDeleted.Name = "lbl_NoDeleted";
            this.lbl_NoDeleted.Size = new System.Drawing.Size(13, 13);
            this.lbl_NoDeleted.TabIndex = 13;
            this.lbl_NoDeleted.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(439, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "No Deleted:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(445, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "No Error:";
            // 
            // lbl_NoError
            // 
            this.lbl_NoError.AutoSize = true;
            this.lbl_NoError.Location = new System.Drawing.Point(515, 154);
            this.lbl_NoError.Name = "lbl_NoError";
            this.lbl_NoError.Size = new System.Drawing.Size(13, 13);
            this.lbl_NoError.TabIndex = 15;
            this.lbl_NoError.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Scim Url";
            // 
            // txt_ScimUrl
            // 
            this.txt_ScimUrl.Location = new System.Drawing.Point(69, 19);
            this.txt_ScimUrl.Name = "txt_ScimUrl";
            this.txt_ScimUrl.Size = new System.Drawing.Size(453, 20);
            this.txt_ScimUrl.TabIndex = 16;
            this.txt_ScimUrl.Text = "https://scim.myday.cloud";
            // 
            // RemoveDuplicateUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 194);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_ScimUrl);
            this.Controls.Add(this.lbl_NoError);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_NoDeleted);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.lbl_NoUniqueUsers);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbl_TotalUsers);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbl_NoDuplicates);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_IdentityDuplicates);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_Token);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_TenantId);
            this.Name = "RemoveDuplicateUsers";
            this.Text = "Remove duplicate SCIM users by externalId";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_TenantId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Token;
        private System.Windows.Forms.Button btn_IdentityDuplicates;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_NoDuplicates;
        private System.Windows.Forms.Label lbl_TotalUsers;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_NoUniqueUsers;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Label lbl_NoDeleted;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_NoError;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_ScimUrl;
    }
}

