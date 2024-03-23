using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hafner.Tools.Tests {

    public class SettableTest {

        public virtual void SettableUsage() {
            //Arrange
            FilterDefinition expected;
            FilterDefinition actual;

            //All filters set
            expected = new FilterDefinition();
            expected.GivenNameFilter = "Christoph";
            expected.MiddleNameFilter = "Urs";
            expected.SurnameFilter = "Hafner";
            expected.CreationDateFromFilter = new DateTime(2022, 09, 01);
            expected.CreationDateToFilter = new DateTime(2022, 10, 01).AddTicks(-1L);
            actual = GetFilter(
                givenNameFilter: expected.GivenNameFilter,
                middleNameFilter: expected.MiddleNameFilter,
                surnameFilter: expected.SurnameFilter,
                creationDateFromFilter: expected.CreationDateFromFilter.Value,
                creationDateToFilter: expected.CreationDateToFilter.Value
            );
            AssertOkay(expected, actual);

            //Some filters set
            expected = new FilterDefinition();
            expected.GivenNameFilter = "Christoph";
            expected.SurnameFilter = "Hafner";
            expected.CreationDateToFilter = new DateTime(2022, 10, 01).AddTicks(-1L);
            actual = GetFilter(
                givenNameFilter: expected.GivenNameFilter,
                surnameFilter: expected.SurnameFilter,
                creationDateToFilter: expected.CreationDateToFilter.Value
            );
            AssertOkay(expected, actual);

            //Some filters set to null
            expected = new FilterDefinition();
            expected.GivenNameFilter = "Christoph";
            expected.MiddleNameFilter = null;
            expected.SurnameFilter = "Hafner";
            expected.CreationDateFromFilter = new DateTime(2022, 09, 01);
            actual = GetFilter(
                givenNameFilter: expected.GivenNameFilter,
                middleNameFilter: expected.MiddleNameFilter,
                surnameFilter: expected.SurnameFilter,
                creationDateFromFilter: expected.CreationDateFromFilter.Value
            );
            AssertOkay(expected, actual);

            //No filters set
            expected = new FilterDefinition();
            actual = GetFilter();
            AssertOkay(expected, actual);
        }

        private static FilterDefinition GetFilter(Settable<string?> givenNameFilter = default, Settable<string?> middleNameFilter = default, Settable<string?> surnameFilter = default, Settable<DateTime> creationDateFromFilter = default, Settable<DateTime> creationDateToFilter = default) {
            FilterDefinition result = new FilterDefinition();
            if (givenNameFilter.IsSet) {
                result.GivenNameFilter = givenNameFilter.Value;
            }
            if (middleNameFilter.IsSet) {
                result.MiddleNameFilter = middleNameFilter.Value;
            }
            if (surnameFilter.IsSet) {
                result.SurnameFilter = surnameFilter.Value;
            }
            if (creationDateFromFilter.IsSet) {
                result.CreationDateFromFilter = creationDateFromFilter.Value;
            }
            if (creationDateToFilter.IsSet) {
                result.CreationDateToFilter = creationDateToFilter.Value;
            }
            return result;
        }

        private static void AssertOkay(FilterDefinition expected, FilterDefinition actual) {
            Assert.AreEqual(expected, actual);
            if (!expected.GivenNameFilter.IsSet) {
                Assert.ThrowsException<InvalidOperationException>(() => actual.GivenNameFilter.Value);
            }
            if (!expected.MiddleNameFilter.IsSet) {
                Assert.ThrowsException<InvalidOperationException>(() => actual.MiddleNameFilter.Value);
            }
            if (!expected.SurnameFilter.IsSet) {
                Assert.ThrowsException<InvalidOperationException>(() => actual.SurnameFilter.Value);
            }
            if (!expected.CreationDateFromFilter.IsSet) {
                Assert.ThrowsException<InvalidOperationException>(() => actual.CreationDateFromFilter.Value);
            }
            if (!expected.CreationDateToFilter.IsSet) {
                Assert.ThrowsException<InvalidOperationException>(() => actual.CreationDateToFilter.Value);
            }
        }

        private class FilterDefinition {

            public Settable<string?> GivenNameFilter { get; set; }
            public Settable<string?> MiddleNameFilter { get; set; }
            public Settable<string?> SurnameFilter { get; set; }
            public Settable<DateTime> CreationDateFromFilter { get; set; }
            public Settable<DateTime> CreationDateToFilter { get; set; }

            public override bool Equals(object? obj) {
                if (obj is null) return false;
                if (obj is not FilterDefinition other) return false;
                if (!Object.Equals(GivenNameFilter, other.GivenNameFilter)) return false;
                if (!Object.Equals(MiddleNameFilter, other.MiddleNameFilter)) return false;
                if (!Object.Equals(SurnameFilter, other.SurnameFilter)) return false;
                if (!Object.Equals(CreationDateFromFilter, other.CreationDateFromFilter)) return false;
                if (!Object.Equals(CreationDateToFilter, other.CreationDateToFilter)) return false;
                return true;
            }

            public override int GetHashCode() {
                return 42;
            }

        }

    }

}
