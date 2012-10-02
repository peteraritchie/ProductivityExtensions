//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Windows.Controls.Primitives;

namespace PRI.ProductivityExtensions.DragCompletedEventHandlerExtensions
{

	/// <summary>
	/// Class that contains extension methods that extend <seealso cref="System.Windows.Controls.Primitives.DragCompletedEventHandler">DragCompletedEventHandler</seealso>
	/// </summary>
	public static partial class DragCompletedEventHandlerable
	{
		/// <summary>
		/// Extends BeginInvoke so that when a state object is not needed, null does not need to be passed.
		/// <example>
		/// dragcompletedeventhandler.BeginInvoke(sender, e, callback);
		/// </example>
		/// </summary>
		public static IAsyncResult BeginInvoke(this DragCompletedEventHandler dragcompletedeventhandler, Object sender, DragCompletedEventArgs e, AsyncCallback callback)
		{
			if(dragcompletedeventhandler == null) throw new ArgumentNullException("dragcompletedeventhandler");

			return dragcompletedeventhandler.BeginInvoke(sender, e, callback, null);
		}

	}
}
