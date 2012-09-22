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

namespace PRI.ProductivityExtensions.DataGridViewRowEventHandlerExtensions
{

	/// <summary>
	/// Class that contains extension methods that extend <seealso cref="System.Windows.Forms.DataGridViewRowEventHandler">DataGridViewRowEventHandler</seealso>
	/// </summary>
	public static partial class DataGridViewRowEventHandlerable
	{
		/// <summary>
		/// Extends BeginInvoke so that when a state object is not needed, null does not need to be passed.
		/// <example>
		/// datagridviewroweventhandler.BeginInvoke(sender, e, callback);
		/// </example>
		/// </summary>
		public static IAsyncResult BeginInvoke(this DataGridViewRowEventHandler datagridviewroweventhandler, Object sender, DataGridViewRowEventArgs e, AsyncCallback callback)
		{
			if(datagridviewroweventhandler == null) throw new ArgumentNullException("datagridviewroweventhandler");

			return datagridviewroweventhandler.BeginInvoke(sender, e, callback, null);
		}

	}
}
