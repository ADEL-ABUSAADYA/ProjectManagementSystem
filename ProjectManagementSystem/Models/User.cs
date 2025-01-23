namespace ProjectManagementSystem.Models;

public class User : BaseModel
{
    public string PhoneNo { get; set; }
    public string Name { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool TwoFactorAuthEnabled { get; set; }
    public string TwoFactorAuthsecretKey { get; set; }

    public ICollection<UserFeature> UserFeatures { get; set; }
}