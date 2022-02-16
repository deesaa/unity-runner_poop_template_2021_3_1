using System;

[Serializable]
public struct GameItemID
{
    public string Name;
    public int Index;
    public EItemType ItemType;
    
    public bool Equals(GameItemID other)
    {
        return Name == other.Name && Index == other.Index && ItemType == other.ItemType;
    }

    public override bool Equals(object obj)
    {
        return obj is GameItemID other && Equals(other);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            var hashCode = (Name != null ? Name.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ Index;
            hashCode = (hashCode * 397) ^ (int)ItemType;
            return hashCode;
        }
    }

    public static bool operator ==(GameItemID a, GameItemID b)
    {
        return a.Equals(b);
    }

    public static bool operator !=(GameItemID a, GameItemID b)
    {
        return !(a == b);
    }

    public override string ToString()
    {
        return $"ID:{ItemType}:{Name}:{Index}";
    }
}
