//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;

namespace PRI.ProductivityExtensions.AsyncCompletedEventHandlerExtensions
{

	/// <summary>
	/// Class that contains extension methods that extend <seealso cref="System.ComponentModel.AsyncCompletedEventHandler">AsyncCompletedEventHandler</seealso>
	/// </summary>
	public static partial class AsyncCompletedEventHandlerable
	{
		/// <summary>
		/// Extends BeginInvoke so that when a state object is not needed, null does not need to be passed.
		/// <example>
		/// asynccompletedeventhandler.BeginInvoke(sender, e, callback);
		/// </example>
		/// </summary>
		public static IAsyncResult BeginInvoke(this AsyncCompletedEventHandler asynccompletedeventhandler, Object sender, AsyncCompletedEventArgs e, AsyncCallback callback)
		{
			if(asynccompletedeventhandler == null) throw new ArgumentNullException("asynccompletedeventhandler");

			return asynccompletedeventhandler.BeginInvoke(sender, e, callback, null);
		}

	}
}
