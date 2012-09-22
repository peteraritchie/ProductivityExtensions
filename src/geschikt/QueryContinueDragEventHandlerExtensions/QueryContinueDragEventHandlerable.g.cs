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

namespace PRI.ProductivityExtensions.QueryContinueDragEventHandlerExtensions
{

	/// <summary>
	/// Class that contains extension methods that extend <seealso cref="System.Windows.Forms.QueryContinueDragEventHandler">QueryContinueDragEventHandler</seealso>
	/// </summary>
	public static partial class QueryContinueDragEventHandlerable
	{
		/// <summary>
		/// Extends BeginInvoke so that when a state object is not needed, null does not need to be passed.
		/// <example>
		/// querycontinuedrageventhandler.BeginInvoke(sender, e, callback);
		/// </example>
		/// </summary>
		public static IAsyncResult BeginInvoke(this QueryContinueDragEventHandler querycontinuedrageventhandler, Object sender, QueryContinueDragEventArgs e, AsyncCallback callback)
		{
			if(querycontinuedrageventhandler == null) throw new ArgumentNullException("querycontinuedrageventhandler");

			return querycontinuedrageventhandler.BeginInvoke(sender, e, callback, null);
		}

	}
}
