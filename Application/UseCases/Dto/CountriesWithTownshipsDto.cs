using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Dto
{
    public class CountriesWithTownshipsDto
    {
        public int Id { get; set; }
        public string NameCountry { get; set; }
        public IEnumerable<TownshipsDto> Townships { get; set; } = new List<TownshipsDto>();
    }

    public class TownshipsDto
    {
        public int Id { get; set; }
        public string NameTownship { get; set; }
    }
}
