﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetX.AuditLog
{
    /// <summary>
    /// 审计日志保存provider 
    /// </summary>
    public interface IAuditLogStoreProvider
    {
        /// <summary>
        /// 保存审计日志 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task SaveAsync(AuditLogConsumerModel model);
    }
}
