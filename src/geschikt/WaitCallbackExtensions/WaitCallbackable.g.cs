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

namespace PRI.ProductivityExtensions.WaitCallbackExtensions
{

	/// <summary>
	/// Class that contains extension methods that extend <seealso cref="System.Threading.WaitCallback">WaitCallback</seealso>
	/// </summary>
	public static partial class WaitCallbackable
	{
		/// <summary>
		/// Extends BeginInvoke so that when a state object is not needed, null does not need to be passed.
		/// <example>
		/// waitcallback.BeginInvoke(state, callback);
		/// </example>
		/// </summary>
		public static IAsyncResult BeginInvoke(this WaitCallback waitcallback, Object state, AsyncCallback callback)
		{
			if(waitcallback == null) throw new ArgumentNullException("waitcallback");

			return waitcallback.BeginInvoke(state, callback, null);
		}

	}
}
