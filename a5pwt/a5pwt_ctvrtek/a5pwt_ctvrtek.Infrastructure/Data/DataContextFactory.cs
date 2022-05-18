using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace a5pwt_ctvrtek.Infrastructure.Data
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DataContext>();
            builder.UseSqlServer("Server=databaze.fai.utb.cz;Database=A17147_A5PWT_Projekt;User ID=A17147;Password=Stevejobs1;persist security info=True;multipleactiveresultsets=True;");
            return new DataContext(builder.Options);
        }
    }
}
