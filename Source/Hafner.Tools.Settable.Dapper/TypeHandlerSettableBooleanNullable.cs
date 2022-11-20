namespace Hafner.Tools {

    public class TypeHandlerSettableBooleanNullable : TypeHandlerSettable<bool?> {

        public override Settable<bool?> Parse(object value) {
            return new Settable<bool?>((bool?)value);
        }

    }

}
