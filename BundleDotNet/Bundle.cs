using System;
using System.Collections.Generic;
using System.Linq;

namespace Draco.DroidDotNet {
    /// <summary>
    /// Wrapper around a HashSet with convenience methods to avoid casting and defaulting.
    /// </summary>
    public class Bundle {
        private Dictionary<string, object> mDict;
        private HashSet<string> mKeySet;

        /// <summary>
        /// Constructs a new, empty <see cref="Bundle" />.
        /// </summary>
        public Bundle() {
            init();
        }

        /// <summary>
        /// Constructs a new, empty <see cref="Bundle" /> sized to hold the given number of elements.
        /// The Bundle will grow as needed.
        /// </summary>
        /// <param name="capacity">the initial capacity of the Bundle.</param>
        public Bundle(int capacity) {
            init(capacity);
        }

        /// <summary>
        /// Constructs a <see cref="Bundle" /> containing a copy of the mappings from the given Bundle.
        /// </summary>
        /// <param name="b">a Bundle to be copied.</param>
        public Bundle(Bundle b) {
            mDict = new Dictionary<string, object>(b.mDict);
            mKeySet = new HashSet<string>(mKeySet);
        }

        private void init(int? capacity = null) {
            if (capacity == null) {
                mDict = new Dictionary<string, object>();
            } else {
                mDict = new Dictionary<string, object>((int)capacity);
            }
            mKeySet = new HashSet<string>();
        }

        /// <summary>
        /// Removes all elements from the mapping of this Bundle.
        /// </summary>
        public void clear() {
            mDict.Clear();
        }

        /// <summary>
        /// Clones the current Bundle. The internal map is cloned, but the keys and values
        /// to which it refers are copied by reference.
        /// </summary>
        /// <returns>a copy of this object.</returns>
        public Object clone() {
            return new Bundle(this);
        }

        /// <summary>
        /// Returns true if the given key is contained in the mapping of this Bundle.
        /// </summary>
        /// <param name="key">a String key</param>
        /// <returns>
        ///   <c>true</c> if the key is part of the mapping, <c>false</c> otherwise.
        /// </returns>
        public bool containsKey(String key) {
            bool c = false;
            c = mDict.ContainsKey(key);
            return c;
        }

        /// <summary>
        /// Returns true if the mapping of this Bundle is empty, false otherwise.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if the mapping of this Bundle is empty, <c>false</c> otherwise.
        /// </returns>
        public bool isEmpty() {
            bool e = true;
            e = (mDict.Count > 0);
            return e;
        }

        /// <summary>
        /// Returns a <see cref="HashSet<string>"/> containing the Strings used as keys in this Bundle.
        /// </summary>
        /// <returns>a HashSet of String keys.</returns>
        public HashSet<string> keySet() {
            return mKeySet;
        }

        /// <summary>
        /// Returns the number of mappings contained in this Bundle.
        /// </summary>
        /// <returns>the number of mappings as an int.</returns>
        public int size() {
            return mDict.Count;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> containing a concise,
        /// human-readable description of this object.
        /// Subclasses are encouraged to override this method and provide an
        /// implementation that takes into account the object's type and data.
        /// The default implementation is equivalent to the following expression:
        /// <code>
        /// GetType().Name + "@" + GetHashCode().ToString("X")
        /// </code>
        /// </summary>
        /// <returns>
        /// a printable representation of this object.
        /// </returns>
        public override string ToString() {
            return GetType().Name + "@" + GetHashCode().ToString("X");
        }

        /// <summary>
        /// Returns the entry with the given key as an object.
        /// </summary>
        /// <param name="key">a String key</param>
        /// <returns>an Object, or null.</returns>
        public object get(String key) {
            object value = null;
            try {
                value = mDict[key];
            } catch {
                return null;
            }
            return value;
        }

        /// <summary>
        /// Returns the entry with the given key as a cast object.
        /// </summary>
        /// <typeparam name="T">The class to cast to.</typeparam>
        /// <param name="key">a String key</param>
        /// <returns>a <typeparamref name="T"/> object, or its default value.</returns>
        public T get<T>(String key) {
            T castValue;
            try {
                object value = mDict[key];
                castValue = (T)value;
            } catch {
                return default(T);
            }
            return castValue;
        }

        /// <summary>
        /// Returns the entry with the given key as a cast object,
        /// or a default value if the object is not found.
        /// </summary>
        /// <typeparam name="T">The class to cast to.</typeparam>
        /// <param name="key">a String key</param>
        /// <param name="defaultValue">the default value</param>
        /// <returns>a <typeparamref name="T"/> object, or its default value.</returns>
        public T get<T>(String key, T defaultValue) {
            T castValue;
            object value = null;
            try {
                if (mDict.ContainsKey(key)) {
                    value = mDict[key];
                    castValue = (T)value;
                } else return defaultValue;
            } catch {
                return default(T);
            }
            return castValue;
        }

        /// <summary>
        /// Inserts an object into the mapping of this Bundle,
        /// replacing any existing value for the given key. 
        /// Either key or value may be null.
        /// </summary>
        /// <param name="key">a String, or null</param>
        /// <param name="value">an object, or null</param>
        public void put(String key, object value) {
            try {
                mDict[key] = value;
                mKeySet.Add(key);
            } catch (Exception e) {
                throw e;
            }
        }

        /// <summary>
        /// Removes any entry with the given key from the mapping of this Bundle.
        /// </summary>
        /// <param name="key">a <see cref="String"/> key.</param>
        public void remove(String key) {
            mDict.Remove(key);
            mKeySet.Remove(key);
        }

        /// <summary>
        /// Returns the value associated with the given key,
        /// or false if no mapping of the desired type exists for the given key.
        /// </summary>
        /// <param name="key">a String</param>
        /// <returns>a boolean value</returns>
        public bool? getBoolean(String key) {
            return get<bool?>(key, false);
        }

        /// <summary>
        /// Returns the value associated with the given key,
        /// or <paramref name="defaultValue"/> if no mapping of the desired type exists for the given key.
        /// </summary>
        /// <param name="key">a String</param>
        /// <param name="defaultValue">Value to return if key does not exist</param>
        /// <returns>a boolean value</returns>
        public bool? getBoolean(String key, bool? defaultValue) {
            return get<bool?>(key, defaultValue);
        }

        /// <summary>
        /// Returns the value associated with the given key,
        /// or null if no mapping of the desired type exists for the given key
        /// or a null value is explicitly associated with the key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public bool[] getBooleanArray(String key) {
            return get<bool[]>(key, null);
        }

        /// <summary>
        /// Returns the value associated with the given key,
        /// or null if no mapping of the desired type exists for the given key
        /// or a null value is explicitly associated with the key.
        /// </summary>
        /// <param name="key">a String, or null</param>
        /// <returns>a Bundle value, or null</returns>
        public Bundle getBundle(String key) {
            return get<Bundle>(key, null);
        }

        /// <summary>
        /// Returns the value associated with the given key,
        /// or (byte) 0 if no mapping of the desired type exists for the given key.
        /// </summary>
        /// <param name="key">a String.</param>
        /// <returns>a byte value.</returns>
        public byte? getByte(String key) {
            return get<byte?>(key, 0);
        }

        /// <summary>
        /// Returns the value associated with the given key,
        /// or <paramref name="defaultValue"/> if no mapping of the desired type exists for the given key.
        /// </summary>
        /// <param name="key">a String.</param>
        /// <param name="defaultValue">Value to return if key does not exist.</param>
        /// <returns>a byte value.</returns>
        public byte? getByte(String key, byte? defaultValue) {
            return get<byte?>(key, defaultValue);
        }

        /// <summary>
        /// Returns the value associated with the given key,
        /// or null if no mapping of the desired type exists for the given key
        /// or a null value is explicitly associated with the key.
        /// </summary>
        /// <param name="key">a String, or null.</param>
        /// <returns>a byte[] value, or null.</returns>
        public byte[] getByteArray(String key) {
            return get<byte[]>(key, null);
        }

        /// <summary>
        /// Returns the value associated with the given key,
        /// or (char) 0 if no mapping of the desired type exists for the given key.
        /// </summary>
        /// <param name="key">a String.</param>
        /// <returns>a char value.</returns>
        public char? getChar(String key) {
            return get<char?>(key, char.ConvertFromUtf32(0).ToCharArray()[0]);
        }

        /// <summary>
        /// Returns the value associated with the given key,
        /// or <paramref name="defaultValue"/> if no mapping of the desired type exists for the given key.
        /// </summary>
        /// <param name="key">a String.</param>
        /// <param name="defaultValue">Value to return if key does not exist.</param>
        /// <returns>a char value.</returns>
        public char? getChar(String key, char? defaultValue) {
            return get<char?>(key, defaultValue);
        }

        /// <summary>
        /// Returns the value associated with the given key,
        /// or null if no mapping of the desired type exists for the given key
        /// or a null value is explicitly associated with the key.
        /// </summary>
        /// <param name="key">a String.</param>
        /// <returns>a char[] value, or null.</returns>
        public char[] getCharArray(String key) {
            return get<char[]>(key, null);
        }

        /// <summary>
        /// Returns the value associated with the given key,
        /// or null if no mapping of the desired type exists for the given key
        /// or a null value is explicitly associated with the key.
        /// </summary>
        /// <param name="key">a String.</param>
        /// <returns>a double value.</returns>
        public double? getDouble(String key) {
            return get<double?>(key);
        }

        /// <summary>
        /// Returns the value associated with the given key,
        /// or <paramref name="defaultValue"/> if no mapping of the desired type exists for the given key.
        /// </summary>
        /// <param name="key">a String.</param>
        /// <param name="defaultValue">Value to return if key does not exist.</param>
        /// <returns>a double value.</returns>
        public double? getDouble(String key, double? defaultValue) {
            return get<double?>(key, defaultValue);
        }

        /// <summary>
        /// Returns the value associated with the given key,
        /// or null if no mapping of the desired type exists for the given key
        /// or a null value is explicitly associated with the key.
        /// </summary>
        /// <param name="key">a String.</param>
        /// <returns>a double[] value, or null.</returns>
        public double[] getDoubleArray(String key) {
            return get<double[]>(key);
        }

        /// <summary>
        /// Returns the value associated with the given key,
        /// or null if no mapping of the desired type exists for the given key
        /// or a null value is explicitly associated with the key.
        /// </summary>
        /// <param name="key">a String.</param>
        /// <returns>a float value.</returns>
        public float? getFloat(String key) {
            return get<float?>(key);
        }

        /// <summary>
        /// Returns the value associated with the given key,
        /// or <paramref name="defaultValue"/> if no mapping of the desired type exists for the given key.
        /// </summary>
        /// <param name="key">a String.</param>
        /// <param name="defaultValue">Value to return if key does not exist.</param>
        /// <returns>a float value.</returns>
        public float? getFloat(String key, float? defaultValue) {
            return get<float?>(key, defaultValue);
        }

        /// <summary>
        /// Returns the value associated with the given key,
        /// or null if no mapping of the desired type exists for the given key
        /// or a null value is explicitly associated with the key.
        /// </summary>
        /// <param name="key">a String.</param>
        /// <returns>a float[] value, or null.</returns>
        public float[] getFloatArray(String key) {
            return get<float[]>(key);
        }

        /// <summary>
        /// Returns the value associated with the given key,
        /// or null if no mapping of the desired type exists for the given key
        /// or a null value is explicitly associated with the key.
        /// </summary>
        /// <param name="key">a String.</param>
        /// <returns>an int value.</returns>
        public int? getInt(String key) {
            return get<int?>(key);
        }

        /// <summary>
        /// Returns the value associated with the given key,
        /// or <paramref name="defaultValue"/> if no mapping of the desired type exists for the given key.
        /// </summary>
        /// <param name="key">a String.</param>
        /// <param name="defaultValue">Value to return if key does not exist.</param>
        /// <returns>an int value.</returns>
        public int? getInt(String key, int? defaultValue) {
            return get<int?>(key, defaultValue);
        }

        /// <summary>
        /// Returns the value associated with the given key,
        /// or null if no mapping of the desired type exists for the given key
        /// or a null value is explicitly associated with the key.
        /// </summary>
        /// <param name="key">a String.</param>
        /// <returns>an int[] value, or null.</returns>
        public int[] getIntArray(String key) {
            return get<int[]>(key);
        }

        /// <summary>
        /// Returns the value associated with the given key,
        /// or null if no mapping of the desired type exists for the given key
        /// or a null value is explicitly associated with the key.
        /// </summary>
        /// <param name="key">a String.</param>
        /// <returns>a List<![CDATA[<int>]]> value, or null.</returns>
        public List<int> getIntList(String key) {
            return get<List<int>>(key);
        }

        /// <summary>
        /// Returns the value associated with the given key,
        /// or null if no mapping of the desired type exists for the given key
        /// or a null value is explicitly associated with the key.
        /// </summary>
        /// <param name="key">a String.</param>
        /// <returns>a long value.</returns>
        public long? getLong(String key) {
            return get<long?>(key);
        }

        /// <summary>
        /// Returns the value associated with the given key,
        /// or <paramref name="defaultValue"/> if no mapping of the desired type exists for the given key.
        /// </summary>
        /// <param name="key">a String.</param>
        /// <param name="defaultValue">Value to return if key does not exist.</param>
        /// <returns>a long value.</returns>
        public long? getLong(String key, long? defaultValue) {
            return get<long?>(key, defaultValue);
        }

        /// <summary>
        /// Returns the value associated with the given key,
        /// or null if no mapping of the desired type exists for the given key
        /// or a null value is explicitly associated with the key.
        /// </summary>
        /// <param name="key">a String.</param>
        /// <returns>a long[] value, or null.</returns>
        public long[] getLongArray(String key) {
            return get<long[]>(key);
        }

        /// <summary>
        /// Returns the value associated with the given key,
        /// or null if no mapping of the desired type exists for the given key
        /// or a null value is explicitly associated with the key.
        /// </summary>
        /// <param name="key">a String.</param>
        /// <returns>a short value.</returns>
        public short? getShort(String key) {
            return get<short?>(key);
        }

        /// <summary>
        /// Returns the value associated with the given key,
        /// or <paramref name="defaultValue"/> if no mapping of the desired type exists for the given key.
        /// </summary>
        /// <param name="key">a String.</param>
        /// <param name="defaultValue">Value to return if key does not exist.</param>
        /// <returns>a short value.</returns>
        public short? getShort(String key, short? defaultValue) {
            return get<short?>(key, defaultValue);
        }

        /// <summary>
        /// Returns the value associated with the given key,
        /// or null if no mapping of the desired type exists for the given key
        /// or a null value is explicitly associated with the key.
        /// </summary>
        /// <param name="key">a String.</param>
        /// <returns>a short[] value, or null.</returns>
        public short[] getShortArray(String key) {
            return get<short[]>(key);
        }

        /// <summary>
        /// Returns the value associated with the given key,
        /// or null if no mapping of the desired type exists for the given key
        /// or a null value is explicitly associated with the key.
        /// </summary>
        /// <param name="key">a String.</param>
        /// <returns>a string value.</returns>
        public string getString(String key) {
            return get<string>(key);
        }

        /// <summary>
        /// Returns the value associated with the given key,
        /// or <paramref name="defaultValue"/> if no mapping of the desired type exists for the given key.
        /// </summary>
        /// <param name="key">a String.</param>
        /// <param name="defaultValue">Value to return if key does not exist.</param>
        /// <returns>a string value.</returns>
        public string getString(String key, string defaultValue) {
            return get<string>(key, defaultValue);
        }

        /// <summary>
        /// Returns the value associated with the given key,
        /// or null if no mapping of the desired type exists for the given key
        /// or a null value is explicitly associated with the key.
        /// </summary>
        /// <param name="key">a String.</param>
        /// <returns>a string[] value, or null.</returns>
        public string[] getStringArray(String key) {
            return get<string[]>(key);
        }

        /// <summary>
        /// Returns the value associated with the given key,
        /// or null if no mapping of the desired type exists for the given key
        /// or a null value is explicitly associated with the key.
        /// </summary>
        /// <param name="key">a String.</param>
        /// <returns>a List<![CDATA[<string>]]> value, or null.</returns>
        public List<string> getStringList(String key) {
            return get<List<string>>(key);
        }

        /// <summary>
        /// Inserts all mappings from the given Bundle into this Bundle.
        /// </summary>
        /// <param name="bundle">a bundle</param>
        public void putAll(Bundle bundle) {
            mDict.Union(bundle.mDict.AsEnumerable());
            mKeySet.Union(bundle.mKeySet.AsEnumerable());
        }

        /// <summary>
        /// Inserts a boolean value into the mapping of this Bundle,
        /// replacing any existing value for the given key. 
        /// Either key or value may be null.
        /// </summary>
        /// <param name="key">a String, or null.</param>
        /// <param name="value">a Boolean, or null.</param>
        public void putBoolean(String key, bool? value) {
            this.put(key, value);
        }

        /// <summary>
        /// Inserts a boolean array value into the mapping of this Bundle,
        /// replacing any existing value for the given key. 
        /// Either key or value may be null.
        /// </summary>
        /// <param name="key">a String, or null.</param>
        /// <param name="value">a Boolean array, or null.</param>
        public void putBooleanArray(String key, bool[] value) {
            this.put(key, value);
        }

        /// <summary>
        /// Inserts a Bundle value into the mapping of this Bundle,
        /// replacing any existing value for the given key. 
        /// Either key or value may be null.
        /// </summary>
        /// <param name="key">a String, or null.</param>
        /// <param name="value">a Bundle, or null.</param>
        public void putBundle(String key, Bundle value) {
            this.put(key, value);
        }

        /// <summary>
        /// Inserts a byte value into the mapping of this Bundle,
        /// replacing any existing value for the given key. 
        /// Either key or value may be null.
        /// </summary>
        /// <param name="key">a String, or null.</param>
        /// <param name="value">a byte, or null.</param>
        public void putByte(String key, byte? value) {
            this.put(key, value);
        }

        /// <summary>
        /// Inserts a byte array value into the mapping of this Bundle,
        /// replacing any existing value for the given key. 
        /// Either key or value may be null.
        /// </summary>
        /// <param name="key">a String, or null.</param>
        /// <param name="value">a byte array, or null.</param>
        public void putByteArray(String key, byte[] value) {
            this.put(key, value);
        }

        /// <summary>
        /// Inserts a char value into the mapping of this Bundle,
        /// replacing any existing value for the given key. 
        /// Either key or value may be null.
        /// </summary>
        /// <param name="key">a String, or null.</param>
        /// <param name="value">a char, or null.</param>
        public void putChar(String key, char? value) {
            this.put(key, value);
        }

        /// <summary>
        /// Inserts a char array value into the mapping of this Bundle,
        /// replacing any existing value for the given key. 
        /// Either key or value may be null.
        /// </summary>
        /// <param name="key">a String, or null.</param>
        /// <param name="value">a char array, or null.</param>
        public void putCharArray(String key, char[] value) {
            this.put(key, value);
        }

        /// <summary>
        /// Inserts a double value into the mapping of this Bundle,
        /// replacing any existing value for the given key. 
        /// Either key or value may be null.
        /// </summary>
        /// <param name="key">a String, or null.</param>
        /// <param name="value">a double, or null.</param>
        public void putDouble(String key, double? value) {
            this.put(key, value);
        }

        /// <summary>
        /// Inserts a double array value into the mapping of this Bundle,
        /// replacing any existing value for the given key. 
        /// Either key or value may be null.
        /// </summary>
        /// <param name="key">a String, or null.</param>
        /// <param name="value">a double array, or null.</param>
        public void putDoubleArray(String key, double[] value) {
            this.put(key, value);
        }

        /// <summary>
        /// Inserts a float value into the mapping of this Bundle,
        /// replacing any existing value for the given key. 
        /// Either key or value may be null.
        /// </summary>
        /// <param name="key">a String, or null.</param>
        /// <param name="value">a float, or null.</param>
        public void putFloat(String key, float? value) {
            this.put(key, value);
        }

        /// <summary>
        /// Inserts a float array value into the mapping of this Bundle,
        /// replacing any existing value for the given key. 
        /// Either key or value may be null.
        /// </summary>
        /// <param name="key">a String, or null.</param>
        /// <param name="value">a float array, or null.</param>
        public void putFloatArray(String key, float[] value) {
            this.put(key, value);
        }

        /// <summary>
        /// Inserts an int value into the mapping of this Bundle,
        /// replacing any existing value for the given key. 
        /// Either key or value may be null.
        /// </summary>
        /// <param name="key">a String, or null.</param>
        /// <param name="value">an int, or null.</param>
        public void putInt(String key, int? value) {
            this.put(key, value);
        }

        /// <summary>
        /// Inserts an int array value into the mapping of this Bundle,
        /// replacing any existing value for the given key. 
        /// Either key or value may be null.
        /// </summary>
        /// <param name="key">a String, or null.</param>
        /// <param name="value">an int array, or null.</param>
        public void putIntArray(String key, int[] value) {
            this.put(key, value);
        }

        /// <summary>
        /// Inserts a List of integers into the mapping of this Bundle,
        /// replacing any existing value for the given key. 
        /// Either key or value may be null.
        /// </summary>
        /// <param name="key">a String, or null.</param>
        /// <param name="value">a List, or null.</param>
        public void putIntList(String key, List<int> value) {
            this.put(key, value);
        }

        /// <summary>
        /// Inserts a long value into the mapping of this Bundle,
        /// replacing any existing value for the given key. 
        /// Either key or value may be null.
        /// </summary>
        /// <param name="key">a String, or null.</param>
        /// <param name="value">a long, or null.</param>
        public void putLong(String key, long? value) {
            this.put(key, value);
        }

        /// <summary>
        /// Inserts a long array value into the mapping of this Bundle,
        /// replacing any existing value for the given key. 
        /// Either key or value may be null.
        /// </summary>
        /// <param name="key">a String, or null.</param>
        /// <param name="value">a long array, or null.</param>
        public void putLongArray(String key, long[] value) {
            this.put(key, value);
        }

        /// <summary>
        /// Inserts a short value into the mapping of this Bundle,
        /// replacing any existing value for the given key. 
        /// Either key or value may be null.
        /// </summary>
        /// <param name="key">a String, or null.</param>
        /// <param name="value">a short, or null.</param>
        public void putShort(String key, short? value) {
            this.put(key, value);
        }

        /// <summary>
        /// Inserts a short array value into the mapping of this Bundle,
        /// replacing any existing value for the given key. 
        /// Either key or value may be null.
        /// </summary>
        /// <param name="key">a String, or null.</param>
        /// <param name="value">a short array, or null.</param>
        public void putShortArray(String key, short[] value) {
            this.put(key, value);
        }

        /// <summary>
        /// Inserts a string value into the mapping of this Bundle,
        /// replacing any existing value for the given key. 
        /// Either key or value may be null.
        /// </summary>
        /// <param name="key">a String, or null.</param>
        /// <param name="value">a string, or null.</param>
        public void putString(String key, string value) {
            this.put(key, value);
        }

        /// <summary>
        /// Inserts a string array value into the mapping of this Bundle,
        /// replacing any existing value for the given key. 
        /// Either key or value may be null.
        /// </summary>
        /// <param name="key">a String, or null.</param>
        /// <param name="value">a string array, or null.</param>
        public void putStringArray(String key, string[] value) {
            this.put(key, value);
        }

        /// <summary>
        /// Inserts a List of strings into the mapping of this Bundle,
        /// replacing any existing value for the given key. 
        /// Either key or value may be null.
        /// </summary>
        /// <param name="key">a String, or null.</param>
        /// <param name="value">a List, or null.</param>
        public void putStringList(String key, List<string> value) {
            this.put(key, value);
        }
    }
}