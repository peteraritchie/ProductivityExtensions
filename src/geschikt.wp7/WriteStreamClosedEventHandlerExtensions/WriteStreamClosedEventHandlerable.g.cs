//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Net;

namespace PRI.ProductivityExtensions.WriteStreamClosedEventHandlerExtensions
{

	/// <summary>
	/// Class that contains extension methods that extend <seealso cref="System.Net.WriteStreamClosedEventHandler">WriteStreamClosedEventHandler</seealso>
	/// </summary>
	public static partial class WriteStreamClosedEventHandlerable
	{
		/// <summary>
		/// Extends BeginInvoke so that when a state object is not needed, null does not need to be passed.
		/// <example>
		/// writestreamclosedeventhandler.BeginInvoke(sender, e, callback);
		/// </example>
		/// </summary>
		public static IAsyncResult BeginInvoke(this WriteStreamClosedEventHandler writestreamclosedeventhandler, Object sender, WriteStreamClosedEventArgs e, AsyncCallback callback)
		{
			if(writestreamclosedeventhandler == null) throw new ArgumentNullException("writestreamclosedeventhandler");

			return writestreamclosedeventhandler.BeginInvoke(sender, e, callback, null);
		}

	}
}
