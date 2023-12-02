using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Shared
{
    public class Doktor
    {
        public int Id { get; set; }
        public string Ime { get; set; } = string.Empty;
        public string Prezime { get; set; } = string.Empty;
        public string BrojTelefona {  get; set; } = string.Empty;
        public Odeljenje? Odeljenje { get; set; }
        public int OdeljenjeId { get; set; }

    }
}
