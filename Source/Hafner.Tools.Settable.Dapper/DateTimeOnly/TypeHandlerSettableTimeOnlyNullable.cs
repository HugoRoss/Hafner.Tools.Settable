using System;

namespace Hafner.Tools {

    public class TypeHandlerSettableTimeOnlyNullable : TypeHandlerSettable<TimeOnly?> {

        public override Settable<TimeOnly?> Parse(object value) {
            return new Settable<TimeOnly?>((TimeOnly?)value);
        }

    }

}
