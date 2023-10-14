using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Entities.Configuration
{
    public class AyditoryaConfiguration : IEntityTypeConfiguration<ayditorya>
    {
        public void Configure(EntityTypeBuilder<ayditorya> builder)
        {
            builder.HasData
            (
            new Ayditorya
            {
                Id = new Guid("b4d33fd4-b129-5dfd-2905-13d6416df55a"),
                Name = "403",
            },
            new Ayditorya
            {
                Id = new Guid("b4ca4fa1-b184-3cdc-3159-13b2180fa22a"),
                Name = "504",
            }
            );
        }
    }
}
