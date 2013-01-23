using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Draco.DroidDotNet;

namespace BundleDotNetTest {
    [TestClass]
    public class BundleTests {
        [TestMethod]
        public void TestBundleNew() {
            Bundle b = new Bundle();
            Assert.IsNotNull(b);
        }

        [TestMethod]
        public void TestBundlePutGet() {
            Bundle b = new Bundle();
            b.putBoolean("testBool1", true);
            Assert.IsTrue((bool)b.getBoolean("testBool1"),
                "A value should be in the Bundle, but it is not.");
        }

        [TestMethod]
        public void TestBundlePutGetDefault() {
            Bundle b = new Bundle();
            b.putBoolean("testBool2", true);
            Assert.IsTrue((bool)b.getBoolean("unrealTestBool", true),
                "A default value should be returned, but it is not.");
        }

        [TestMethod]
        public void TestBundleSize() {
            Bundle b = new Bundle();
            b = putALot(b);
            Assert.AreEqual(b.size(), 9,
                "Wrong Bundle size, expected 9, got " + b.size());
        }

        [TestMethod]
        public void TestBundleRemove() {
            Bundle b = new Bundle();
            b = putALot(b);
            b.remove("stringVal");
            Assert.IsNull(b.getString("stringVal"),
                "A value should have been removed, but the Bundle still holds it.");
        }

        private Bundle putALot(Bundle b) {
            b.putBoolean("boolVal", true);
            b.putByte("byteVal", 1);
            b.putChar("charVal", 'X');
            b.putDouble("doubleVal", double.MaxValue);
            b.putFloat("floatVal", float.MaxValue);
            b.putInt("intVal", int.MaxValue);
            b.putLong("longVal", long.MaxValue);
            b.putShort("shortVal", short.MaxValue);
            b.putString("stringVal", "YAY Bundle!");
            return b;
        }
    }
}
