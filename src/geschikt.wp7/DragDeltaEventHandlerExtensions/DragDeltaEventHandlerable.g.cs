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

namespace PRI.ProductivityExtensions.DragDeltaEventHandlerExtensions
{

	/// <summary>
	/// Class that contains extension methods that extend <seealso cref="System.Windows.Controls.Primitives.DragDeltaEventHandler">DragDeltaEventHandler</seealso>
	/// </summary>
	public static partial class DragDeltaEventHandlerable
	{
		/// <summary>
		/// Extends BeginInvoke so that when a state object is not needed, null does not need to be passed.
		/// <example>
		/// dragdeltaeventhandler.BeginInvoke(sender, e, callback);
		/// </example>
		/// </summary>
		public static IAsyncResult BeginInvoke(this DragDeltaEventHandler dragdeltaeventhandler, Object sender, DragDeltaEventArgs e, AsyncCallback callback)
		{
			if(dragdeltaeventhandler == null) throw new ArgumentNullException("dragdeltaeventhandler");

			return dragdeltaeventhandler.BeginInvoke(sender, e, callback, null);
		}

	}
}
