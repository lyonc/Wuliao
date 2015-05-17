// Writer.cs
//
// Author:
//       Lyon <qinhutu@gmail.com>
//
// Copyright (c) 2015 © Clsmap Inc.
//
//
using System;

namespace Clsmap.Wuliao.Mvc.Models
{
    public class Writer
    {
        public Writer()
        {
        }

        public Int32 Id{ get; set; }

        public String Name { get; set; }

        public String Email { get; set; }

        public String DisplayName { get; set; }
    }
}

