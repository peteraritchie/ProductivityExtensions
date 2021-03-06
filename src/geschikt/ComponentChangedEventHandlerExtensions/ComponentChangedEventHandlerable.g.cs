#if (NETSTANDARD2_0 || NET45 || NET40 || NET451 || NET452 || NET46 || NET461 || NET462)
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel.Design;

namespace PRI.ProductivityExtensions.ComponentChangedEventHandlerExtensions
{

	/// <summary>
	/// Class that contains extension methods that extend <seealso cref="System.ComponentModel.Design.ComponentChangedEventHandler">ComponentChangedEventHandler</seealso>
	/// </summary>
	public static partial class ComponentChangedEventHandlerable
	{
		/// <summary>
		/// Extends BeginInvoke so that when a state object is not needed, null does not need to be passed.
		/// <example>
		/// componentchangedeventhandler.BeginInvoke(sender, e, callback);
		/// </example>
		/// </summary>
		public static IAsyncResult BeginInvoke(this ComponentChangedEventHandler componentchangedeventhandler, Object sender, ComponentChangedEventArgs e, AsyncCallback callback)
		{
			if(componentchangedeventhandler == null) throw new ArgumentNullException("componentchangedeventhandler");

			return componentchangedeventhandler.BeginInvoke(sender, e, callback, null);
		}

	}
}
#endif