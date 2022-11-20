namespace Hafner.Tools {

    public class TypeHandlerSettableSingleNullable : TypeHandlerSettable<float?> {

        public override Settable<float?> Parse(object value) {
            return new Settable<float?>((float?)value);
        }

    }

}
