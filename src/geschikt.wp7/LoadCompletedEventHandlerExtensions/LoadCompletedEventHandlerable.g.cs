//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Windows.Navigation;

namespace PRI.ProductivityExtensions.LoadCompletedEventHandlerExtensions
{

	/// <summary>
	/// Class that contains extension methods that extend <seealso cref="System.Windows.Navigation.LoadCompletedEventHandler">LoadCompletedEventHandler</seealso>
	/// </summary>
	public static partial class LoadCompletedEventHandlerable
	{
		/// <summary>
		/// Extends BeginInvoke so that when a state object is not needed, null does not need to be passed.
		/// <example>
		/// loadcompletedeventhandler.BeginInvoke(sender, e, callback);
		/// </example>
		/// </summary>
		public static IAsyncResult BeginInvoke(this LoadCompletedEventHandler loadcompletedeventhandler, Object sender, NavigationEventArgs e, AsyncCallback callback)
		{
			if(loadcompletedeventhandler == null) throw new ArgumentNullException("loadcompletedeventhandler");

			return loadcompletedeventhandler.BeginInvoke(sender, e, callback, null);
		}

	}
}
