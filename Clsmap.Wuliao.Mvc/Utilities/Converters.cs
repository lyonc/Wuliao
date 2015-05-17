// Converters.cs
//
// Author:
//       Lyon <qinhutu@gmail.com>
//
// Copyright (c) 2015 © Clsmap Inc.
//
//
using System;
using System.Configuration;

namespace Clsmap.Wuliao.Mvc.Utilities
{
    public static class Converters
    {
        public static T Parse<T>(Object source, Func<Object, T> convertor, T defaultValue)
        {
            try
            {
                return convertor(source);
            }
            catch
            {
                return defaultValue;
            }
        }

        public static T GetConfigValue<T>(Func<String, T> parser, Func<T> defaultValue, String key = "", String supressKey = "")
        {
            if (!String.IsNullOrWhiteSpace(supressKey))
            {
                key = supressKey;
            }

            var value = ConfigurationManager.AppSettings[key];

            return String.IsNullOrWhiteSpace(value) ? defaultValue() : parser(value);
        }
    }
}

