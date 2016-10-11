using MapperOrm.Attributes;
using MapperOrm.DBContext;
using MapperOrm.Models;

namespace ExampleMapperOrm
{
    [TableName("profile")]
    public class Profile : EntityBase
    {
        [FieldName("profile_id")]
        public override int Id { get; set; }

        [FieldName("userinfo_id")]
        public int? UserInfoId { get; set; }

        [FieldName("role_id")]
        //[ForeignKey("userinfo_id", "userinfo")]
        public int RoleId { get; set; }

        [RelatedEntity("Id", "UserProfileId", "PhotoGallery")]
        public EntitySet<Picture> Pictures { get; set; }

    }
}
