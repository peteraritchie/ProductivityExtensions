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

namespace PRI.ProductivityExtensions.DateRangeEventHandlerExtensions
{

	/// <summary>
	/// Class that contains extension methods that extend <seealso cref="System.Windows.Forms.DateRangeEventHandler">DateRangeEventHandler</seealso>
	/// </summary>
	public static partial class DateRangeEventHandlerable
	{
		/// <summary>
		/// Extends BeginInvoke so that when a state object is not needed, null does not need to be passed.
		/// <example>
		/// daterangeeventhandler.BeginInvoke(sender, e, callback);
		/// </example>
		/// </summary>
		public static IAsyncResult BeginInvoke(this DateRangeEventHandler daterangeeventhandler, Object sender, DateRangeEventArgs e, AsyncCallback callback)
		{
			if(daterangeeventhandler == null) throw new ArgumentNullException("daterangeeventhandler");

			return daterangeeventhandler.BeginInvoke(sender, e, callback, null);
		}

	}
}
