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

namespace PRI.ProductivityExtensions.UploadDataCompletedEventHandlerExtensions
{

	/// <summary>
	/// Class that contains extension methods that extend <seealso cref="System.Net.UploadDataCompletedEventHandler">UploadDataCompletedEventHandler</seealso>
	/// </summary>
	public static partial class UploadDataCompletedEventHandlerable
	{
		/// <summary>
		/// Extends BeginInvoke so that when a state object is not needed, null does not need to be passed.
		/// <example>
		/// uploaddatacompletedeventhandler.BeginInvoke(sender, e, callback);
		/// </example>
		/// </summary>
		public static IAsyncResult BeginInvoke(this UploadDataCompletedEventHandler uploaddatacompletedeventhandler, Object sender, UploadDataCompletedEventArgs e, AsyncCallback callback)
		{
			if(uploaddatacompletedeventhandler == null) throw new ArgumentNullException("uploaddatacompletedeventhandler");

			return uploaddatacompletedeventhandler.BeginInvoke(sender, e, callback, null);
		}

	}
}
