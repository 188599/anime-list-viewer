namespace Domain.Common.Models;

public abstract class Entity
{
    int? _requestedHashCode;

    public required int Id { get; init; }

    public override bool Equals(object? obj)
    {
        if (obj == null || obj is not Entity)
            return false;

        if (ReferenceEquals(this, obj))
            return true;

        if (GetType() != obj.GetType())
            return false;

        Entity item = (Entity)obj;

        return item.Id == Id;
    }

    public override int GetHashCode()
    {
        if (!_requestedHashCode.HasValue)
            _requestedHashCode = Id.GetHashCode() ^ 31; // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)

        return _requestedHashCode.Value;
    }

    public static bool operator ==(Entity left, Entity right)
    {
        if (Equals(left, null))
            return Equals(right, null);
        else
            return left.Equals(right);
    }

    public static bool operator !=(Entity left, Entity right)
    {
        return !(left == right);
    }
}