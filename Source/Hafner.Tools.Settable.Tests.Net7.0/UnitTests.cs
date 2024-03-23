using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hafner.Tools.Tests {

    [TestClass]
    public class SettableTestNet70 : SettableTest {

        [TestMethod]
        public override void SettableUsage() {
            base.SettableUsage();
        }

    }

    [TestClass]
    public class DeserializationTestNet70 : DeserializationTest {

        [TestMethod]
        public override void SerializeDeserializeUsingDataContractSerializer() {
            base.SerializeDeserializeUsingDataContractSerializer();
        }

    }

}
