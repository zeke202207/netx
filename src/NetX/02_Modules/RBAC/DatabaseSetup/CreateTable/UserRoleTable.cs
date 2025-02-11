﻿using FluentMigrator;
using NetX.DatabaseSetup;
using NetX.RBAC.Models;

namespace NetX.RBAC.DatabaseSetup.CreateTable;

/// <summary>
/// 
/// </summary>
[Migration(20091124100607)]
public class UserRoleTable : CreateTableMigration
{
    /// <summary>
    /// 
    /// </summary>
    public UserRoleTable()
        : base(DatabaseSetupConst.C_DATABASESETUP_TABLENAME_SYSUSERROLE)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public override void Up()
    {
        try
        {
            Create.Table(_tableName)
                   .WithColumn(nameof(sys_user_role.userid).ToLower()).AsString(50).PrimaryKey()
                   //.ForeignKey($"fk_{DatabaseSetupConst.C_DATABASESETUP_TABLENAME_SYSUSERROLE}_{DatabaseSetupConst.C_DATABASESETUP_TABLENAME_SYSUSER}", DatabaseSetupConst.C_DATABASESETUP_TABLENAME_SYSUSER, "id")
                   .WithColumn(nameof(sys_user_role.roleid).ToLower()).AsString(50).PrimaryKey()
                   //.ForeignKey($"fk_{DatabaseSetupConst.C_DATABASESETUP_TABLENAME_SYSUSERROLE}_{DatabaseSetupConst.C_DATABASESETUP_TABLENAME_SYSROLE}", DatabaseSetupConst.C_DATABASESETUP_TABLENAME_SYSROLE, "id")
                   ;
            Create.Index("idx_userrole")
                .OnTable(_tableName)
                .OnColumn("userid").Ascending()
                .OnColumn("roleid").Ascending();
        }
        catch (Exception ex)
        {
        }
    }
}
