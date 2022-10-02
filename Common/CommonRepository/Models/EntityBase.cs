namespace CommonRepository.Models;

public abstract class EntityBase
{
    public Guid Id { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTime LastModifiedDate { get; set; }

    protected EntityBase()
    {
        Id = Guid.NewGuid();
        CreatedBy = "DefaultCreator";
        CreatedDate = DateTime.Now;
        LastModifiedBy = null;
        LastModifiedDate = DateTime.Now;
    }

    protected EntityBase(string creatorName)
    {
        Id = Guid.NewGuid();
        CreatedBy = creatorName;
        CreatedDate = DateTime.Now;
        LastModifiedBy = null;
        LastModifiedDate = DateTime.Now;
    }
}
