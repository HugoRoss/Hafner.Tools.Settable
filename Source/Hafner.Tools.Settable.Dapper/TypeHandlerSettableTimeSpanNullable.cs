using System;

namespace Hafner.Tools {

    public class TypeHandlerSettableTimeSpanNullable : TypeHandlerSettable<TimeSpan?> {

        public override Settable<TimeSpan?> Parse(object value) {
            return new Settable<TimeSpan?>((TimeSpan?)value);
        }

    }

}
