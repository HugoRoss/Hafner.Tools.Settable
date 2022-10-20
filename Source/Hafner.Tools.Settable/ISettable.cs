using System;

namespace Hafner.Tools {

    /// <summary>
    /// Technical interface to have a common base for <see cref="Settable{T}" /> of different types, e.g. to have them in a
    /// collection and filter all elements that have <see cref="Settable{T}.IsSet" /> set (or not set) or have a value of <see
    /// langword="null" /> etc. The main contact is still struct <see cref="Settable{T}" />, do not use this interface if you
    /// don't have to and do not implement it in your own types.
    /// </summary>
    public interface ISettable {

        /// <summary>Whether the value of this <see cref="Settable{T}" /> was set or not.</summary>
        bool IsSet { get; }

        /// <summary>The value that was set. An <see cref="InvalidOperationException"/> is thrown if no value was set.</summary>
        /// <exception cref="InvalidOperationException">An <see cref="InvalidOperationException"/> is thrown if no value was set.</exception>
        object? Value { get; }

        /// <summary>The underlying type of the value.</summary>
        Type UnderlyingType { get; }

    }

}
