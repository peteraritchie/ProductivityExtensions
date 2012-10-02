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

namespace PRI.ProductivityExtensions.PropertyChangedEventHandlerExtensions
{

	/// <summary>
	/// Class that contains extension methods that extend <seealso cref="System.ComponentModel.PropertyChangedEventHandler">PropertyChangedEventHandler</seealso>
	/// </summary>
	public static partial class PropertyChangedEventHandlerable
	{
		/// <summary>
		/// Extends BeginInvoke so that when a state object is not needed, null does not need to be passed.
		/// <example>
		/// propertychangedeventhandler.BeginInvoke(sender, e, callback);
		/// </example>
		/// </summary>
		public static IAsyncResult BeginInvoke(this PropertyChangedEventHandler propertychangedeventhandler, Object sender, PropertyChangedEventArgs e, AsyncCallback callback)
		{
			if(propertychangedeventhandler == null) throw new ArgumentNullException("propertychangedeventhandler");

			return propertychangedeventhandler.BeginInvoke(sender, e, callback, null);
		}

	}
}
