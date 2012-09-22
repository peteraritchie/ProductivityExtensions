//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.SqlClient;

namespace PRI.ProductivityExtensions.SqlRowUpdatingEventHandlerExtensions
{

	/// <summary>
	/// Class that contains extension methods that extend <seealso cref="System.Data.SqlClient.SqlRowUpdatingEventHandler">SqlRowUpdatingEventHandler</seealso>
	/// </summary>
	public static partial class SqlRowUpdatingEventHandlerable
	{
		/// <summary>
		/// Extends BeginInvoke so that when a state object is not needed, null does not need to be passed.
		/// <example>
		/// sqlrowupdatingeventhandler.BeginInvoke(sender, e, callback);
		/// </example>
		/// </summary>
		public static IAsyncResult BeginInvoke(this SqlRowUpdatingEventHandler sqlrowupdatingeventhandler, Object sender, SqlRowUpdatingEventArgs e, AsyncCallback callback)
		{
			if(sqlrowupdatingeventhandler == null) throw new ArgumentNullException("sqlrowupdatingeventhandler");

			return sqlrowupdatingeventhandler.BeginInvoke(sender, e, callback, null);
		}

	}
}
