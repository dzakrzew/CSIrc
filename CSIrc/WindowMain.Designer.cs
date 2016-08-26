namespace CSIrc
{
    partial class WindowMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WindowMain));
            this.eContent = new System.Windows.Forms.RichTextBox();
            this.eTextInput = new System.Windows.Forms.TextBox();
            this.eTopic = new System.Windows.Forms.TextBox();
            this.eButtonSend = new System.Windows.Forms.Button();
            this.eUsersList = new System.Windows.Forms.ListBox();
            this.eChannelsList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // eContent
            // 
            this.eContent.BackColor = System.Drawing.Color.White;
            this.eContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.eContent.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.eContent.HideSelection = false;
            this.eContent.Location = new System.Drawing.Point(160, 30);
            this.eContent.Name = "eContent";
            this.eContent.ReadOnly = true;
            this.eContent.Size = new System.Drawing.Size(665, 330);
            this.eContent.TabIndex = 0;
            this.eContent.Text = "";
            this.eContent.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.eContent_LinkClicked);
            this.eContent.TextChanged += new System.EventHandler(this.eContent_TextChanged);
            // 
            // eTextInput
            // 
            this.eTextInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.eTextInput.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.eTextInput.Location = new System.Drawing.Point(160, 365);
            this.eTextInput.Name = "eTextInput";
            this.eTextInput.Size = new System.Drawing.Size(665, 20);
            this.eTextInput.TabIndex = 1;
            this.eTextInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.eTextInput_KeyDown);
            this.eTextInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.eTextInput_KeyPress);
            // 
            // eTopic
            // 
            this.eTopic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.eTopic.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.eTopic.Location = new System.Drawing.Point(160, 5);
            this.eTopic.Name = "eTopic";
            this.eTopic.Size = new System.Drawing.Size(665, 20);
            this.eTopic.TabIndex = 2;
            this.eTopic.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.eTopic_KeyPress);
            // 
            // eButtonSend
            // 
            this.eButtonSend.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.eButtonSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.eButtonSend.Location = new System.Drawing.Point(830, 365);
            this.eButtonSend.Name = "eButtonSend";
            this.eButtonSend.Size = new System.Drawing.Size(150, 20);
            this.eButtonSend.TabIndex = 4;
            this.eButtonSend.Text = "Send";
            this.eButtonSend.UseVisualStyleBackColor = true;
            this.eButtonSend.Click += new System.EventHandler(this.eButtonSend_Click);
            // 
            // eUsersList
            // 
            this.eUsersList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.eUsersList.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.eUsersList.FormattingEnabled = true;
            this.eUsersList.IntegralHeight = false;
            this.eUsersList.ItemHeight = 14;
            this.eUsersList.Location = new System.Drawing.Point(830, 5);
            this.eUsersList.Name = "eUsersList";
            this.eUsersList.Size = new System.Drawing.Size(150, 355);
            this.eUsersList.TabIndex = 6;
            this.eUsersList.DoubleClick += new System.EventHandler(this.eUsersList_DoubleClick);
            // 
            // eChannelsList
            // 
            this.eChannelsList.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.eChannelsList.FormattingEnabled = true;
            this.eChannelsList.IntegralHeight = false;
            this.eChannelsList.ItemHeight = 14;
            this.eChannelsList.Location = new System.Drawing.Point(5, 5);
            this.eChannelsList.Name = "eChannelsList";
            this.eChannelsList.Size = new System.Drawing.Size(150, 380);
            this.eChannelsList.TabIndex = 7;
            this.eChannelsList.SelectedIndexChanged += new System.EventHandler(this.eChannelsList_SelectedIndexChanged);
            // 
            // WindowMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 391);
            this.Controls.Add(this.eChannelsList);
            this.Controls.Add(this.eUsersList);
            this.Controls.Add(this.eButtonSend);
            this.Controls.Add(this.eTopic);
            this.Controls.Add(this.eTextInput);
            this.Controls.Add(this.eContent);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WindowMain";
            this.Text = "CSIrc";
            this.Resize += new System.EventHandler(this.IRCWindow_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox eContent;
        private System.Windows.Forms.TextBox eTextInput;
        private System.Windows.Forms.TextBox eTopic;
        private System.Windows.Forms.Button eButtonSend;
        private System.Windows.Forms.ListBox eUsersList;
        private System.Windows.Forms.ListBox eChannelsList;

        public void UpdateChannelsList()
        {
            eChannelsList.Items.Clear();
            eChannelsList.Items.Add(((IIrcContext)ContextCollection.Server).Name);
            //eChannelsList.Items.AddRange(ContextCollection.GetContextNames().ToArray());

            foreach (string name in ContextCollection.GetContextNames())
            {
                if (ContextCollection.ActiveContexts.Contains(name))
                {
                    eChannelsList.Items.Add("* " + name);
                }
                else
                {
                    eChannelsList.Items.Add(name);
                }
            }
        }

        public void UpdateUsersList()
        {
            var ctx = ContextCollection.Current;

            eUsersList.Items.Clear();

            if (ctx == null) return;

            if (ctx.UsersList == null || ctx.UsersList.Count <= 0)
            {
                eUsersList.Enabled = false;
                return;
            }
            else
            {
                eUsersList.Enabled = true;
            }

            eUsersList.Items.AddRange(ctx.UsersList.ToArray());
        }

        public void UpdateContent()
        {
            var ctx = ContextCollection.Current;

            if (ctx == null) return;

            eContent.Rtf = @"{\rtf1\" + RTF.Encoding + " " + RTF.ColorTable + ctx.Content + @"}";

            eContent.ScrollToCaret();
        }

        public void UpdateTopic()
        {
            var ctx = ContextCollection.Current;

            eTopic.Text = "";

            if (ctx == null) return;

            if (ctx.Topic == null || ctx.Topic.Length == 0)
            {
                eTopic.Enabled = false;
                return;
            }
            else
            {
                eTopic.Enabled = true;
            }

            eTopic.Text = ctx.Topic;
        }

        public void UpdateContext()
        {
            if (ContextCollection.Current != null)
            {
                ContextCollection.ActiveContexts.Remove(ContextCollection.Current.Name);

                UpdateTopic();
                UpdateUsersList();
                UpdateContent();
                UpdateChannelsList();

                Program.MainWindow.Text = "CSIrc: " + ContextCollection.Current.Name;

                Program.MainWindow.eTextInput.Focus();
            }
        }
    }
}

