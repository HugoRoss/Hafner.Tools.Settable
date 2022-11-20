namespace Hafner.Tools {

    public class TypeHandlerSettableDoubleNullable : TypeHandlerSettable<double?> {

        public override Settable<double?> Parse(object value) {
            return new Settable<double?>((double?)value);
        }

    }

}
