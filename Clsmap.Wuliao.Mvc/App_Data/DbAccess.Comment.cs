// DbAccess.Comment.cs
//
// Author:
//       Lyon <qinhutu@gmail.com>
//
// Copyright (c) 2015 © Clsmap Inc.
//
//
using System;

using Dapper;

using Clsmap.Wuliao.Mvc.Models;
using Clsmap.Wuliao.Mvc.Utilities;

namespace Clsmap.Wuliao.Mvc.App_Data
{
    public partial class DbAccess
    {
        public bool PostComment(Comment comment)
        {
            var numberSql = @"
select last_no as LastNo
 from `master.numbering` as n
where n.table_name = 'comment'";

            var sql = @"
insert `blog.comment`
(uid, article_id, reader_name, reader_email, post_time, content, display)
values
(@Id, @articleId, @readerName, @readerEmail, @postTime, @content, @display);

update `master.numbering`
   set last_no = @Id
 where table_name = 'comment'";

            try
            {
                connection.Open();

                var lastNo = Converters.Parse(connection.ExecuteScalar(numberSql), Convert.ToInt32, 0);

                comment.Id = lastNo + 1;
                var transaction = connection.BeginTransaction();
                try
                {
                    var tally = connection.Execute(sql, comment, transaction);
                    if (tally > 0)
                    {
                        transaction.Commit();
                        return true;
                    }
                    else
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }             
            }
            finally
            {
                connection.Close();
            }
        }
    }
}

