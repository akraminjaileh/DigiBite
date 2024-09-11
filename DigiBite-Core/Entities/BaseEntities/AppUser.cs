using Microsoft.AspNetCore.Identity;
using static DigiBite_Core.Enums.DigiBiteEnums;

namespace DigiBite_Core.Models.Entities
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }

        public bool IsActive { get; set; }
        public bool IsBanned { get; set; }
        public BanType BanType { get; set; }
        public string BanReason { get; set; }

        //Relationships
        public int? ProfileImgId { get; set; }

    }
}

