﻿namespace System
{
    public static class Extensions
    {
        public static string Fmt(this string format, object arg0) {
            return string.Format(format, arg0);
        }

        public static string Fmt(this string format, object arg0, object arg1) {
            return string.Format(format, arg0, arg1);
        }

        public static string Fmt(this string format, object arg0, object arg1, object arg2) {
            return string.Format(format, arg0, arg1, arg2);
        }

        public static string Fmt(this string format, params object[] args) {
            return string.Format(format, args);
        }
    }
}