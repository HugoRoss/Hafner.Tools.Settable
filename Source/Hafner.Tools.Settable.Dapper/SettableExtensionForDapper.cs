using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using Dapper;
using static Dapper.SqlMapper;

namespace Hafner.Tools {

    public static partial class SettableExtensionForDapper {

        [return: NotNullIfNotNull(nameof(connection))]
        public static IDbConnection? EnsureSettableConvertersLoaded(this IDbConnection? connection) {
            LoadConverters();
            return connection;
        }

        public static void LoadConverters() {
            if (SqlMapper.HasTypeHandler(typeof(SettableExtensionForDapper))) return;
            SqlMapper.AddTypeHandler(typeof(SettableExtensionForDapper), new DummyHandler());
            SqlMapper.AddTypeHandler(new TypeHandlerSettableBigIntegerNullable());
            SqlMapper.AddTypeHandler(new TypeHandlerSettableBooleanNullable());
            SqlMapper.AddTypeHandler(new TypeHandlerSettableByteNullable());
            SqlMapper.AddTypeHandler(new TypeHandlerSettableCharNullable());
            SqlMapper.AddTypeHandler(new TypeHandlerSettableDateTimeNullable());
            SqlMapper.AddTypeHandler(new TypeHandlerSettableDateTimeOffsetNullable());
            SqlMapper.AddTypeHandler(new TypeHandlerSettableDecimalNullable());
            SqlMapper.AddTypeHandler(new TypeHandlerSettableDoubleNullable());
            SqlMapper.AddTypeHandler(new TypeHandlerSettableGuidNullable());
            SqlMapper.AddTypeHandler(new TypeHandlerSettableInt16Nullable());
            SqlMapper.AddTypeHandler(new TypeHandlerSettableInt32Nullable());
            SqlMapper.AddTypeHandler(new TypeHandlerSettableInt64Nullable());
            SqlMapper.AddTypeHandler(new TypeHandlerSettableSByteNullable());
            SqlMapper.AddTypeHandler(new TypeHandlerSettableSingleNullable());
            SqlMapper.AddTypeHandler(new TypeHandlerSettableTimeSpanNullable());
            SqlMapper.AddTypeHandler(new TypeHandlerSettableUInt16Nullable());
            SqlMapper.AddTypeHandler(new TypeHandlerSettableUInt32Nullable());
            SqlMapper.AddTypeHandler(new TypeHandlerSettableUInt64Nullable());
            LoadDateTimeOnlyIfAvailable();
        }

        private sealed class DummyHandler : ITypeHandler {

            public object Parse(Type destinationType, object value) {
                throw new NotImplementedException();
            }

            public void SetValue(IDbDataParameter parameter, object value) {
                throw new NotImplementedException();
            }

        }

    }

}
