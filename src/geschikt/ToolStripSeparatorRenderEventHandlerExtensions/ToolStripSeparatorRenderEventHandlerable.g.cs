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

namespace PRI.ProductivityExtensions.ToolStripSeparatorRenderEventHandlerExtensions
{

	/// <summary>
	/// Class that contains extension methods that extend <seealso cref="System.Windows.Forms.ToolStripSeparatorRenderEventHandler">ToolStripSeparatorRenderEventHandler</seealso>
	/// </summary>
	public static partial class ToolStripSeparatorRenderEventHandlerable
	{
		/// <summary>
		/// Extends BeginInvoke so that when a state object is not needed, null does not need to be passed.
		/// <example>
		/// toolstripseparatorrendereventhandler.BeginInvoke(sender, e, callback);
		/// </example>
		/// </summary>
		public static IAsyncResult BeginInvoke(this ToolStripSeparatorRenderEventHandler toolstripseparatorrendereventhandler, Object sender, ToolStripSeparatorRenderEventArgs e, AsyncCallback callback)
		{
			if(toolstripseparatorrendereventhandler == null) throw new ArgumentNullException("toolstripseparatorrendereventhandler");

			return toolstripseparatorrendereventhandler.BeginInvoke(sender, e, callback, null);
		}

	}
}
