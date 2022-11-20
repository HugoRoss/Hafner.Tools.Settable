namespace Hafner.Tools {

    public class TypeHandlerSettableInt64Nullable : TypeHandlerSettable<long?> {

        public override Settable<long?> Parse(object value) {
            return new Settable<long?>((long?)value);
        }

    }

}
