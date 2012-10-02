//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Windows;

namespace PRI.ProductivityExtensions.DependencyPropertyChangedEventHandlerExtensions
{

	/// <summary>
	/// Class that contains extension methods that extend <seealso cref="System.Windows.DependencyPropertyChangedEventHandler">DependencyPropertyChangedEventHandler</seealso>
	/// </summary>
	public static partial class DependencyPropertyChangedEventHandlerable
	{
		/// <summary>
		/// Extends BeginInvoke so that when a state object is not needed, null does not need to be passed.
		/// <example>
		/// dependencypropertychangedeventhandler.BeginInvoke(sender, e, callback);
		/// </example>
		/// </summary>
		public static IAsyncResult BeginInvoke(this DependencyPropertyChangedEventHandler dependencypropertychangedeventhandler, Object sender, DependencyPropertyChangedEventArgs e, AsyncCallback callback)
		{
			if(dependencypropertychangedeventhandler == null) throw new ArgumentNullException("dependencypropertychangedeventhandler");

			return dependencypropertychangedeventhandler.BeginInvoke(sender, e, callback, null);
		}

	}
}
