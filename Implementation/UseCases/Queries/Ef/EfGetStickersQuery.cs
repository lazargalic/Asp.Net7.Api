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
    public class EfGetStickersQuery : EfUseCase, IGetStickersQuery
    {
        public EfGetStickersQuery(Asp2023DbContext context) : base(context)
        {
        }

        public int Id => 16;

        public string Name => "Dohvati Stikere";

        public string Description => "";

        public IEnumerable<GetStickersDto> Execute(EmptySearchDto search)
        {
            var query = Context.Stickers.Where(x => x.IsActive == true);

            var results = query.Select(x => new GetStickersDto
            {
                Id = x.Id,
                NameSticker = x.NameSticker,
                PathSticker = x.StickerPath
            }).ToList();

            return results;
        }
    }
}
