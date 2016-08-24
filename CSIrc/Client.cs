namespace CSIrc
{
    class Client
    {
        public Client(string _nickname, string _username, string _realname, bool _motd)
        {
            Nickname = _nickname;
            Username = _username;
            Realname = _realname;
            ShowMotd = _motd;
        }
        public string Nickname { get; set; }
        public string Username { get; set; }
        public string Realname { get; set; }
        public bool ShowMotd { get; set; }
    }
}
