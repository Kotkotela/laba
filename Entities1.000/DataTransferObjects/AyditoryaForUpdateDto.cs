using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities1._0.DataTransferObjects
{
    public class AyditoryaForUpdateDto
    {
        public string Name { get; set; }
        public IEnumerable<StudentForCreationDto> Students { get; set; }
    }
}
