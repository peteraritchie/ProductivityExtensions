//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Threading;

namespace PRI.ProductivityExtensions.SendOrPostCallbackExtensions
{

	/// <summary>
	/// Class that contains extension methods that extend <seealso cref="System.Threading.SendOrPostCallback">SendOrPostCallback</seealso>
	/// </summary>
	public static partial class SendOrPostCallbackable
	{
		/// <summary>
		/// Extends BeginInvoke so that when a state object is not needed, null does not need to be passed.
		/// <example>
		/// sendorpostcallback.BeginInvoke(state, callback);
		/// </example>
		/// </summary>
		public static IAsyncResult BeginInvoke(this SendOrPostCallback sendorpostcallback, Object state, AsyncCallback callback)
		{
			if(sendorpostcallback == null) throw new ArgumentNullException("sendorpostcallback");

			return sendorpostcallback.BeginInvoke(state, callback, null);
		}

	}
}