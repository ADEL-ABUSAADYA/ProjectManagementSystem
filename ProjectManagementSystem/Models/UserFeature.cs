using ProjectManagementSystem.Common.Data.Enums;

namespace ProjectManagementSystem.Models
{
    public class UserFeature : BaseModel
    { 
        public int UserID { get; set; }
        public User user { get; set; }
        public Feature Feature { get; set; }
    }
}
