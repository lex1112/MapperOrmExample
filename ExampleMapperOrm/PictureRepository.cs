using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MapperOrm.Repository;

namespace ExampleMapperOrm
{
    public class PictureRepository : Repository<Picture>
    {
        public PictureRepository()
            : base("PhotoGallery")
        {
        }
    }
}
