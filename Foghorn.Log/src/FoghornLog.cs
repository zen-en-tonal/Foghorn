using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Foghorn.Log
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class FoghornLog
    {
        public readonly Guid Id;

        public readonly string Ident;

        public readonly LogLevel LogLevel;

        public readonly string Message;

        public readonly string Host;

        public readonly DateTime PublishedAt;

        public readonly LogAttributes Attributes;

        public FoghornLog(
            string ident,
            LogLevel logLevel,
            string message,
            string host,
            DateTime publishedAt,
            LogAttributes attributes)
        {
            Id = Guid.NewGuid();
            Ident = ident;
            LogLevel = logLevel;
            Message = message;
            Host = host;
            PublishedAt = publishedAt;
            Attributes = attributes;
        }

        public override bool Equals(object obj)
        {
            return obj is FoghornLog log &&
                   Id.Equals(log.Id) &&
                   Ident == log.Ident &&
                   LogLevel == log.LogLevel &&
                   Message == log.Message &&
                   Host == log.Host &&
                   PublishedAt == log.PublishedAt &&
                   EqualityComparer<LogAttributes>.Default.Equals(Attributes, log.Attributes);
        }

        public override int GetHashCode()
        {
            int hashCode = 1112645873;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Ident);
            hashCode = hashCode * -1521134295 + LogLevel.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Message);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Host);
            hashCode = hashCode * -1521134295 + PublishedAt.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<LogAttributes>.Default.GetHashCode(Attributes);
            return hashCode;
        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}
