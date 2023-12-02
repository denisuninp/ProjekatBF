using Klinika.Shared.ENUMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Shared.Dto.PregledDto
{
    public class PregledUpdateDto
    {
        public int Id { get; set; }
        public int DoktorId { get; set; }
        public int PacijentId { get; set; }
        public StatusPregleda Status { get; set; }
        public string Opis { get; set; } = string.Empty;
    }
}
