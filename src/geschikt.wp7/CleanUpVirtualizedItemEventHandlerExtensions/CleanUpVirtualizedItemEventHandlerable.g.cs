//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Windows.Controls;

namespace PRI.ProductivityExtensions.CleanUpVirtualizedItemEventHandlerExtensions
{

	/// <summary>
	/// Class that contains extension methods that extend <seealso cref="System.Windows.Controls.CleanUpVirtualizedItemEventHandler">CleanUpVirtualizedItemEventHandler</seealso>
	/// </summary>
	public static partial class CleanUpVirtualizedItemEventHandlerable
	{
		/// <summary>
		/// Extends BeginInvoke so that when a state object is not needed, null does not need to be passed.
		/// <example>
		/// cleanupvirtualizeditemeventhandler.BeginInvoke(sender, e, callback);
		/// </example>
		/// </summary>
		public static IAsyncResult BeginInvoke(this CleanUpVirtualizedItemEventHandler cleanupvirtualizeditemeventhandler, Object sender, CleanUpVirtualizedItemEventArgs e, AsyncCallback callback)
		{
			if(cleanupvirtualizeditemeventhandler == null) throw new ArgumentNullException("cleanupvirtualizeditemeventhandler");

			return cleanupvirtualizeditemeventhandler.BeginInvoke(sender, e, callback, null);
		}

	}
}