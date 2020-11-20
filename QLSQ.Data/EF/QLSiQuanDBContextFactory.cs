using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace QLSQ.Data.EF
{
    class QLSiQuanDBContextFactory : IDesignTimeDbContextFactory<QL_SiQuanDBContext>
    {
        public QL_SiQuanDBContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();


            var connectStrings = configuration.GetConnectionString("QLSiQuanConnectionStrings");
            var optionsBuilder = new DbContextOptionsBuilder<QL_SiQuanDBContext>();
            optionsBuilder.UseSqlServer(connectStrings);

            return new QL_SiQuanDBContext(optionsBuilder.Options);
            //throw new NotImplementedException();
        }
    }
}
