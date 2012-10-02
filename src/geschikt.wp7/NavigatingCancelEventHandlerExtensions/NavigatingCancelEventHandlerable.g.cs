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

namespace PRI.ProductivityExtensions.NavigatingCancelEventHandlerExtensions
{

	/// <summary>
	/// Class that contains extension methods that extend <seealso cref="System.Windows.Navigation.NavigatingCancelEventHandler">NavigatingCancelEventHandler</seealso>
	/// </summary>
	public static partial class NavigatingCancelEventHandlerable
	{
		/// <summary>
		/// Extends BeginInvoke so that when a state object is not needed, null does not need to be passed.
		/// <example>
		/// navigatingcanceleventhandler.BeginInvoke(sender, e, callback);
		/// </example>
		/// </summary>
		public static IAsyncResult BeginInvoke(this NavigatingCancelEventHandler navigatingcanceleventhandler, Object sender, NavigatingCancelEventArgs e, AsyncCallback callback)
		{
			if(navigatingcanceleventhandler == null) throw new ArgumentNullException("navigatingcanceleventhandler");

			return navigatingcanceleventhandler.BeginInvoke(sender, e, callback, null);
		}

	}
}
