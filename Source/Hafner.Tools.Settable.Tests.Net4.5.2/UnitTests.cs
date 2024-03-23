using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hafner.Tools.Tests {

    [TestClass]
    public class SettableTestNet452 : SettableTest {

        [TestMethod]
        public override void SettableUsage() {
            base.SettableUsage();
        }

    }

    [TestClass]
    public class DeserializationTestNet452 : DeserializationTest {

        [TestMethod]
        public override void SerializeDeserializeUsingDataContractSerializer() {
            base.SerializeDeserializeUsingDataContractSerializer();
        }

    }

}
