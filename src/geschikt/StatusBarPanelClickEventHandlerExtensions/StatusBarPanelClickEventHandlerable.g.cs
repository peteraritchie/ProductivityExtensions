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

namespace PRI.ProductivityExtensions.StatusBarPanelClickEventHandlerExtensions
{

	/// <summary>
	/// Class that contains extension methods that extend <seealso cref="System.Windows.Forms.StatusBarPanelClickEventHandler">StatusBarPanelClickEventHandler</seealso>
	/// </summary>
	public static partial class StatusBarPanelClickEventHandlerable
	{
		/// <summary>
		/// Extends BeginInvoke so that when a state object is not needed, null does not need to be passed.
		/// <example>
		/// statusbarpanelclickeventhandler.BeginInvoke(sender, e, callback);
		/// </example>
		/// </summary>
		public static IAsyncResult BeginInvoke(this StatusBarPanelClickEventHandler statusbarpanelclickeventhandler, Object sender, StatusBarPanelClickEventArgs e, AsyncCallback callback)
		{
			if(statusbarpanelclickeventhandler == null) throw new ArgumentNullException("statusbarpanelclickeventhandler");

			return statusbarpanelclickeventhandler.BeginInvoke(sender, e, callback, null);
		}

	}
}
