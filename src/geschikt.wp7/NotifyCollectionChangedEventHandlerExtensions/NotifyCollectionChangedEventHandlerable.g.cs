//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Specialized;

namespace PRI.ProductivityExtensions.NotifyCollectionChangedEventHandlerExtensions
{

	/// <summary>
	/// Class that contains extension methods that extend <seealso cref="System.Collections.Specialized.NotifyCollectionChangedEventHandler">NotifyCollectionChangedEventHandler</seealso>
	/// </summary>
	public static partial class NotifyCollectionChangedEventHandlerable
	{
		/// <summary>
		/// Extends BeginInvoke so that when a state object is not needed, null does not need to be passed.
		/// <example>
		/// notifycollectionchangedeventhandler.BeginInvoke(sender, e, callback);
		/// </example>
		/// </summary>
		public static IAsyncResult BeginInvoke(this NotifyCollectionChangedEventHandler notifycollectionchangedeventhandler, Object sender, NotifyCollectionChangedEventArgs e, AsyncCallback callback)
		{
			if(notifycollectionchangedeventhandler == null) throw new ArgumentNullException("notifycollectionchangedeventhandler");

			return notifycollectionchangedeventhandler.BeginInvoke(sender, e, callback, null);
		}

	}
}
