using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public interface ICommand<TRequest> : IUseCase
    {
        public void Execute(TRequest data);
        //request ce biti ono iz body-a ili query stringa kao dto parametri za neku operaciju, nemamo rezultat
    }
}
