using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Hafner.Tools {

    /// <summary>
    /// Helper type that can be used to differentiate between whether a parameter/property was set to null or was not set at all.
    /// Useful for filters (null not set = do not apply any filter for that property, null set = return all records that have null
    /// in that column) or UpdateRecord methods (null not set = don't touch that value, null set = change the value to null) etc.
    /// </summary>
    /// <typeparam name="T">The underlying type of the <see cref="Settable{T}" />.</typeparam>
    [Serializable]
    public readonly struct Settable<T> : ISettable, IEquatable<Settable<T>> {

        /// <summary>
        /// Constructs a new <see cref="Settable{T}" /> with the given value. Property <see cref="IsSet" /> is <see
        /// langword="true" /> afterwards, regardless whether the value was <see langword="null" /> or not. This constructor is
        /// called by the implicit conversion operator which is the common way to assign a value.
        /// </summary>
        /// <param name="value">The value to be set.</param>
        public Settable(T? value) {
            IsSet = true;
            _value = value;
        }

        /// <summary><see langword="true" /> if a value was set (which might be null), <see langword="false" /> otherwise.</summary>
        public bool IsSet { get; }

        /// <summary>The value that was set. An <see cref="InvalidOperationException"/> is thrown if no value was set.</summary>
        /// <exception cref="InvalidOperationException">An <see cref="InvalidOperationException"/> is thrown if no value was set.</exception>
        public T? Value {
            get {
                if (IsSet) return _value;
                throw new InvalidOperationException($"No value was set, please check with property '{nameof(IsSet)}' before accessing this property!");
            }
        }

        /// <inheritdoc cref="ISettable.Value" />
        object? ISettable.Value => this.Value;

        /// <inheritdoc cref="ISettable.UnderlyingType" />
        Type ISettable.UnderlyingType => typeof(T);

        /// <summary>
        /// Implicit conversion from the underlying type to this <see cref="Settable{T}"/> which calls the <see cref="Settable(T?)">constructor</see>.
        /// </summary>
        /// <param name="value"></param>
        [SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "The constructor can be used if the language does not support implicit conversions.")]
        public static implicit operator Settable<T>(T? value) {
            return new Settable<T>(value);
        }

        /// <inheritdoc cref="Object.ToString()" />
        public override string ToString() {
            if (!IsSet) return "n/a";
            object? value = Value;
            if (value is null) return "null";
            return value.ToString() ?? "";
        }

        public override bool Equals([NotNullWhen(true)] object? obj) {
            if (obj is not Settable<T> other) return false;
            return Equals(other);
        }

        public bool Equals(Settable<T> other) {
            if (IsSet != other.IsSet) return false;
            if (!IsSet) return true;
            return Object.Equals(Value, other.Value);
        }

        public override int GetHashCode() {
            if (!IsSet) return Int32.MinValue;
            object? value = Value;
            return (value is null) ? 0 : value.GetHashCode();
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly T? _value;

        public static bool operator ==(Settable<T> left, Settable<T> right) {
            return left.Equals(right);
        }

        public static bool operator !=(Settable<T> left, Settable<T> right) {
            return !left.Equals(right);
        }

    }

}
