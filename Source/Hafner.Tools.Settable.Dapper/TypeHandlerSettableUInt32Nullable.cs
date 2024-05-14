namespace Hafner.Tools {

    public class TypeHandlerSettableUInt32Nullable : TypeHandlerSettable<uint?> {

        public override Settable<uint?> Parse(object value) {
            return new Settable<uint?>((uint?)value);
        }

    }

}
