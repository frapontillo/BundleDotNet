# BundleDotNet #
**BundleDotNet** is an C# implementation of the `Bundle` class [you can find](http://developer.android.com/reference/android/os/Bundle.html) on the Android SDK. 
It basically is a wrapper around a `HashSet` that leverages you from casting the returned object.

## Information ##
Created by **Francesco Pontillo**

NuGet repo: [http://nuget.org/packages/BundleDotNet/](http://nuget.org/packages/BundleDotNet/)

## Get it ##
In Visual Studio, open the Package Manager console and issue the following command:

`PM> Install-Package BundleDotNet`

If you don't want to use NuGet, you can simply download the binaries from the [official NuGet page](http://nuget.org/packages/BundleDotNet/).

## How to use ##

### Instantiating ###
You can directly use a `Bundle` by instantiating it:

```c#
	Bundle b = new Bundle();
	Bundle sizedB = new Bundle(initialCapacity);
	Bundle copiedBundle = new Bundle(b);
```

### BundleBuilder ###
Otherwise, you can use the convenient `BundleBuilder`:

```c#
	BundleBuilder builder = new BundleBuilder();
	builder.put(...).put(...).put(...).getBundle();
```

`BundleBuilder` exposes chainable methods which you can use to build a `Bundle` in one line.

### Calling the methods ###
Then, you can use all of the get and put methods you'd imagine:

```c#
	b.putBoolean(mBool);
	b.putBoolean(mBool, defaultBool);
	b.putBooleanArray(mBoolArray);
	b.putChar(mChar);
	b.putChar(mChar, defaultChar);
	b.putCharArray(mCharArray);
	// ...
```

And the list goes on. You can check out the IntelliSense documentation. The complete list of the classes you can use in a `Bundle` without executing any kind of casting is:

- `bool?`
- `bool[]`
- `Bundle`
- `byte?`
- `byte[]`
- `char?`
- `char[]`
- `double?`
- `double[]`
- `float?`
- `float[]`
- `int?`
- `int[]`
- `List<int>`
- `long?`
- `long[]`
- `short?`
- `short[]`
- `string`
- `string[]`
- `List<string>`
- `object`, using `put(string key, object obj)`

Other methods are:

- `clear()`, to clear the content of the `Bundle`
- `clone()`, to clone the `Bundle`, equivalent to n`ew Bundle(originalBundle)`
- `containsKey(String key)`
- `isEmpty()`
- `keySet()`, returns a `HashSet<string>` of the keys in the `Bundle`
- `size()`
- `get(String key)`, returns an uncast `object`
- `get<T>(String key)`, returns a cast `object`
- `get<T>(String key, T defaultValue)`, returns the found object or a default value
- `put(String key, object value)`, puts a generic object
- `remove(String key)`

## Version History ##
- 1.0.0: released on 01/23/2013.

## License ##
Released under the [MIT license](http://www.opensource.org/licenses/mit-license.php).

Copyright (c) 2013 Francesco Pontillo

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE /SOFTWARE.