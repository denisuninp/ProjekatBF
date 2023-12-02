using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Shared.Dto.DoktorDto
{
    public class DoktorDto
    {
        public int Id { get; set; }
        public string Ime { get; set; } = string.Empty;
        public string Prezime { get; set; } = string.Empty;
        public string BrojTelefona { get; set; } = string.Empty;
        public Odeljenje? Odeljenje { get; set; }
    }
}
