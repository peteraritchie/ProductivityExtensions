#if (NETSTANDARD2_0 || NET45 || NET40 || NET451 || NET452 || NET46 || NET461 || NET462)
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data;

namespace PRI.ProductivityExtensions.DataTableClearEventHandlerExtensions
{

	/// <summary>
	/// Class that contains extension methods that extend <seealso cref="System.Data.DataTableClearEventHandler">DataTableClearEventHandler</seealso>
	/// </summary>
	public static partial class DataTableClearEventHandlerable
	{
		/// <summary>
		/// Extends BeginInvoke so that when a state object is not needed, null does not need to be passed.
		/// <example>
		/// datatablecleareventhandler.BeginInvoke(sender, e, callback);
		/// </example>
		/// </summary>
		public static IAsyncResult BeginInvoke(this DataTableClearEventHandler datatablecleareventhandler, Object sender, DataTableClearEventArgs e, AsyncCallback callback)
		{
			if(datatablecleareventhandler == null) throw new ArgumentNullException("datatablecleareventhandler");

			return datatablecleareventhandler.BeginInvoke(sender, e, callback, null);
		}

	}
}
#endif