namespace ProjectManagementSystem.Models;
public class BaseModel
{
    public int ID { get; set; }
    public bool IsActive { get; set; } = true;
    public bool Deleted { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public int? UpdatedBy { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
