using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskMgmt.Data
{
    public static class DbInitializer
    {
        public static void Initialize(TaskMgmtContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
