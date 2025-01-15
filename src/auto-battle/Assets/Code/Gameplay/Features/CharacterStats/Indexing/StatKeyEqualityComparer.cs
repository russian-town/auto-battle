using System;
using System.Collections.Generic;

namespace Code.Gameplay.Features.CharacterStats.Indexing
{
    public class StatKeyEqualityComparer : EqualityComparer<StatKey>
    {
        public override bool Equals(StatKey x, StatKey y) =>
            x.TargetId == y.TargetId && x.Stat == y.Stat;

        public override int GetHashCode(StatKey obj) =>
            HashCode.Combine(obj.TargetId, (int)obj.Stat);
    }
}
