namespace Hafner.Tools {

    public class TypeHandlerSettableInt32Nullable : TypeHandlerSettable<int?> {

        public override Settable<int?> Parse(object value) {
            return new Settable<int?>((int?)value);
        }

    }

}
