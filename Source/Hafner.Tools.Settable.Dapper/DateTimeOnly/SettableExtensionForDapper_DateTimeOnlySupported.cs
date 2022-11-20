using Dapper;

namespace Hafner.Tools {

    public static partial class SettableExtensionForDapper {

        private static void LoadDateTimeOnlyIfAvailable() {
            SqlMapper.AddTypeHandler(new TypeHandlerSettableDateOnlyNullable());
            SqlMapper.AddTypeHandler(new TypeHandlerSettableTimeOnlyNullable());
        }

    }

}
