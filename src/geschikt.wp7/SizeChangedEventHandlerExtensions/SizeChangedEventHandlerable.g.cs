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

namespace PRI.ProductivityExtensions.SizeChangedEventHandlerExtensions
{

	/// <summary>
	/// Class that contains extension methods that extend <seealso cref="System.Windows.SizeChangedEventHandler">SizeChangedEventHandler</seealso>
	/// </summary>
	public static partial class SizeChangedEventHandlerable
	{
		/// <summary>
		/// Extends BeginInvoke so that when a state object is not needed, null does not need to be passed.
		/// <example>
		/// sizechangedeventhandler.BeginInvoke(sender, e, callback);
		/// </example>
		/// </summary>
		public static IAsyncResult BeginInvoke(this SizeChangedEventHandler sizechangedeventhandler, Object sender, SizeChangedEventArgs e, AsyncCallback callback)
		{
			if(sizechangedeventhandler == null) throw new ArgumentNullException("sizechangedeventhandler");

			return sizechangedeventhandler.BeginInvoke(sender, e, callback, null);
		}

	}
}
