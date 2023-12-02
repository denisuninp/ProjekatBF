using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Shared.Dto.OdeljenjeDto
{
    public class OdeljenjeDto
    {
        public int Id { get; set; }
        public string Naziv { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }
}
