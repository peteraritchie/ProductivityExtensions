//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;

namespace PRI.ProductivityExtensions.EntryWrittenEventHandlerExtensions
{

	/// <summary>
	/// Class that contains extension methods that extend <seealso cref="System.Diagnostics.EntryWrittenEventHandler">EntryWrittenEventHandler</seealso>
	/// </summary>
	public static partial class EntryWrittenEventHandlerable
	{
		/// <summary>
		/// Extends BeginInvoke so that when a state object is not needed, null does not need to be passed.
		/// <example>
		/// entrywritteneventhandler.BeginInvoke(sender, e, callback);
		/// </example>
		/// </summary>
		public static IAsyncResult BeginInvoke(this EntryWrittenEventHandler entrywritteneventhandler, Object sender, EntryWrittenEventArgs e, AsyncCallback callback)
		{
			if(entrywritteneventhandler == null) throw new ArgumentNullException("entrywritteneventhandler");

			return entrywritteneventhandler.BeginInvoke(sender, e, callback, null);
		}

	}
}
