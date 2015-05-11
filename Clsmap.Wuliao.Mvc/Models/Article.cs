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

namespace Models
{
    public class Article
    {
        public Article()
        {
        }

        public Guid Id { get; set; }

        public String Writer { get; set; }

        public DateTime PublishTimestamp { get; set; }

        public DateTime LastEditTimestamp{ get; set; }

        public Int32 Reads { get; set; }

        public Int32 Comments { get; set; }

        public Int32 Likes { get; set; }

        public String Title { get; set; }

        public String Content { get; set; }

        public IList<String> Categories { get; set; }

        public IList<String> Tags{ get; set; }
    }
}

