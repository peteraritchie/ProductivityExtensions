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
using System.Net;

namespace PRI.ProductivityExtensions.DownloadDataCompletedEventHandlerExtensions
{

	/// <summary>
	/// Class that contains extension methods that extend <seealso cref="System.Net.DownloadDataCompletedEventHandler">DownloadDataCompletedEventHandler</seealso>
	/// </summary>
	public static partial class DownloadDataCompletedEventHandlerable
	{
		/// <summary>
		/// Extends BeginInvoke so that when a state object is not needed, null does not need to be passed.
		/// <example>
		/// downloaddatacompletedeventhandler.BeginInvoke(sender, e, callback);
		/// </example>
		/// </summary>
		public static IAsyncResult BeginInvoke(this DownloadDataCompletedEventHandler downloaddatacompletedeventhandler, Object sender, DownloadDataCompletedEventArgs e, AsyncCallback callback)
		{
			if(downloaddatacompletedeventhandler == null) throw new ArgumentNullException("downloaddatacompletedeventhandler");

			return downloaddatacompletedeventhandler.BeginInvoke(sender, e, callback, null);
		}

	}
}
#endif