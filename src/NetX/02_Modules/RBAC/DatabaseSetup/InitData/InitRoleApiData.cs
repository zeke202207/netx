﻿using FluentMigrator;
using NetX.DatabaseSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetX.RBAC.DatabaseSetup.InitData
{
    /// <summary>
    /// 
    /// </summary>
    [Migration(1009)]
    public class InitRoleApiData : InitDataMigration
    {
        /// <summary>
        /// 
        /// </summary>
        public InitRoleApiData()
            : base(DatabaseSetupConst.C_DATABASESETUP_TABLENAME_SYSROLEAPI)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public override void Up()
        {
            Insert.IntoTable(_tableName)

            #region account

           .Row(new
           {
               roleid = "00000000000000000000000000000001",
               apiid = "10000000000000000000000000000000",
           })
           .Row(new
           {
               roleid = "00000000000000000000000000000001",
               apiid = "10000000000000000000000000000001",
           })
           .Row(new
           {
               roleid = "00000000000000000000000000000001",
               apiid = "10000000000000000000000000000002",
           })
           .Row(new
           {
               roleid = "00000000000000000000000000000001",
               apiid = "10000000000000000000000000000003",
           })
           .Row(new
           {
               roleid = "00000000000000000000000000000001",
               apiid = "10000000000000000000000000000004",
           })
           .Row(new
           {
               roleid = "00000000000000000000000000000001",
               apiid = "10000000000000000000000000000005",
           })
           .Row(new
           {
               roleid = "00000000000000000000000000000001",
               apiid = "10000000000000000000000000000006",
           })
           .Row(new
           {
               roleid = "00000000000000000000000000000001",
               apiid = "10000000000000000000000000000007",
           })
           .Row(new
           {
               roleid = "00000000000000000000000000000001",
               apiid = "10000000000000000000000000000008",
           })

            #endregion

            #region dept

           .Row(new
           {
               roleid = "00000000000000000000000000000001",
               apiid = "20000000000000000000000000000000",
           })
           .Row(new
           {
               roleid = "00000000000000000000000000000001",
               apiid = "20000000000000000000000000000001",
           })
           .Row(new
           {
               roleid = "00000000000000000000000000000001",
               apiid = "20000000000000000000000000000002",
           })
           .Row(new
           {
               roleid = "00000000000000000000000000000001",
               apiid = "20000000000000000000000000000003",
           })


            #endregion

            #region menu

           .Row(new
           {
               roleid = "00000000000000000000000000000001",
               apiid = "30000000000000000000000000000000",
           })
           .Row(new
           {
               roleid = "00000000000000000000000000000001",
               apiid = "30000000000000000000000000000001",
           })
           .Row(new
           {
               roleid = "00000000000000000000000000000001",
               apiid = "30000000000000000000000000000002",
           })
           .Row(new
           {
               roleid = "00000000000000000000000000000001",
               apiid = "30000000000000000000000000000003",
           })
           .Row(new
           {
               roleid = "00000000000000000000000000000001",
               apiid = "30000000000000000000000000000004",
           })

            #endregion

            #region role

           .Row(new
           {
               roleid = "00000000000000000000000000000001",
               apiid = "40000000000000000000000000000000",
           })
           .Row(new
           {
               roleid = "00000000000000000000000000000001",
               apiid = "40000000000000000000000000000001",
           })
           .Row(new
           {
               roleid = "00000000000000000000000000000001",
               apiid = "40000000000000000000000000000002",
           })
           .Row(new
           {
               roleid = "00000000000000000000000000000001",
               apiid = "40000000000000000000000000000003",
           })
           .Row(new
           {
               roleid = "00000000000000000000000000000001",
               apiid = "40000000000000000000000000000004",
           })
           .Row(new
           {
               roleid = "00000000000000000000000000000001",
               apiid = "40000000000000000000000000000005",
           })
            #endregion

            #region api

            .Row(new
            {
                roleid = "00000000000000000000000000000001",
                apiid = "50000000000000000000000000000000",
            })
            .Row(new
            {
                roleid = "00000000000000000000000000000001",
                apiid = "50000000000000000000000000000001",
            })
            .Row(new
            {
                roleid = "00000000000000000000000000000001",
                apiid = "50000000000000000000000000000002",
            })
            .Row(new
            {
                roleid = "00000000000000000000000000000001",
                apiid = "50000000000000000000000000000003",
            })
            .Row(new
            {
                roleid = "00000000000000000000000000000001",
                apiid = "50000000000000000000000000000004",
            })

            #endregion
           ;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Down()
        {
            Execute.Sql($"delete * from {_tableName}");
        }
    }
}
