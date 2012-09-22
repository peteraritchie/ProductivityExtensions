//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Windows.Forms;

namespace PRI.ProductivityExtensions.PropertyValueChangedEventHandlerExtensions
{

	/// <summary>
	/// Class that contains extension methods that extend <seealso cref="System.Windows.Forms.PropertyValueChangedEventHandler">PropertyValueChangedEventHandler</seealso>
	/// </summary>
	public static partial class PropertyValueChangedEventHandlerable
	{
		/// <summary>
		/// Extends BeginInvoke so that when a state object is not needed, null does not need to be passed.
		/// <example>
		/// propertyvaluechangedeventhandler.BeginInvoke(s, e, callback);
		/// </example>
		/// </summary>
		public static IAsyncResult BeginInvoke(this PropertyValueChangedEventHandler propertyvaluechangedeventhandler, Object s, PropertyValueChangedEventArgs e, AsyncCallback callback)
		{
			if(propertyvaluechangedeventhandler == null) throw new ArgumentNullException("propertyvaluechangedeventhandler");

			return propertyvaluechangedeventhandler.BeginInvoke(s, e, callback, null);
		}

	}
}
