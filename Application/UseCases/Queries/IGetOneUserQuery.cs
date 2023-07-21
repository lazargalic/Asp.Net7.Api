using Application.UseCases.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Queries
{
    public interface IGetOneUserQuery : IQuery<int, OneUserDto>
    {

    }
}
