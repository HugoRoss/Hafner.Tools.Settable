namespace Hafner.Tools {

    public class TypeHandlerSettableInt16Nullable : TypeHandlerSettable<short?> {

        public override Settable<short?> Parse(object value) {
            return new Settable<short?>((short?)value);
        }

    }

}
