using System;

namespace Hafner.Tools {

    public class TypeHandlerSettableUInt64Nullable : TypeHandlerSettable<ulong?> {

        public override Settable<ulong?> Parse(object value) {
            return new Settable<ulong?>((ulong?)value);
        }

    }

}
