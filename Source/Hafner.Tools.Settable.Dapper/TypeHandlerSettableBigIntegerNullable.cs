using System.Numerics;

namespace Hafner.Tools {

    public class TypeHandlerSettableBigIntegerNullable : TypeHandlerSettable<BigInteger?> {

        public override Settable<BigInteger?> Parse(object value) {
            return new Settable<BigInteger?>((BigInteger?)value);
        }

    }

}
