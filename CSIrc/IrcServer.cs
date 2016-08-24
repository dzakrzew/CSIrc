using System;
using System.IO;
using System.Net.Sockets;
using System.Reflection;
using System.Collections.Generic;
using System.Threading;

namespace CSIrc
{
    class IrcServer : IIrcContext
    {
        private string hostname;
        private int port;
        private string content;

        public Client Client;
        private TcpClient IRC;
        private NetworkStream Stream;
        private StreamWriter Writer;
        private StreamReader Reader;
        public Dictionary<string,string> Support = new Dictionary<string, string>();

        #region IIRCContext interface members
        string IIrcContext.Name
        {
            get { return hostname; }
            set { hostname = value; }
        }

        string IIrcContext.Content
        {
            get { return content; }
        }

        UsersListCollection IIrcContext.UsersList
        {
            get { return null; }
        }

        string IIrcContext.Topic
        {
            get { return null; }
            set { }
        }

        void IIrcContext.WriteMessage(string _nick, string _msg)
        {

        }

        #endregion

        public IrcServer(string _hostname, int _port, Client _client)
        {
            hostname = _hostname;
            port = _port;
            Client = _client;
        }

        public void Connect()
        {
            WriteLine("Connecting to " + hostname + " on port " + port.ToString() + "...");

            try
            {
                IRC = new TcpClient(hostname, port);
            }
            catch (Exception)
            {
                WriteLine("Cannot connect to " + hostname + " on port " + port.ToString() + "!");
                return;
            }


            Stream = IRC.GetStream();
            Writer = new StreamWriter(Stream);
            Reader = new StreamReader(Stream);

            SendQuery(string.Format("USER {0} {1} {2} {3} :{4}", Client.Username, Client.Username, Client.Username, Client.Username, Client.Realname));
            SendQuery(string.Format("NICK {0}", Client.Nickname));

            HandleInput();
        }

        public void Disconnect()
        {
            WriteLine("Disconnected.");
        }

        public void SendQuery(string query)
        {
            try
            {
                Writer.WriteLine(query);
                Writer.Flush();
            }
            catch (Exception)
            {
                WriteLine("Cannot send.");
            }
        }

        public void WriteLine(string msg)
        {
            content += RTF.ColourfulTimestamp() + RTF.Escape(msg) + @"\line";

            if (ContextCollection.Current == this)
            {
                Program.MainWindow.UpdateContent();
            }
        }

        private async void HandleInput()
        {
            string input;

            while (true)
            {
                input = await Reader.ReadLineAsync();

                if (input != null)
                {
                    try
                    {
                        Message message = new Message(input);

                        MethodInfo oMethodInfo = MessageProcessing.GetMethod(message.Command);

                        if (oMethodInfo != null)
                        {
                            oMethodInfo.Invoke(new MessageProcessingMethods(), new object[] { message });
                        }
                        else
                        {
                            WriteLine("Unrecognized command (" + message.Command + ")");
                        }
                    }
                    catch (Exception e)
                    {
                        WriteLine("Unhandled exception on " + input + ": " + e.Message);
                    }
                }
            }
        }
    }
}
