using System;

namespace Hafner.Tools {

    public class TypeHandlerSettableGuidNullable : TypeHandlerSettable<Guid?> {

        public override Settable<Guid?> Parse(object value) {
            return new Settable<Guid?>((Guid?)value);
        }

    }

}
