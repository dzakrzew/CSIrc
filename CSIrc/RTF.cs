using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CSIrc
{
    public static class RTF
    {
        public static string ColorTable = @"{\colortbl;\red255\green255\blue255;\red0\green0\blue0;\red0\green0\blue127;\red0\green147\blue0;\red255\green0\blue0;\red127\green0\blue0;\red156\green0\blue156;\red252\green127\blue0;\red255\green255\blue0;\red0\green252\blue0;\red0\green147\blue147;\red0\green255\blue255;\red0\green0\blue252;\red255\green0\blue255;\red127\green127\blue127;\red210\green210\blue210;}";
        public static string Encoding = @"ansicpg1250";

        public static string[] Colors = { @"\cf1", @"\cf2", @"\cf3", @"\cf4", @"\cf5", @"\cf6", @"\cf7", @"\cf8", @"\cf9", @"\cf10", @"\cf11", @"\cf12", @"\cf13", @"\cf14", @"\cf15", @"\cf16" };
        public static string[] BackgroundColors = { @"\highlight1", @"\highlight2", @"\highlight3", @"\highlight4", @"\highlight5", @"\highlight6", @"\highlight7", @"\highlight8", @"\highlight9", @"\highlight10", @"\highlight11", @"\highlight12", @"\highlight13", @"\highlight14", @"\highlight15", @"\highlight16" };

        public static string Escape(string _str)
        {
            string _ret = "";

            _str = _str.Replace(@"\", @"\\").Replace(@"{", @"\{").Replace(@"}", @"\}");

            int bold = 0;
            int italic = 0;
            int underline = 0;
            int color = 0;

            for (int i = 0; i < _str.Length; i++)
            {
                switch (_str[i])
                {
                    case '\u0002':
                        if (bold == 0)
                        {
                            _ret += @"\b ";
                            bold++;
                        }
                        else
                        {
                            _ret += @"\b0 ";
                            bold--;
                        }
                        break;

                    case '\u001d':
                        if (italic == 0)
                        {
                            _ret += @"\i ";
                            italic++;
                        }
                        else
                        {
                            _ret += @"\i0 ";
                            italic--;
                        }
                        break;

                    case '\u001f':
                        if (underline == 0)
                        {
                            _ret += @"\ul ";
                            underline++;
                        }
                        else
                        {
                            _ret += @"\ul0 ";
                            underline--;
                        }
                        break;

                    case '\u0003':
                        if (color == 0)
                        {
                            if (i > _str.Length - 5) break;

                            Match m = Regex.Match(_str.Substring(i+1, 5), @"^(00|1[0-5]|0?[1-9]?)(,(00|1[0-5]|0?[1-9]?))?");

                            if (m.Groups[1] == null) break;

                            _ret += "{" + Colors[int.Parse(m.Groups[1].Value)];

                            i += m.Groups[1].Value.Length;

                            if (m.Groups[3] == null || m.Groups[3].Value.Length == 0)
                            {
                                _ret += " ";
                            }
                            else
                            {
                                _ret += BackgroundColors[int.Parse(m.Groups[3].Value)] + " ";
                                i += m.Groups[3].Value.Length + 1;
                            }

                            color++;
                        }
                        else
                        {
                            _ret += "}";
                            color--;
                        }
                        break;

                    default:
                        _ret += _str[i];
                        break;
                }
            }

            if (bold > 0) _ret += @"\b0 ";
            if (italic > 0) _ret += @"\i0 ";
            if (underline > 0) _ret += @"\ul0 ";
            if (color > 0) _ret += "}";

            return _ret;
        }

        public static string ColourString(string _text, IrcColor color)
        {
            string text = _text;

            if (char.IsDigit(_text[0]))
            {
                text = " " + _text;
            }

            return "{" + RTF.Colors[(int)color] + text + "}";
        }
    }
}
