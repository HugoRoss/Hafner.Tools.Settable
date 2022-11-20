using System;

namespace Hafner.Tools {

    public class TypeHandlerSettableDateTimeNullable : TypeHandlerSettable<DateTime?> {

        public override Settable<DateTime?> Parse(object value) {
            return new Settable<DateTime?>((DateTime?)value);
        }

    }

}
