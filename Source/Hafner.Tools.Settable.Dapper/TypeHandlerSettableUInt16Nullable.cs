using System;

namespace Hafner.Tools {

    public class TypeHandlerSettableUInt16Nullable : TypeHandlerSettable<ushort?> {

        public override Settable<ushort?> Parse(object value) {
            return new Settable<ushort?>((ushort?)value);
        }

    }

}
