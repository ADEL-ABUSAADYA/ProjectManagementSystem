namespace ProjectManagementSystem.Models;

public class User : BaseModel
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string PhoneNo { get; set; }
    public string Country { get; set; }
    
    public bool TwoFactorAuthEnabled { get; set; }
    public string TwoFactorAuthsecretKey { get; set; }

    public int RoleID { get; set; }
    public Role Role { get; set; }
    
    public ICollection<UserFeature> UserFeatures { get; set; }
    public ICollection<Project> Projects { get; set; }
    public ICollection<UserSprintItem> UserSprintItems { get; set; }
}