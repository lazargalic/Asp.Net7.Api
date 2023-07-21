using Application.UseCases.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Commands.AdminCommands
{
    public interface IEditEmotionCommand : ICommand<EditEmotionDto>
    {
    }
}
