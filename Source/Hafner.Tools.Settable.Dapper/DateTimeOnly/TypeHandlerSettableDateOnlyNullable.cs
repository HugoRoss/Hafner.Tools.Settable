using System;

namespace Hafner.Tools {

    public class TypeHandlerSettableDateOnlyNullable : TypeHandlerSettable<DateOnly?> {

        public override Settable<DateOnly?> Parse(object value) {
            return new Settable<DateOnly?>((DateOnly?)value);
        }

    }

}
