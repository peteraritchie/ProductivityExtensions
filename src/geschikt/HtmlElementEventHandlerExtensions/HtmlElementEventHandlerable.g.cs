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

namespace PRI.ProductivityExtensions.HtmlElementEventHandlerExtensions
{

	/// <summary>
	/// Class that contains extension methods that extend <seealso cref="System.Windows.Forms.HtmlElementEventHandler">HtmlElementEventHandler</seealso>
	/// </summary>
	public static partial class HtmlElementEventHandlerable
	{
		/// <summary>
		/// Extends BeginInvoke so that when a state object is not needed, null does not need to be passed.
		/// <example>
		/// htmlelementeventhandler.BeginInvoke(sender, e, callback);
		/// </example>
		/// </summary>
		public static IAsyncResult BeginInvoke(this HtmlElementEventHandler htmlelementeventhandler, Object sender, HtmlElementEventArgs e, AsyncCallback callback)
		{
			if(htmlelementeventhandler == null) throw new ArgumentNullException("htmlelementeventhandler");

			return htmlelementeventhandler.BeginInvoke(sender, e, callback, null);
		}

	}
}
