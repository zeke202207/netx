﻿using NetX.Ddd.Domain;
using NetX.TaskScheduling.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetX.TaskScheduling.Domain
{
    public class JobTaskQueryAll : DomainQuery<IEnumerable<JobTaskModel>>
    {
        public string JobName { get; set; }
        public JobTaskQueryAll(string jobName)
        {
            JobName = jobName;
        }
    }
}
