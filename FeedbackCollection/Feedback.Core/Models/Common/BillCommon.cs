﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feedback.Core.Models.Common
{
    public class BillCommon
    {
        public DbContext _dbContext;
        public ReturnMessage _vmReturn;
        public BillCommon()
        {
            _vmReturn = new ReturnMessage();
            _dbContext = new DbContext(AppDbConnection.ConnectionString, "System.Data.SqlClient");
        }
    }
}
