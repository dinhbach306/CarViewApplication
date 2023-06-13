using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Infrastructures.Utils;

public class CreatedAtTimeGenerator : ValueGenerator<DateTimeOffset>
{
    public override DateTimeOffset Next(EntityEntry entry)
    {
        if (entry == null)
        {
            throw new ArgumentNullException(nameof(entry));
        }

        return DateTimeOffset.UtcNow;
    }

    public override bool GeneratesTemporaryValues { get; }
}

public class ModifiedAtTimeGenerator : ValueGenerator<DateTimeOffset>
{
    public override DateTimeOffset Next(EntityEntry entry)
    {
        if (entry == null)
        {
            throw new ArgumentNullException(nameof(entry));
        }

        return DateTimeOffset.UtcNow;
    }

    public override bool GeneratesTemporaryValues { get; }
}