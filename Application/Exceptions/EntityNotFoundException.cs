using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public string EntityType { get; }
        public int Id { get; }

        public EntityNotFoundException(string entityType, int id) :
            base("Objekat sa id-jem " + id + ", tipa " + entityType + " ne postoji u bazi.")
        {
            EntityType = entityType;
            Id = id;
        }
    }
}
