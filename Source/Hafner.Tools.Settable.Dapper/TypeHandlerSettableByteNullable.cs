namespace Hafner.Tools {

    public class TypeHandlerSettableByteNullable : TypeHandlerSettable<byte?> {

        public override Settable<byte?> Parse(object value) {
            return new Settable<byte?>((byte?)value);
        }

    }

}
