using System;
using System.Collections.Generic;

namespace Foghorn.Log
{
    public class LogAttributes : Dictionary<string, string>
    {
        public static LogAttributes Empty = new LogAttributes();

        public LogAttributes Clone()
        {
            return (LogAttributes)this.MemberwiseClone();
        }

        public override bool Equals(object obj)
        {
            return obj is LogAttributes attributes &&
                   EqualityComparer<IEqualityComparer<string>>.Default.Equals(Comparer, attributes.Comparer) &&
                   Count == attributes.Count &&
                   EqualityComparer<KeyCollection>.Default.Equals(Keys, attributes.Keys) &&
                   EqualityComparer<ValueCollection>.Default.Equals(Values, attributes.Values);
        }

        public override int GetHashCode()
        {
            int hashCode = 340188902;
            hashCode = hashCode * -1521134295 + EqualityComparer<IEqualityComparer<string>>.Default.GetHashCode(Comparer);
            hashCode = hashCode * -1521134295 + Count.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<KeyCollection>.Default.GetHashCode(Keys);
            hashCode = hashCode * -1521134295 + EqualityComparer<ValueCollection>.Default.GetHashCode(Values);
            return hashCode;
        }
    }
}
