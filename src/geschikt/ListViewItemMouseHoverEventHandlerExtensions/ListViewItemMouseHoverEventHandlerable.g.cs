//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Windows.Forms;

namespace PRI.ProductivityExtensions.ListViewItemMouseHoverEventHandlerExtensions
{

	/// <summary>
	/// Class that contains extension methods that extend <seealso cref="System.Windows.Forms.ListViewItemMouseHoverEventHandler">ListViewItemMouseHoverEventHandler</seealso>
	/// </summary>
	public static partial class ListViewItemMouseHoverEventHandlerable
	{
		/// <summary>
		/// Extends BeginInvoke so that when a state object is not needed, null does not need to be passed.
		/// <example>
		/// listviewitemmousehovereventhandler.BeginInvoke(sender, e, callback);
		/// </example>
		/// </summary>
		public static IAsyncResult BeginInvoke(this ListViewItemMouseHoverEventHandler listviewitemmousehovereventhandler, Object sender, ListViewItemMouseHoverEventArgs e, AsyncCallback callback)
		{
			if(listviewitemmousehovereventhandler == null) throw new ArgumentNullException("listviewitemmousehovereventhandler");

			return listviewitemmousehovereventhandler.BeginInvoke(sender, e, callback, null);
		}

	}
}
