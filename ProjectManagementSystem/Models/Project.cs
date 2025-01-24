using System.ComponentModel.DataAnnotations.Schema;
using ProjectManagementSystem.Models.Enums;

namespace ProjectManagementSystem.Models;

public class Project : BaseModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public ProjectStatus Status { get; set; }
    
    // Foreign keys
    [ForeignKey("Creator")]
    public int CreatorId { get; set; }

    [ForeignKey("Assignee")]
    public int AssigneeId { get; set; }

    // Navigation properties
    [InverseProperty("CreatedProjects")]
    public User Creator { get; set; }

    [InverseProperty("AssignedProjects")]
    public User Assignee { get; set; }
    
    public ICollection<SprintItem> SprintItems { get; set; }
}