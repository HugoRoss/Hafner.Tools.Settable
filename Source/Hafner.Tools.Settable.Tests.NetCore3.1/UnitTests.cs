using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hafner.Tools.Tests {

    [TestClass]
    public class SettableTestNetCore31 : SettableTest {

        [TestMethod]
        public override void SettableUsage() {
            base.SettableUsage();
        }

    }

    [TestClass]
    public class DeserializationTestNetCore31 : DeserializationTest {

        [TestMethod]
        public override void SerializeDeserializeUsingDataContractSerializer() {
            base.SerializeDeserializeUsingDataContractSerializer();
        }

    }

}
