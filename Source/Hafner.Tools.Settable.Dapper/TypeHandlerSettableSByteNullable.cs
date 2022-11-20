using System;

namespace Hafner.Tools {

    public class TypeHandlerSettableSByteNullable : TypeHandlerSettable<sbyte?> {

        public override Settable<sbyte?> Parse(object value) {
            return new Settable<sbyte?>((sbyte?)value);
        }

    }

}
