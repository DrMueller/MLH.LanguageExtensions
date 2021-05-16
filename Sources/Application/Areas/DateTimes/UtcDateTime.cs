using System;

namespace Mmu.Mlh.LanguageExtensions.Areas.DateTimes
{
    public class UtcDateTime
    {
        private readonly DateTime _value;

        private UtcDateTime(DateTime? dateTime)
        {
            HasValue = dateTime.HasValue;

            if (!dateTime.HasValue)
            {
                return;
            }

            switch (dateTime.Value.Kind)
            {
                case DateTimeKind.Local:
                {
                    _value = dateTime.Value.ToUniversalTime();

                    break;
                }

                case DateTimeKind.Utc:
                {
                    _value = dateTime.Value;

                    break;
                }

                case DateTimeKind.Unspecified:
                {
                    throw new InvalidOperationException($"Unspecified DateTmeKind for {dateTime.Value}");
                }
            }
        }

        public bool HasValue { get; }

        public DateTime Value
        {
            get
            {
                if (!HasValue)
                {
                    throw new InvalidOperationException("UtcDateTime has no value.");
                }

                return _value;
            }
        }

        public static UtcDateTime CreateEmpty()
        {
            return new UtcDateTime(null);
        }

        public static UtcDateTime CreateFromDateTime(DateTime? dateTime)
        {
            return new UtcDateTime(dateTime);
        }

        public static UtcDateTime CreateNow()
        {
            return new UtcDateTime(DateTime.UtcNow);
        }
    }
}