//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;

namespace PRI.ProductivityExtensions.UnhandledExceptionEventHandlerExtensions
{

	/// <summary>
	/// Class that contains extension methods that extend <seealso cref="System.UnhandledExceptionEventHandler">UnhandledExceptionEventHandler</seealso>
	/// </summary>
	public static partial class UnhandledExceptionEventHandlerable
	{
		/// <summary>
		/// Extends BeginInvoke so that when a state object is not needed, null does not need to be passed.
		/// <example>
		/// unhandledexceptioneventhandler.BeginInvoke(sender, e, callback);
		/// </example>
		/// </summary>
		public static IAsyncResult BeginInvoke(this UnhandledExceptionEventHandler unhandledexceptioneventhandler, Object sender, UnhandledExceptionEventArgs e, AsyncCallback callback)
		{
			if(unhandledexceptioneventhandler == null) throw new ArgumentNullException("unhandledexceptioneventhandler");

			return unhandledexceptioneventhandler.BeginInvoke(sender, e, callback, null);
		}

	}
}
