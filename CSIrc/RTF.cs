using System;
using System.Collections.Generic;

namespace CSIrc
{
    public static class RTF
    {
        public static string ColorTable = @"{\colortbl;\red5\green5\blue5;\red217\green95\blue95;\red95\green95\blue217;\red95\green217\blue95;\red70\green70\blue70;}";
        public static string Encoding = @"ansicpg1250";

        public static Dictionary<string, string> Colors = new Dictionary<string, string>()
        {
            { "black", @"\cf1" },
            { "red", @"\cf2" },
            { "blue", @"\cf3" },
            { "green", @"\cf4" },
            { "gray", @"\cf5" }
        };

        public static string Escape(string _str)
        {
            return _str.Replace(@"\", @"\\").Replace(@"{", @"\{").Replace(@"}", @"\}");
        }

        public static string ColourfulTimestamp()
        {
            return DateTime.Now.ToString("[HH:mm:ss] ");
        }
    }
}
