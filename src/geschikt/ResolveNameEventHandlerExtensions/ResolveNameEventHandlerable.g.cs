//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel.Design.Serialization;

namespace PRI.ProductivityExtensions.ResolveNameEventHandlerExtensions
{

	/// <summary>
	/// Class that contains extension methods that extend <seealso cref="System.ComponentModel.Design.Serialization.ResolveNameEventHandler">ResolveNameEventHandler</seealso>
	/// </summary>
	public static partial class ResolveNameEventHandlerable
	{
		/// <summary>
		/// Extends BeginInvoke so that when a state object is not needed, null does not need to be passed.
		/// <example>
		/// resolvenameeventhandler.BeginInvoke(sender, e, callback);
		/// </example>
		/// </summary>
		public static IAsyncResult BeginInvoke(this ResolveNameEventHandler resolvenameeventhandler, Object sender, ResolveNameEventArgs e, AsyncCallback callback)
		{
			if(resolvenameeventhandler == null) throw new ArgumentNullException("resolvenameeventhandler");

			return resolvenameeventhandler.BeginInvoke(sender, e, callback, null);
		}

	}
}
