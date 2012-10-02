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

namespace PRI.ProductivityExtensions.DownloadStringCompletedEventHandlerExtensions
{

	/// <summary>
	/// Class that contains extension methods that extend <seealso cref="System.Net.DownloadStringCompletedEventHandler">DownloadStringCompletedEventHandler</seealso>
	/// </summary>
	public static partial class DownloadStringCompletedEventHandlerable
	{
		/// <summary>
		/// Extends BeginInvoke so that when a state object is not needed, null does not need to be passed.
		/// <example>
		/// downloadstringcompletedeventhandler.BeginInvoke(sender, e, callback);
		/// </example>
		/// </summary>
		public static IAsyncResult BeginInvoke(this DownloadStringCompletedEventHandler downloadstringcompletedeventhandler, Object sender, DownloadStringCompletedEventArgs e, AsyncCallback callback)
		{
			if(downloadstringcompletedeventhandler == null) throw new ArgumentNullException("downloadstringcompletedeventhandler");

			return downloadstringcompletedeventhandler.BeginInvoke(sender, e, callback, null);
		}

	}
}
