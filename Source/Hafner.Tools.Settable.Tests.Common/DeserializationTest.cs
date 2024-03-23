using System;
using System.IO;
using System.Runtime.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hafner.Tools.Tests {

    public class DeserializationTest {

        public virtual void SerializeDeserializeUsingDataContractSerializer() {
            Guid recordId = Guid.NewGuid();
            string givenName = "Christoph";
            string? middleName = null;
            string surname = "Hafner";
            string street = "Catherine Street";
            int streetNumber = 42;
            string line2 = "Flat 2";
            string postcode = "BA11 1DB";
            string city = "Frome";
            //string district = "Somerset";
            int countryCode = 55;

            AddressUpdateDTO before = new AddressUpdateDTO();
            before.RecordId = recordId;
            before.GivenName = givenName;
            before.MiddleName = middleName;
            before.Surname = surname;
            before.Street = street;
            before.StreetNumber = streetNumber;
            before.Line2 = line2;
            before.Postcode = postcode;
            before.City = city;
            //before.District = district;
            before.CountryCode = countryCode;

            //Serialize/deserialize
            DataContractSerializer serializer = new DataContractSerializer(typeof(AddressUpdateDTO));
            using MemoryStream stream = new MemoryStream();
            serializer.WriteObject(stream, before);
            stream.Flush();
            stream.Position = 0;
            AddressUpdateDTO? after = serializer.ReadObject(stream) as AddressUpdateDTO;

            //Asserts
            Assert.IsNotNull(after);
            Assert.IsTrue(before.Equals(after));
            Assert.IsTrue(Object.Equals(after.RecordId, recordId));
            Assert.IsTrue(Object.Equals(after.GivenName.Value, givenName));
            Assert.IsTrue(Object.Equals(after.MiddleName.Value, middleName));
            Assert.IsTrue(Object.Equals(after.Surname.Value, surname));
            Assert.IsTrue(Object.Equals(after.Street.Value, street));
            Assert.IsTrue(Object.Equals(after.StreetNumber.Value, streetNumber));
            Assert.IsTrue(Object.Equals(after.Line2.Value, line2));
            Assert.IsTrue(Object.Equals(after.Postcode.Value, postcode));
            //Assert.IsTrue(Object.Equals(after.District.Value, district));
            Assert.IsTrue(Object.Equals(after.City.Value, city));
            Assert.IsFalse(after.District.IsSet);
            Assert.ThrowsException<InvalidOperationException>(() => _ = after.District.Value);
            Assert.IsTrue(Object.Equals(after.CountryCode.Value, countryCode));
        }

        [DataContract]
        private sealed class AddressUpdateDTO {

            [DataMember]
            public Guid RecordId { get; set; }

            [DataMember]
            public Settable<string> GivenName { get; set; }

            [DataMember]
            public Settable<string?> MiddleName { get; set; }

            [DataMember]
            public Settable<string> Surname { get; set; }

            [DataMember]
            public Settable<string> Street { get; set; }

            [DataMember]
            public Settable<int?> StreetNumber { get; set; }

            [DataMember]
            public Settable<string?> Line2 { get; set; }

            [DataMember]
            public Settable<string?> Postcode { get; set; }

            [DataMember]
            public Settable<string> City { get; set; }

            [DataMember]
            public Settable<string> District { get; set; }

            [DataMember]
            public Settable<int> CountryCode { get; set; }

            public override bool Equals(object? obj) {
                if (obj is null) return false;
                if (obj is not AddressUpdateDTO other) return false;
                if (!Object.Equals(RecordId, other.RecordId)) return false;
                if (!Object.Equals(GivenName, other.GivenName)) return false;
                if (!Object.Equals(MiddleName, other.MiddleName)) return false;
                if (!Object.Equals(Surname, other.Surname)) return false;
                if (!Object.Equals(Street, other.Street)) return false;
                if (!Object.Equals(StreetNumber, other.StreetNumber)) return false;
                if (!Object.Equals(Line2, other.Line2)) return false;
                if (!Object.Equals(Postcode, other.Postcode)) return false;
                if (!Object.Equals(City, other.City)) return false;
                if (!Object.Equals(District, other.District)) return false;
                if (!Object.Equals(CountryCode, other.CountryCode)) return false;
                return true;
            }

            public override int GetHashCode() {
                return 42;
            }

        }

    }

}
