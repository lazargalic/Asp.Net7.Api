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
    public class EfGetAllEmotionQuery : EfUseCase, IGetAllEmotionQuery
    {
        public EfGetAllEmotionQuery(Asp2023DbContext context) : base(context)
        {
        }

        public int Id => 9;

        public string Name => "Vidi sve reakcije";

        public string Description => "";

        public IEnumerable<EmotionDto> Execute(EmptySearchDto search)
        {
            var query = Context.Emotions.Where(x => x.IsActive == true);
            
            var res = query.Select(x => new EmotionDto
            {
                Id=x.Id,
                NameEmotion = x.NameEmotion,
                ImagePath = x.ImagePath,
               // Price = x.Price
            }).ToList();

            return res;
        }
    }
}
