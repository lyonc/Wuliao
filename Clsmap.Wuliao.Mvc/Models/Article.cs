// Article.cs
//
// Author:
//       Lyon <qinhutu@gmail.com>
//
// Copyright (c) 2015 © Clsmap Inc.
//
//
using System;
using System.Collections.Generic;

namespace Clsmap.Wuliao.Mvc.Models
{
    public class Article
    {
        public Article()
        {
        }

        public Int32 Id { get; set; }

        public String PostId { get; set; }

        public String WriterName { get; set; }

        public DateTime PublishTime { get; set; }

        public DateTime LastEditTime{ get; set; }

        public Int32 Reads { get; set; }

        public Int32 Likes { get; set; }

        public String Title { get; set; }

        public String Content { get; set; }

        public Int32 PrevPostId { get; set; } = -1;

        public Int32 NextPostId { get; set; } = -1;
    }
}

