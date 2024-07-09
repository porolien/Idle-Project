using System.Collections.Generic;
using System;

public class BehaviorComparer : IComparer<Behavior>
{
    public int Compare(Behavior x, Behavior y)
    {
        if (x == null || y == null)
        {
            throw new ArgumentException("Arguments cannot be null");
        }

        return x.BehaviorImportance.CompareTo(y.BehaviorImportance);
    }
}
