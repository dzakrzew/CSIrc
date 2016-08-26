using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CSIrc
{
    public partial class WindowMain : Form
    {
        List<string> history = new List<string>();
        int history_i = -1;

        public WindowMain()
        {
            InitializeComponent();
        }

        private void eButtonSend_Click(object sender, EventArgs e)
        {
            if (eTextInput.Text.Length > 0)
            {
                string input = RTF.Escape(eTextInput.Text);

                history.Add(input);
                history_i = history.Count - 1;

                if (input.StartsWith("/"))
                {
                    try
                    {
                        Match m = Regex.Match(input, @"^\/([A-Za-z]+) ?(.*)?$");

                        MethodInfo oMethodInfo = CommandProcessing.GetMethod(m.Groups[1].Value.ToLower());

                        if (oMethodInfo != null)
                        {
                            oMethodInfo.Invoke(new CommandProcessingMethods(), new object[] { (m.Groups[2] != null) ? m.Groups[2].Value : null });
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    catch (Exception)
                    {
                        ContextCollection.Current.WriteLine("Command not found.");
                    }
                }
                else
                {
                    ContextCollection.Server.SendQuery("PRIVMSG " + ContextCollection.Current.Name + " :" + eTextInput.Text);
                    ContextCollection.Current.WriteMessage(ContextCollection.Server.Client.Nickname, input);
                }

                eTextInput.Clear();
            }
        }

        private void IRCWindow_Resize(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            Size W = control.Size;

            eUsersList.Location = new Point(W.Width - 170, 5);
            eUsersList.Size = new Size(150, W.Height - 75);
            eButtonSend.Location = new Point(W.Width - 170, W.Height - 65);
            eTopic.Size = new Size(W.Width - 335, 20);
            eContent.Size = new Size(W.Width - 335, W.Height - 100);
            eChannelsList.Size = new Size(150, W.Height - 50);
            eTextInput.Location = new Point(160, W.Height - 65);
            eTextInput.Size = new Size(W.Width - 335, 20);
        }

        private void eContent_TextChanged(object sender, EventArgs e)
        {
            eContent.SelectionStart = eContent.Text.Length;
            eContent.ScrollToCaret();
        }

        private void eTextInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                eButtonSend.PerformClick();
            }
        }

        private void eChannelsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ContextCollection.Current = ContextCollection.GetByIndex(eChannelsList.SelectedIndex);
            UpdateContext();
            ActiveControl = eTextInput;
        }

        private void eTextInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up && history_i >= 0)
            {
                eTextInput.Text = history[history_i--];
            }
        }

        private void eUsersList_DoubleClick(object sender, EventArgs e)
        {
            var userItem = eUsersList.SelectedItem;

            if (userItem == null) return;

            Match m = Regex.Match(userItem.ToString(), "^[@+]?(.*)$");

            string targetNick = m.Groups[1].Value;

            var ctx = ContextCollection.GetByName(targetNick);

            if (ctx == null)
            {
                ContextCollection.Add(new IrcQuery(targetNick));
            }
            else
            {
                ContextCollection.Current = ctx;
                UpdateContext();
            }
        }

        private void eTopic_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && ContextCollection.Current is IrcChannel)
            {
                ContextCollection.Server.SendQuery("TOPIC " + ContextCollection.Current.Name + " :" + eTopic.Text);
            }
        }

        private void eContent_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }
    }
}
