using Application.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Logging
{
    public class ConsoleExceptionLogger : IExceptionLogger
    {
        public void Log(Exception ex)
        {
            Console.WriteLine("Greska se desila u : " + DateTime.UtcNow);
            Console.WriteLine(ex.Message);
            Console.WriteLine("\n Inner Exception: " );
            Console.WriteLine(ex.InnerException);
        }
    }
}
