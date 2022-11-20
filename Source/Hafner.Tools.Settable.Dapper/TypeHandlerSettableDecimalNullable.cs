namespace Hafner.Tools {

    public class TypeHandlerSettableDecimalNullable : TypeHandlerSettable<decimal?> {

        public override Settable<decimal?> Parse(object value) {
            return new Settable<decimal?>((decimal?)value);
        }

    }

}
