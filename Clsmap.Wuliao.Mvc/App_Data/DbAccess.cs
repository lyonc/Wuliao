// DbAccess.Post.cs
//
// Author:
//       Lyon <qinhutu@gmail.com>
//
// Copyright (c) 2015 © Clsmap Inc.
//
//
using System;
using System.Data;

using MySql.Data.MySqlClient;

namespace Clsmap.Wuliao.Mvc.App_Data
{
    public partial class DbAccess
    {
        private const String ConnnectionStringFormat = "Server={0};Database={1};User Id={2};Password={3};Pooling={4};";

        private IDbConnection connection;

        public DbAccess()
        {
            connection = new MySqlConnection(BuildeConnectionString());
        }

        private String BuildeConnectionString()
        {
            return String.Empty;
        }
    }
}

