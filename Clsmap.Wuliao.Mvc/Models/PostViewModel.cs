// PostViewModel.cs
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
    public class PostViewModel
    {
        public Article Article { get; set; }

        public Writer Writer { get; set; }

        public IList<Topic> Topics { get; set; }

        public IList<Tag> Tags { get; set; }

        public Article PrevPost { get; set; }

        public Article NextPost { get; set; }

        public IList<Comment> Comments { get; set; }
    }
}

