using Padutronics.Diagnostics.Debugging;
using Padutronics.Extensions.System;
using System;
using System.Diagnostics;

namespace Padutronics.IO.Paths;

[DebuggerDisplay(DebuggerDisplayValues.ToStringWithQuotes)]
public sealed class DirectoryPath : IComparable<DirectoryPath>, IEquatable<DirectoryPath>
{
    private readonly string value;

    public DirectoryPath(string value)
    {
        if (value.IsEmpty())
        {
            throw new ArgumentException("Directory path cannot be empty.", nameof(value));
        }

        this.value = value;
    }

    public int CompareTo(DirectoryPath? other)
    {
        return value.CompareTo(other?.value);
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as DirectoryPath);
    }

    public bool Equals(DirectoryPath? other)
    {
        return other is not null && value == other.value;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(value);
    }

    public override string ToString()
    {
        return value.ToString();
    }

    public static bool operator ==(DirectoryPath? left, DirectoryPath? right)
    {
        return left?.Equals(right) ?? right is null;
    }

    public static bool operator !=(DirectoryPath? left, DirectoryPath? right)
    {
        return !(left == right);
    }

    public static bool operator >=(DirectoryPath? left, DirectoryPath? right)
    {
        return right <= left;
    }

    public static bool operator <=(DirectoryPath? left, DirectoryPath? right)
    {
        return left is null || left.CompareTo(right) <= 0;
    }

    public static bool operator >(DirectoryPath? left, DirectoryPath? right)
    {
        return right < left;
    }

    public static bool operator <(DirectoryPath? left, DirectoryPath? right)
    {
        return left is null ? right is not null : left.CompareTo(right) < 0;
    }

    public static implicit operator DirectoryPath(string value)
    {
        return new DirectoryPath(value);
    }
}