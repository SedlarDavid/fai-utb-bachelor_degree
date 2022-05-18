using Microsoft.EntityFrameworkCore;
using a5pwt_ctvrtek.Domain.Entities.Settings;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace a5pwt_ctvrtek.Infrastructure.Configurations.Settings
{
    public class SettingConfiguration : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.ToTable("Settings", "Web");
            builder.HasKey(e => e.ID);
        }
    }
}
