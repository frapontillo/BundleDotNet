using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Draco.DroidDotNet;

namespace BundleDotNetTest {
    [TestClass]
    public class BundleBuilderTests {
        [TestMethod]
        public void TestBundleBuilderNew() {
            BundleBuilder bd = new BundleBuilder();
            Assert.IsNotNull(bd);
        }

        [TestMethod]
        public void TestBundleBuilderPutGet() {
            BundleBuilder bd = new BundleBuilder();
            bd.putBoolean("testBool1", true);
            Assert.IsTrue((bool)bd.getBundle().getBoolean("testBool1"),
                "A value should be in the Bundle, but it is not.");
        }

        [TestMethod]
        public void TestBundleBuilderPutGetDefault() {
            BundleBuilder bd = new BundleBuilder();
            bd.putBoolean("testBool2", true);
            Assert.IsTrue((bool)bd.getBundle().getBoolean("unrealTestBool", true),
                "A default value should be returned, but it is not.");
        }

        [TestMethod]
        public void TestBundleBuilderSize() {
            BundleBuilder bd = new BundleBuilder();
            bd = putALot(bd);
            Assert.AreEqual(bd.getBundle().size(), 9,
                "Wrong Bundle size, expected 9, got " + bd.getBundle().size());
        }

        [TestMethod]
        public void TestBundleBuilderRemove() {
            BundleBuilder bd = new BundleBuilder();
            bd = putALot(bd);
            bd.getBundle().remove("stringVal");
            Assert.IsNull(bd.getBundle().getString("stringVal"),
                "A value should have been removed, but the Bundle still holds it.");
        }

        private BundleBuilder putALot(BundleBuilder bd) {
            bd.putBoolean("boolVal", true)
                .putByte("byteVal", 1)
                .putChar("charVal", 'X')
                .putDouble("doubleVal", double.MaxValue)
                .putFloat("floatVal", float.MaxValue)
                .putInt("intVal", int.MaxValue)
                .putLong("longVal", long.MaxValue)
                .putShort("shortVal", short.MaxValue)
                .putString("stringVal", "YAY Bundle!");
            return bd;
        }
    }
}
