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

namespace PRI.ProductivityExtensions.DataGridViewCellPaintingEventHandlerExtensions
{

	/// <summary>
	/// Class that contains extension methods that extend <seealso cref="System.Windows.Forms.DataGridViewCellPaintingEventHandler">DataGridViewCellPaintingEventHandler</seealso>
	/// </summary>
	public static partial class DataGridViewCellPaintingEventHandlerable
	{
		/// <summary>
		/// Extends BeginInvoke so that when a state object is not needed, null does not need to be passed.
		/// <example>
		/// datagridviewcellpaintingeventhandler.BeginInvoke(sender, e, callback);
		/// </example>
		/// </summary>
		public static IAsyncResult BeginInvoke(this DataGridViewCellPaintingEventHandler datagridviewcellpaintingeventhandler, Object sender, DataGridViewCellPaintingEventArgs e, AsyncCallback callback)
		{
			if(datagridviewcellpaintingeventhandler == null) throw new ArgumentNullException("datagridviewcellpaintingeventhandler");

			return datagridviewcellpaintingeventhandler.BeginInvoke(sender, e, callback, null);
		}

	}
}
