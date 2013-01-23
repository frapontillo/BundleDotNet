using System;
using System.Collections.Generic;

namespace Draco.DroidDotNet {
    /// <summary>
    /// Builder for the <see cref="Bundle"/> class.
    /// All of the insertion methods are chainable.
    /// </summary>
    public class BundleBuilder {
        private Bundle mBundle;

        /// <summary>
        /// Initializes a new instance of the <see cref="BundleBuilder" /> class.
        /// </summary>
        public BundleBuilder() {
            mBundle = new Bundle();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="BundleBuilder" /> class,
        /// filling the inner <see cref="Bundle"/> with another given Bundle.
        /// </summary>
        /// <param name="bundle">The bundle.</param>
        public BundleBuilder(Bundle bundle) {
            mBundle = new Bundle(bundle);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BundleBuilder" /> class
        /// with a given capacity.
        /// </summary>
        /// <param name="capacity">The capacity.</param>
        public BundleBuilder(int capacity) {
            mBundle = new Bundle(capacity);
        }

        /// <summary>
        /// Returns the built bundle.
        /// </summary>
        /// <returns>The bundle built with the current BundleBuilder.</returns>
        public Bundle getBundle() {
            return mBundle;
        }

        /// <summary>
        /// Inserts all mappings from the given Bundle into this Bundle.
        /// </summary>
        /// <param name="bundle">a bundle</param>
        /// <returns>The current BundleBuilder.</returns>
        public BundleBuilder putAll(Bundle bundle) {
            mBundle.putAll(bundle);
            return this;
        }

        /// <summary>
        /// Inserts a boolean value into the mapping of the Bundle,
        /// replacing any existing value for the given key. 
        /// Either key or value may be null.
        /// </summary>
        /// <param name="key">a String, or null.</param>
        /// <param name="value">a Boolean, or null.</param>
        /// <returns>The current BundleBuilder.</returns>
        public BundleBuilder putBoolean(String key, bool? value) {
            mBundle.putBoolean(key, value);
            return this;
        }

        /// <summary>
        /// Inserts a boolean array value into the mapping of the Bundle,
        /// replacing any existing value for the given key. 
        /// Either key or value may be null.
        /// </summary>
        /// <param name="key">a String, or null.</param>
        /// <param name="value">a Boolean array, or null.</param>
        /// <returns>The current BundleBuilder.</returns>
        public BundleBuilder putBooleanArray(String key, bool[] value) {
            mBundle.putBooleanArray(key, value);
            return this;
        }

        /// <summary>
        /// Inserts a Bundle value into the mapping of the Bundle,
        /// replacing any existing value for the given key. 
        /// Either key or value may be null.
        /// </summary>
        /// <param name="key">a String, or null.</param>
        /// <param name="value">a Bundle, or null.</param>
        /// <returns>The current BundleBuilder.</returns>
        public BundleBuilder putBundle(String key, Bundle value) {
            mBundle.putBundle(key, value);
            return this;
        }

        /// <summary>
        /// Inserts a byte value into the mapping of the Bundle,
        /// replacing any existing value for the given key. 
        /// Either key or value may be null.
        /// </summary>
        /// <param name="key">a String, or null.</param>
        /// <param name="value">a byte, or null.</param>
        /// <returns>The current BundleBuilder.</returns>
        public BundleBuilder putByte(String key, byte? value) {
            mBundle.putByte(key, value);
            return this;
        }

        /// <summary>
        /// Inserts a byte array value into the mapping of the Bundle,
        /// replacing any existing value for the given key. 
        /// Either key or value may be null.
        /// </summary>
        /// <param name="key">a String, or null.</param>
        /// <param name="value">a byte array, or null.</param>
        /// <returns>The current BundleBuilder.</returns>
        public BundleBuilder putByteArray(String key, byte[] value) {
            mBundle.putByteArray(key, value);
            return this;
        }

        /// <summary>
        /// Inserts a char value into the mapping of the Bundle,
        /// replacing any existing value for the given key. 
        /// Either key or value may be null.
        /// </summary>
        /// <param name="key">a String, or null.</param>
        /// <param name="value">a char, or null.</param>
        /// <returns>The current BundleBuilder.</returns>
        public BundleBuilder putChar(String key, char? value) {
            mBundle.putChar(key, value);
            return this;
        }

        /// <summary>
        /// Inserts a char array value into the mapping of the Bundle,
        /// replacing any existing value for the given key. 
        /// Either key or value may be null.
        /// </summary>
        /// <param name="key">a String, or null.</param>
        /// <param name="value">a char array, or null.</param>
        /// <returns>The current BundleBuilder.</returns>
        public BundleBuilder putCharArray(String key, char[] value) {
            mBundle.putCharArray(key, value);
            return this;
        }

        /// <summary>
        /// Inserts a double value into the mapping of the Bundle,
        /// replacing any existing value for the given key. 
        /// Either key or value may be null.
        /// </summary>
        /// <param name="key">a String, or null.</param>
        /// <param name="value">a double, or null.</param>
        /// <returns>The current BundleBuilder.</returns>
        public BundleBuilder putDouble(String key, double? value) {
            mBundle.putDouble(key, value);
            return this;
        }

        /// <summary>
        /// Inserts a double array value into the mapping of the Bundle,
        /// replacing any existing value for the given key. 
        /// Either key or value may be null.
        /// </summary>
        /// <param name="key">a String, or null.</param>
        /// <param name="value">a double array, or null.</param>
        /// <returns>The current BundleBuilder.</returns>
        public BundleBuilder putDoubleArray(String key, double[] value) {
            mBundle.putDoubleArray(key, value);
            return this;
        }

        /// <summary>
        /// Inserts a float value into the mapping of the Bundle,
        /// replacing any existing value for the given key. 
        /// Either key or value may be null.
        /// </summary>
        /// <param name="key">a String, or null.</param>
        /// <param name="value">a float, or null.</param>
        /// <returns>The current BundleBuilder.</returns>
        public BundleBuilder putFloat(String key, float? value) {
            mBundle.putFloat(key, value);
            return this;
        }

        /// <summary>
        /// Inserts a float array value into the mapping of the Bundle,
        /// replacing any existing value for the given key. 
        /// Either key or value may be null.
        /// </summary>
        /// <param name="key">a String, or null.</param>
        /// <param name="value">a float array, or null.</param>
        /// <returns>The current BundleBuilder.</returns>
        public BundleBuilder putFloatArray(String key, float[] value) {
            mBundle.putFloatArray(key, value);
            return this;
        }

        /// <summary>
        /// Inserts an int value into the mapping of the Bundle,
        /// replacing any existing value for the given key. 
        /// Either key or value may be null.
        /// </summary>
        /// <param name="key">a String, or null.</param>
        /// <param name="value">an int, or null.</param>
        /// <returns>The current BundleBuilder.</returns>
        public BundleBuilder putInt(String key, int? value) {
            mBundle.putInt(key, value);
            return this;
        }

        /// <summary>
        /// Inserts an int array value into the mapping of the Bundle,
        /// replacing any existing value for the given key. 
        /// Either key or value may be null.
        /// </summary>
        /// <param name="key">a String, or null.</param>
        /// <param name="value">an int array, or null.</param>
        /// <returns>The current BundleBuilder.</returns>
        public BundleBuilder putIntArray(String key, int[] value) {
            mBundle.putIntArray(key, value);
            return this;
        }

        /// <summary>
        /// Inserts a List of integers into the mapping of the Bundle,
        /// replacing any existing value for the given key. 
        /// Either key or value may be null.
        /// </summary>
        /// <param name="key">a String, or null.</param>
        /// <param name="value">a List, or null.</param>
        /// <returns>The current BundleBuilder.</returns>
        public BundleBuilder putIntList(String key, List<int> value) {
            mBundle.putIntList(key, value);
            return this;
        }

        /// <summary>
        /// Inserts a long value into the mapping of the Bundle,
        /// replacing any existing value for the given key. 
        /// Either key or value may be null.
        /// </summary>
        /// <param name="key">a String, or null.</param>
        /// <param name="value">a long, or null.</param>
        /// <returns>The current BundleBuilder.</returns>
        public BundleBuilder putLong(String key, long? value) {
            mBundle.putLong(key, value);
            return this;
        }

        /// <summary>
        /// Inserts a long array value into the mapping of the Bundle,
        /// replacing any existing value for the given key. 
        /// Either key or value may be null.
        /// </summary>
        /// <param name="key">a String, or null.</param>
        /// <param name="value">a long array, or null.</param>
        /// <returns>The current BundleBuilder.</returns>
        public BundleBuilder putLongArray(String key, long[] value) {
            mBundle.putLongArray(key, value);
            return this;
        }

        /// <summary>
        /// Inserts a short value into the mapping of the Bundle,
        /// replacing any existing value for the given key. 
        /// Either key or value may be null.
        /// </summary>
        /// <param name="key">a String, or null.</param>
        /// <param name="value">a short, or null.</param>
        /// <returns>The current BundleBuilder.</returns>
        public BundleBuilder putShort(String key, short? value) {
            mBundle.putShort(key, value);
            return this;
        }

        /// <summary>
        /// Inserts a short array value into the mapping of the Bundle,
        /// replacing any existing value for the given key. 
        /// Either key or value may be null.
        /// </summary>
        /// <param name="key">a String, or null.</param>
        /// <param name="value">a short array, or null.</param>
        /// <returns>The current BundleBuilder.</returns>
        public BundleBuilder putShortArray(String key, short[] value) {
            mBundle.putShortArray(key, value);
            return this;
        }

        /// <summary>
        /// Inserts a string value into the mapping of the Bundle,
        /// replacing any existing value for the given key. 
        /// Either key or value may be null.
        /// </summary>
        /// <param name="key">a String, or null.</param>
        /// <param name="value">a string, or null.</param>
        /// <returns>The current BundleBuilder.</returns>
        public BundleBuilder putString(String key, string value) {
            mBundle.putString(key, value);
            return this;
        }

        /// <summary>
        /// Inserts a string array value into the mapping of the Bundle,
        /// replacing any existing value for the given key. 
        /// Either key or value may be null.
        /// </summary>
        /// <param name="key">a String, or null.</param>
        /// <param name="value">a string array, or null.</param>
        /// <returns>The current BundleBuilder.</returns>
        public BundleBuilder putStringArray(String key, string[] value) {
            mBundle.putStringArray(key, value);
            return this;
        }

        /// <summary>
        /// Inserts a List of strings into the mapping of the Bundle,
        /// replacing any existing value for the given key. 
        /// Either key or value may be null.
        /// </summary>
        /// <param name="key">a String, or null.</param>
        /// <param name="value">a List, or null.</param>
        /// <returns>The current BundleBuilder.</returns>
        public BundleBuilder putStringList(String key, List<string> value) {
            mBundle.putStringList(key, value);
            return this;
        }
    
    }
}