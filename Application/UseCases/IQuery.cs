using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public interface IQuery<TRequest, TResult> : IUseCase
       //where TResult : class ovo ne sme da bude , to mi se crvenilo u use case handleru
    {
        public TResult Execute(TRequest search);
        //search ce ovde biti dto za filtriranje, a result rezulat u kom cemo da mapiramo 
    }
}
