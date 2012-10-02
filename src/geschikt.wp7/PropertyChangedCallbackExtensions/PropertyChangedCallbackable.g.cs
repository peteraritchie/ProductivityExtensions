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

namespace PRI.ProductivityExtensions.PropertyChangedCallbackExtensions
{

	/// <summary>
	/// Class that contains extension methods that extend <seealso cref="System.Windows.PropertyChangedCallback">PropertyChangedCallback</seealso>
	/// </summary>
	public static partial class PropertyChangedCallbackable
	{
		/// <summary>
		/// Extends BeginInvoke so that when a state object is not needed, null does not need to be passed.
		/// <example>
		/// propertychangedcallback.BeginInvoke(d, e, callback);
		/// </example>
		/// </summary>
		public static IAsyncResult BeginInvoke(this PropertyChangedCallback propertychangedcallback, DependencyObject d, DependencyPropertyChangedEventArgs e, AsyncCallback callback)
		{
			if(propertychangedcallback == null) throw new ArgumentNullException("propertychangedcallback");

			return propertychangedcallback.BeginInvoke(d, e, callback, null);
		}

	}
}
