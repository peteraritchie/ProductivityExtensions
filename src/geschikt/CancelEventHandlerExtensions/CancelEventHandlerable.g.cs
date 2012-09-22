//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;

namespace PRI.ProductivityExtensions.CancelEventHandlerExtensions
{

	/// <summary>
	/// Class that contains extension methods that extend <seealso cref="System.ComponentModel.CancelEventHandler">CancelEventHandler</seealso>
	/// </summary>
	public static partial class CancelEventHandlerable
	{
		/// <summary>
		/// Extends BeginInvoke so that when a state object is not needed, null does not need to be passed.
		/// <example>
		/// canceleventhandler.BeginInvoke(sender, e, callback);
		/// </example>
		/// </summary>
		public static IAsyncResult BeginInvoke(this CancelEventHandler canceleventhandler, Object sender, CancelEventArgs e, AsyncCallback callback)
		{
			if(canceleventhandler == null) throw new ArgumentNullException("canceleventhandler");

			return canceleventhandler.BeginInvoke(sender, e, callback, null);
		}

	}
}
