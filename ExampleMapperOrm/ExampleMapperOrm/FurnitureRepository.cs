using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MapperOrm.Repository;

namespace ExampleMapperOrm
{
    public class FurnitureRepository : Repository<Furniture>
    {
        public FurnitureRepository()
            : base("FurnitureLocationDb")
        {
        }
    }
}
