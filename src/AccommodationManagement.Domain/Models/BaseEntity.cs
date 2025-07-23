namespace AccommodationManagement.Domain.Models;
public abstract class BaseEntity
{
  public Guid Id { get; set; } = Guid.NewGuid();

  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

  public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}

public abstract class SoftDeletableEntity : BaseEntity
{
    public DateTime? DiscardedAt { get; set; }
    
    public bool IsDiscarded => DiscardedAt.HasValue;
}