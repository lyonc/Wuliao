// Comment.cs
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
    public class Comment
    {
        public Comment()
        {
        }

        public Int32 Id{ get; set; }

        public String ArticleId { get; set; }

        public String ReaderId{ get; set; }

        public String ReaderName { get; set; }

        public String ReaderEmail{ get; set; }

        public Int32 Floor { get; set; }

        public Int32 ReplayTo{ get; set; }

        public DateTime PostTime { get; set; }

        public String Content { get; set; }

        public Int32 Display{ get; set; }

        public Boolean IsDisplay
        {
            get { return Display == 0; }
            set { Display = (value ? 0 : 1); } 
        }
    }
}

