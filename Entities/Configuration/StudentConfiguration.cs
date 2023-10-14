using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<student>
    {
        public void Configure(EntityTypeBuilder<student> builder)
        {
            builder.HasData
            (
            new Student
            {
                Id = new Guid("54164014-112a-5a5a-6dd1-cb6db1891308"),
                Name = "Nardyshev Nikita",
                Age = 30,
                ayditoryaId = new Guid("b4d33fd4-b129-5dfd-2905-13d6416df55a"),
            },
            new Student
            {
                Id = new Guid("ad867425-a5ba-5629-b3b1-ad0d4655bbt8"),
                Name = "Ovtin Ruslan",
                Age = 58,
                ayditoryaId = new Guid("b4d33fd4-b129-5dfd-2905-13d6416df55a"),
            },
            new Student
            {
                Id = new Guid("ed651a8c-1751-7b63-5a58-3519ab79g44d"),
                Name = "Ivliev Nikita",
                Age = 89,
                ayditoryaId = new Guid("b4ca4fa1-b184-3cdc-3159-13b2180fa22a"),
            },
            new Student
            {
                Id = new Guid("ad737b1a-0493-1a43-7a78-6583ab97b10h"),
                Name = "Strokin Dima",
                Age = 10,
                ayditoryaId = new Guid("b4ca4fa1-b184-3cdc-3159-13b2180fa22a"),
            }
            );
        }
    }
}
