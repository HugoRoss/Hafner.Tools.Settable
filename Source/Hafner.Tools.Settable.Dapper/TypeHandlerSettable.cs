using System;
using System.ComponentModel;
using System.Data;
using Dapper;

namespace Hafner.Tools {

    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class TypeHandlerSettable<T> : SqlMapper.TypeHandler<Settable<T>> {

        public override void SetValue(IDbDataParameter parameter, Settable<T> value) {
            if (parameter is null) throw new ArgumentNullException(nameof(parameter));
            parameter.Value = value.Value;
        }

        public abstract override Settable<T> Parse(object value);

    }

}
