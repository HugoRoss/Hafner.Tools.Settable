namespace Hafner.Tools {

    public class TypeHandlerSettableCharNullable : TypeHandlerSettable<char?> {

        public override Settable<char?> Parse(object value) {
            return new Settable<char?>((char?)value);
        }

    }

}
