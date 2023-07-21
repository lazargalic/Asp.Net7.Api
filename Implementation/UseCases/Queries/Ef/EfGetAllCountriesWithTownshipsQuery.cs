using Application.UseCases.Dto;
using Application.UseCases.Queries;
using Application.UseCases.Queries.Searches;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.Ef
{
    public class EfGetAllCountriesWithTownshipsQuery : EfUseCase, IGetAllCountriesWithTownshipsQuery
    {
        public EfGetAllCountriesWithTownshipsQuery(Asp2023DbContext context) : base(context)
        {
        }

        public int Id => 10;

        public string Name => "Dohvati drzave sa opstinama.";

        public string Description => "";

        public IEnumerable<CountriesWithTownshipsDto> Execute(EmptySearchDto search)
        {
            var query = Context.Countries.AsQueryable();

            var result = query.Select(x => new CountriesWithTownshipsDto
            {
                Id = x.Id,
                NameCountry = x.NameCountry,
                Townships = x.Townships.Select(y => new TownshipsDto
                {
                    Id = y.Id,
                    NameTownship = y.NameTownship
                })
            }).ToList();

            return result;
        }
    }
}
