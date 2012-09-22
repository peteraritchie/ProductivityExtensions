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

namespace PRI.ProductivityExtensions.ColumnReorderedEventHandlerExtensions
{

	/// <summary>
	/// Class that contains extension methods that extend <seealso cref="System.Windows.Forms.ColumnReorderedEventHandler">ColumnReorderedEventHandler</seealso>
	/// </summary>
	public static partial class ColumnReorderedEventHandlerable
	{
		/// <summary>
		/// Extends BeginInvoke so that when a state object is not needed, null does not need to be passed.
		/// <example>
		/// columnreorderedeventhandler.BeginInvoke(sender, e, callback);
		/// </example>
		/// </summary>
		public static IAsyncResult BeginInvoke(this ColumnReorderedEventHandler columnreorderedeventhandler, Object sender, ColumnReorderedEventArgs e, AsyncCallback callback)
		{
			if(columnreorderedeventhandler == null) throw new ArgumentNullException("columnreorderedeventhandler");

			return columnreorderedeventhandler.BeginInvoke(sender, e, callback, null);
		}

	}
}
