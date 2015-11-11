ProductivityExtensions
======================

[![Build status](https://ci.appveyor.com/api/projects/status/d7hnf2d25oull7jq?svg=true)](https://ci.appveyor.com/project/peteraritchie/productivityextensions)

If you're not comfortable with GitHub for issues/feedback.  I've set up a UserVoice site at https://productivityextensions.uservoice.com/

Productivity Extensions is a series of extension methods for .NET 4.0 or newer (Visual Studio 2010 or newer).

Currently, there over 650 methods extending over 400 classes in the .NET Framework.

The .NET Framework has been around since 2002.  There are many common classes and methods that have been around a long time.  The Framework and the languages used to develop on it have evolved quite a bit since many of these classes and their methods came into existence.  Existing classes and methods in the base class library (BCL) could be kept up to date with these technologies, but it's time consuming and potentially destabilizing to add or change methods after a library has been released and Microsoft generally avoids this unless there's a *really good* reason.

Generics, for example, came along in the .Net 2.0 timeframe; so, many existing Framework subsystems never had the benefit of generics to make certain methods more strongly-typed.  Many methods in the Framework take a `Type` parameter and return an `Object` of that `Type` but must be first cast in order for the object to be used as its requested type.  `Attribute.GetCustomAttribute(Assembly, Type)` gets an `Attribute`-based class that has been added at the assembly level.  For example, to get the copyright information of an assembly, you might do something like:

```C#
var aca = (AssemblyCopyrightAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(),
    typeof (AssemblyCopyrightAttribute));
Trace.WriteLine(aca.Copyright);
```

Involving an `Assembly` instance, the `Attribute` class, the `typeof` operator, and a cast.  The Productivity Extensions contains a generic extension method to `Assembly` to get this information without the `Attribute` class, the `typeof` operator or the cast.  For example:

```C#
var aca = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyCopyrightAttribute>();
Trace.WriteLine(aca.Copyright);
```

Anonymous methods was another addition to several .NET programming languages.  Other Framework methods came into existence before anonymous methods so their use could not have used anonymous method  (and thus use captured variables) and tended to require passing along state information.  Asynchronous patterns like the Asynchronous Programming Model (APM) introduced methods starting with `Begin` that asynchronously performed a task and invoked a callback when done that would execute a matching `End` method.  The callback delegate passed to these methods, prior to anonymous methods, had to be instance or class methods and thus had to store the state required to perform the callback explicitly.  This could be done with instance or class members, but often this required passing an opaque state object instance into the `Begin` method that was passed along to the callback via the `IAsyncResult.AsyncState` property.  Almost all `Begin`-pattern methods have a mandatory state parameter.  The callback would cast the object to whatever type it passed in and thus have its state.  For example:

```C#
  //...
  byte[] buffer = new byte[1024];
	fileStream.BeginRead(buffer, 0, buffer.Length, ReadCompleted, fileStream);
  //...

private static void ReadCompleted(IAsyncResult ar)
{
  FileStream fileStream = (FileStream) ar.AsyncState;
	fileStream.EndRead(ar);
	//...
}
```
In this example we're re-using the stream for our state and passing as the state object in the last argument to `BeginRead`.

With anonymous methods passing this state in often became unnecessary as the compiler would generate a state machine to manage any variables used within the anonymous method that were declared outside of the anonymous method.  For example:

```C#
fileStream.BeginRead(buffer, 0, buffer.Length, 
  delegate(IAsyncResult ar) { fileStream.EndRead(ar); },
	null);
```
Or, if you prefer the more recent lambda syntax:
```C#
fileStream.BeginRead(buffer, 0, buffer.Length,
  		            ar => fileStream.EndRead(ar),
			            null);
```

The state passed in in these situations would be `null`.  Using `null`  in many of these places can be a bit tedious.  So, Productivity Extensions includes many extension methods that extend APM `Begin` methods to avoid passing this value in (and just send null).  For example: 

```C#
fileStream.BeginRead(buffer, 0, buffer.Length,
  		            ar => fileStream.EndRead(ar));
```

`FileStream` points out another area of potential productivity increases, the needless passing of `0, buffer.Length`.  Many methods in the BCL that read data into an array require that you pass the initial index and the quantity of bytes (or data) that you want to read--despite there being a `Length` property or `Array` classes.  If I always want to just fill a buffer with data, why is there no method that simply does the `0, buffer.Length` for me?  Well, now there is--in Productivity Extensions.  You can now write:

```C#
fileStream.BeginRead(buffer, ar => fileStream.EndRead(ar));
```

Must less typing.

Other themes in the extension library include interface fluidity.  For example, the `Int32.Seconds()` extension method allows you to create a `TimeSpan` object that represents a span of time of second granularity:

```C#
waitHandle.WaitOne(5.Seconds());
```

###Structure###
The nature of extensions methods is such that they can only be scoped by namespace.  Two extension methods in the same namespace extending the same type, with the same signature will cause an error.

All the extension methods in Productivity Extensions are contained in namespaces unique to the type they extend.  These namespaces are simply called `<ClassName>Extensions`.  If you want to use an extension method, you'll have to add a reference to that namespace within the source code file you want to use it.  Each class being in their own namespace adds a granularity that avoids conflicts with extension methods in other libraries.  If all the extension methods in Productivity Extensions were on one namespace (remember, there's over 650 extension methods that could conflict with other extension methods in different libraries) you would not be able to pick and choose which classes you want to extend in case of a conflict.  For example, if you had a conflict with a method that extends `Stream` with the signature `BeginRead(this Stream stream, Byte[] buffer, AsyncCallback callback, Object state)` but wanted to use the extension method `FontConverter.ConvertTo<T>(Object value)` you'd have to use neither if they were bot in the same namespace.

Each extension class is simply named `<ClassName>able`.  This was arbitrary and basically mirrors `System.Enumerable`.  The name of the class is never used and this provides a way to avoid a conflict with the namespace while providing a cogent namespace.

Some methods may have originated from http://dotnetext.codeplex.com/license