using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Project_DATN.Data.EF.DBContext
{
    public class DB_ContextFactory : IDesignTimeDbContextFactory<DB_Context>
    {
        public DB_Context CreateDbContext(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

            var connectionString = configuration.GetConnectionString("DATN");
            var optionBuilder = new DbContextOptionsBuilder<DB_Context>();
            optionBuilder.UseSqlServer(connectionString);
            return new DB_Context(optionBuilder.Options);
        }
    }
}
