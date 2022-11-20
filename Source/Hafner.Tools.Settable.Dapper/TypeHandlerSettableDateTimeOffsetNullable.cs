using System;

namespace Hafner.Tools {

    public class TypeHandlerSettableDateTimeOffsetNullable : TypeHandlerSettable<DateTimeOffset?> {

        public override Settable<DateTimeOffset?> Parse(object value) {
            return new Settable<DateTimeOffset?>((DateTimeOffset?)value);
        }

    }

}
