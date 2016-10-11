using System;
using MapperOrm.Attributes;
using MapperOrm.DBContext;
using MapperOrm.Models;

namespace ExampleMapperOrm
{
    [TableName("Furniture")]
    public class Furniture : EntityBase
    {
        [FieldName("Id")]
        public override int Id { get; set; }

        [FieldName("RoomId")]
        public int RoomId { get; set; }

        [FieldName("Types")]
        //[ForeignKey("userinfo_id", "userinfo")]
        public int Types { get; set; }

        [FieldName("Name")]
        //[ForeignKey("userinfo_id", "userinfo")]
        public string Name { get; set; }

        [FieldName("CreateDate")]
        public DateTime CreateDate { get; set; }



    }
}
