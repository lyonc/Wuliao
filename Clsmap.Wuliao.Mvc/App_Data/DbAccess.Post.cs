// DbAccess.cs
//
// Author:
//       Lyon <qinhutu@gmail.com>
//
// Copyright (c) 2015 © Clsmap Inc.
//


using System;
using System.Linq;
using System.Threading.Tasks;

using Dapper;

using Clsmap.Wuliao.Mvc.Models;

namespace Clsmap.Wuliao.Mvc.App_Data
{
    public partial class DbAccess
    {
        public PostViewModel GetArticleById(String id)
        {
            if (String.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException("id");

            var sql = @"
select a.uid as Id
      ,a.link_name as PostId
      ,IFNULL(w.penname, '已注销用户') as WriterName
      ,a.publish_time as PublishTime
      ,a.last_edit_time as LastEditTime
      ,a.title as Title
      ,a.content as Content
      ,a.prev_id as PrevId
      ,a.next_id as NextId
      ,ar.reads as `Reads`
      ,al.likes as Likes
  from `blog.article` as a
  left join `blog.article_reads` as ar on ar.article_id = a.uid
  left join `blog.article_likes` as al on al.article_id = a.uid
  left join `master.writer` as w on w.uid = a.writer_id
 where a.uid = @id;

select tc.name as Name
      ,tc.link_name as LinkName
  from `blog.article_topic` as atc
 inner join `blog.topic` as tc on tc.uid = atc.topic_id
 where atc.article_id = @id;

select tg.name as Name
      ,tg.link_name as LinkName
  from `blog.article_tag` as atg
 inner join `blog.tag` as tg on tg.uid = atg.tag_id
 where atg.article_id = @id;

select c.uid as Id
      ,c.reader_id as ReaderId
      ,c.reader_name as ReaderName
      ,c.reader_email as ReaderEmail
      ,c.post_time as PostTime
      ,c.floor as Floor
      ,c.reply_to as ReplyTo
      ,c.content as Content
      ,c.display as Display
  from `blog.comment` as c
 where c.article_id = @id
 order by c.floor asc;";

            var pagingPostSql = @"
select a.uid as Id
      ,a.link_name as PostId
      ,a.title as Title
  from `blog.article` as a
 where a.uid = @prevId;

select a.uid as Id
      ,a.link_name as PostId
      ,a.title as Title
  from `blog.article` as a
 where a.uid = @nextId;";

            var post = new PostViewModel();
            try
            {
                connection.Open();
                using (var multi = connection.QueryMultiple(sql, new {id = id}))
                {
                    post.Article = multi.Read<Article>().Single();
                    post.Writer = new Writer{ Name = post.Article.WriterName };
                    post.Topics = multi.Read<Topic>().ToList();
                    post.Tags = multi.Read<Tag>().ToList();
                    post.Comments = multi.Read<Comment>().Where(c => c.IsDisplay).ToList();
                }

                var prevId = post.Article.PrevPostId;
                var nextId = post.Article.NextPostId;
                using (var multi = connection.QueryMultiple(pagingPostSql, new {prevId = prevId, nextId = nextId}))
                {
                    var posts = multi.Read<Article>();
                    post.PrevPost = posts.FirstOrDefault(a => a.Id == prevId);
                    post.NextPost = posts.FirstOrDefault(a => a.Id == nextId);
                }

                return post;
            }
            finally
            {
                connection.Close();
            }
        }

        public PostViewModel GetPrevAndNext(PostViewModel post)
        {
            var sql = @"
select a.link_name as PostId
      ,a.title as Title
  from `blog.article`
 where a.uid = @prevId;

select a.link_name as PostId
      ,a.title as Title
  from `blog.article`
 where a.uid = @nextId;";

            try
            {
                using (var multi = connection.QueryMultiple(sql, new {prevId = post.Article.PrevPostId, nextId = post.Article.NextPostId}))
                {
                    var posts = multi.Read<Article>().ToList();
                    post.PrevPost = posts[0];
                    post.NextPost = posts[1];
                }

                return post;
            }
            finally
            {
                connection.Close();
            }
        }

        public Task<int> IncreaseReads(String id)
        {
            if (String.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException("id");

            var sql = @"
update `blog.article_reads`
   set reads = reads + 1
 where article_id = @id;";

            try
            {
                return connection.ExecuteAsync(sql, new {id = id});
            }
            finally
            {
                connection.Close();
            }
        }
    }
}  