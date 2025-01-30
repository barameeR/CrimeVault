

namespace CrimeVault.Domain.Primitives;

public abstract class Entity : IEquatable<Entity>
{
    protected Entity(Guid id)
    {
        Id = id;
    }

    override public bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        var other = (Entity)obj;
        return Id == other.Id;
    }

    override public int GetHashCode()
    {
        return HashCode.Combine(Id);
    }

    public bool Equals(Entity? other)
    {
        if (other == null)
        {
            return false;
        }

        if (other.GetType() != GetType())
        {
            return false;
                };
        return Id == other.Id;
    }

    public static bool operator ==(Entity? a, Entity? b)
    {
        if (a is null && b is null)
        {
            return true;
        }
        if (a is null || b is null)
        {
            return false;
        }
        return a.Equals(b);
    }

    public static bool operator !=(Entity? a, Entity? b)
    {
        return !(a == b);
    }

    public Guid Id { get; private init; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public DeleteStatus IsDeleted { get; set; } = DeleteStatus.Active;
    public DateTime? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
    public string? UpdatedBy { get; set; }
    public string? CreatedBy { get; set; }
}
public enum DeleteStatus
{
    Active = 0,
    Deleted = 1,
    Archived = 2
}

