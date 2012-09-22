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

namespace PRI.ProductivityExtensions.LinkLabelLinkClickedEventHandlerExtensions
{

	/// <summary>
	/// Class that contains extension methods that extend <seealso cref="System.Windows.Forms.LinkLabelLinkClickedEventHandler">LinkLabelLinkClickedEventHandler</seealso>
	/// </summary>
	public static partial class LinkLabelLinkClickedEventHandlerable
	{
		/// <summary>
		/// Extends BeginInvoke so that when a state object is not needed, null does not need to be passed.
		/// <example>
		/// linklabellinkclickedeventhandler.BeginInvoke(sender, e, callback);
		/// </example>
		/// </summary>
		public static IAsyncResult BeginInvoke(this LinkLabelLinkClickedEventHandler linklabellinkclickedeventhandler, Object sender, LinkLabelLinkClickedEventArgs e, AsyncCallback callback)
		{
			if(linklabellinkclickedeventhandler == null) throw new ArgumentNullException("linklabellinkclickedeventhandler");

			return linklabellinkclickedeventhandler.BeginInvoke(sender, e, callback, null);
		}

	}
}
