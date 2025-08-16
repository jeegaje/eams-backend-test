namespace EAMS.Domain.Entities;
public abstract class BaseEntity
{
  public Int64 Id { get; set; }

  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

  public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}

public abstract class SoftDeletableEntity : BaseEntity
{
    public DateTime? DiscardedAt { get; set; }
    
    public bool IsDiscarded => DiscardedAt.HasValue;
}