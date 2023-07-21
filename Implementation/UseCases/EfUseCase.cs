using AutoMapper;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases
{
    public class EfUseCase
    {
        private Asp2023DbContext _context;
        public EfUseCase(Asp2023DbContext context)
        {
            _context = context;
        }
        protected Asp2023DbContext Context => _context;

    }
}
