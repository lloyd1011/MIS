namespace MIS.Backend.Migrations
{
    using Microsoft.Azure.Mobile.Server.Tables;
    using MIS.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Models.MobileServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            SetSqlGenerator("System.Data.SqlClient", new EntityTableSqlGenerator());
        }
        protected override void Seed(Models.MobileServiceContext context)
        {
            
        }

    }
}
   
