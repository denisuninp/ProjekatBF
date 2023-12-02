using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Shared.Dto.DoktorDto
{
    public class DoktorUpdateDto
    {
        public int Id { get; set; }
        public string Ime { get; set; } = string.Empty;
        public string Prezime { get; set; } = string.Empty;
        public string BrojTelefona { get; set; } = string.Empty;
        public int OdeljenjeId { get; set; }
    }
}
