//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Threading;

namespace PRI.ProductivityExtensions.ThreadExceptionEventHandlerExtensions
{

	/// <summary>
	/// Class that contains extension methods that extend <seealso cref="System.Threading.ThreadExceptionEventHandler">ThreadExceptionEventHandler</seealso>
	/// </summary>
	public static partial class ThreadExceptionEventHandlerable
	{
		/// <summary>
		/// Extends BeginInvoke so that when a state object is not needed, null does not need to be passed.
		/// <example>
		/// threadexceptioneventhandler.BeginInvoke(sender, e, callback);
		/// </example>
		/// </summary>
		public static IAsyncResult BeginInvoke(this ThreadExceptionEventHandler threadexceptioneventhandler, Object sender, ThreadExceptionEventArgs e, AsyncCallback callback)
		{
			if(threadexceptioneventhandler == null) throw new ArgumentNullException("threadexceptioneventhandler");

			return threadexceptioneventhandler.BeginInvoke(sender, e, callback, null);
		}

	}
}
