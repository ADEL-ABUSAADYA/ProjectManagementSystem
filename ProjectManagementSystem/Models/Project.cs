using ProjectManagementSystem.Models.Enums;

namespace ProjectManagementSystem.Models;

public class Project : BaseModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public ProjectStatus Status { get; set; }
    
    public int UserID { get; set; }
    public User User { get; set; }
    
    public ICollection<SprintItem> SprintItems { get; set; }
}