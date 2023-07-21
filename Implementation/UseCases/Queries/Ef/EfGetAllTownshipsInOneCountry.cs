using Application.Exceptions;
using Application.UseCases.Dto;
using Application.UseCases.Queries;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.Ef
{
    public class EfGetAllTownshipsInOneCountry : EfUseCase, IGetAllTownshipsInOneCountry
    {
        public EfGetAllTownshipsInOneCountry(Asp2023DbContext context) : base(context)
        {
        }

        public int Id => 11;

        public string Name => "Sve opstine u jednoj drzavi";

        public string Description => "";

        public IEnumerable<TownshipsDto> Execute(int search)
        {
            var objToFind = Context.Countries.Find(search);

            if (objToFind == null)
            {
                throw new EntityNotFoundException("Countries", search);
            }

            return Context.Townships.Where(x => x.CountryId == search)
                                         .Select(y => new TownshipsDto
                                         {
                                             Id = y.Id,
                                             NameTownship = y.NameTownship
                                         }).ToList();

        }
    }
}
