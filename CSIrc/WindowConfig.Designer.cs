namespace CSIrc
{
    partial class WindowConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WindowConfig));
            this.eAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ePort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.eNickname = new System.Windows.Forms.TextBox();
            this.eUsername = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.eRealname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.eConnect = new System.Windows.Forms.Button();
            this.eSkipMotd = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // eAddress
            // 
            this.eAddress.Location = new System.Drawing.Point(99, 12);
            this.eAddress.Name = "eAddress";
            this.eAddress.Size = new System.Drawing.Size(156, 20);
            this.eAddress.TabIndex = 0;
            this.eAddress.Text = "irc.freenode.net";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Server address:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port:";
            // 
            // ePort
            // 
            this.ePort.Location = new System.Drawing.Point(99, 39);
            this.ePort.Name = "ePort";
            this.ePort.Size = new System.Drawing.Size(57, 20);
            this.ePort.TabIndex = 3;
            this.ePort.Text = "6667";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nickname:";
            // 
            // eNickname
            // 
            this.eNickname.Location = new System.Drawing.Point(99, 65);
            this.eNickname.Name = "eNickname";
            this.eNickname.Size = new System.Drawing.Size(156, 20);
            this.eNickname.TabIndex = 5;
            this.eNickname.Text = "";
            // 
            // eUsername
            // 
            this.eUsername.Location = new System.Drawing.Point(99, 92);
            this.eUsername.Name = "eUsername";
            this.eUsername.Size = new System.Drawing.Size(156, 20);
            this.eUsername.TabIndex = 6;
            this.eUsername.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Username:";
            // 
            // eRealname
            // 
            this.eRealname.Location = new System.Drawing.Point(99, 119);
            this.eRealname.Name = "eRealname";
            this.eRealname.Size = new System.Drawing.Size(156, 20);
            this.eRealname.TabIndex = 8;
            this.eRealname.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Realname:";
            // 
            // eConnect
            // 
            this.eConnect.Location = new System.Drawing.Point(12, 188);
            this.eConnect.Name = "eConnect";
            this.eConnect.Size = new System.Drawing.Size(240, 23);
            this.eConnect.TabIndex = 10;
            this.eConnect.Text = "Connect";
            this.eConnect.UseVisualStyleBackColor = true;
            this.eConnect.Click += new System.EventHandler(this.eConnect_Click);
            // 
            // eSkipMotd
            // 
            this.eSkipMotd.AutoSize = true;
            this.eSkipMotd.Location = new System.Drawing.Point(99, 156);
            this.eSkipMotd.Name = "eSkipMotd";
            this.eSkipMotd.Size = new System.Drawing.Size(82, 17);
            this.eSkipMotd.TabIndex = 11;
            this.eSkipMotd.Text = "Skip MOTD";
            this.eSkipMotd.UseVisualStyleBackColor = true;
            // 
            // WindowConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 223);
            this.Controls.Add(this.eSkipMotd);
            this.Controls.Add(this.eConnect);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.eRealname);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.eUsername);
            this.Controls.Add(this.eNickname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ePort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.eAddress);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WindowConfig";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox eAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ePort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox eNickname;
        private System.Windows.Forms.TextBox eUsername;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox eRealname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button eConnect;
        private System.Windows.Forms.CheckBox eSkipMotd;
    }
}
