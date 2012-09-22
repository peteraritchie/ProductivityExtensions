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

namespace PRI.ProductivityExtensions.RunWorkerCompletedEventHandlerExtensions
{

	/// <summary>
	/// Class that contains extension methods that extend <seealso cref="System.ComponentModel.RunWorkerCompletedEventHandler">RunWorkerCompletedEventHandler</seealso>
	/// </summary>
	public static partial class RunWorkerCompletedEventHandlerable
	{
		/// <summary>
		/// Extends BeginInvoke so that when a state object is not needed, null does not need to be passed.
		/// <example>
		/// runworkercompletedeventhandler.BeginInvoke(sender, e, callback);
		/// </example>
		/// </summary>
		public static IAsyncResult BeginInvoke(this RunWorkerCompletedEventHandler runworkercompletedeventhandler, Object sender, RunWorkerCompletedEventArgs e, AsyncCallback callback)
		{
			if(runworkercompletedeventhandler == null) throw new ArgumentNullException("runworkercompletedeventhandler");

			return runworkercompletedeventhandler.BeginInvoke(sender, e, callback, null);
		}

	}
}
