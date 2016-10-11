using System;
using MapperOrm.Attributes;
using MapperOrm.DBContext;
using MapperOrm.Models;

namespace ExampleMapperOrm
{


    [TableName("user_picture")]
    public class Picture : EntityBase
    {
        [FieldName("id")]
        public override int Id { get; set; }

        [FieldName("profile_id")]

        public Int32? UserProfileId { get; set; }

        [FieldName("src")]
        public String Src { get; set; }

        [FieldName("description")]
        public String Description { get; set; }

        [RelatedEntity("UserProfileId", "Id", "PhotoGallery")]
        public EntitySet<Profile> Profile { get; set; }


        //[NotMapped]
        //public HttpPostedFileBase FileUpload { get; set; }

    }
}
