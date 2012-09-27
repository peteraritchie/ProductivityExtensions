//////////////////////////////////////////////////////////////////////
// BCLExtensions is (c) 2010 Solutions Design. All rights reserved.
// http://www.sd.nl
//////////////////////////////////////////////////////////////////////
// COPYRIGHTS:
// Copyright (c) 2010 Solutions Design. All rights reserved.
// 
// The BCLExtensions library sourcecode and its accompanying tools, tests and support code
// are released under the following license: (BSD2)
// ----------------------------------------------------------------------
// Redistribution and use in source and binary forms, with or without modification, 
// are permitted provided that the following conditions are met: 
//
// 1) Redistributions of source code must retain the above copyright notice, this list of 
//    conditions and the following disclaimer. 
// 2) Redistributions in binary form must reproduce the above copyright notice, this list of 
//    conditions and the following disclaimer in the documentation and/or other materials 
//    provided with the distribution. 
// 
// THIS SOFTWARE IS PROVIDED BY SOLUTIONS DESIGN ``AS IS'' AND ANY EXPRESS OR IMPLIED WARRANTIES, 
// INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A 
// PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL SOLUTIONS DESIGN OR CONTRIBUTORS BE LIABLE FOR 
// ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT 
// NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR 
// BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, 
// STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE 
// USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE. 
//
// The views and conclusions contained in the software and documentation are those of the authors 
// and should not be interpreted as representing official policies, either expressed or implied, 
// of Solutions Design. 
//
//////////////////////////////////////////////////////////////////////
// Contributers to the code:
//		- Frans Bouma [FB]
//////////////////////////////////////////////////////////////////////
using System;
using System.ComponentModel;

namespace PRI.ProductivityExtensions.EventHandlerExtensions
{
	public static partial class EventHandlerable
	{
		/// <summary>
		/// Raises the event which is represented by the handler specified. 
		/// </summary>
		/// <typeparam name="T">type of the event args</typeparam>
		/// <param name="handler">The handler of the event to raise.</param>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="arguments">The arguments to pass to the handler.</param>
		public static void RaiseEvent<T>(this EventHandler<T> handler, object sender, T arguments)
			where T : EventArgs
		{
			if(handler != null)
			{
				handler(sender, arguments);
			}
		}


		/// <summary>
		/// Raises the PropertyChanged event, if the handler isn't null, otherwise a no-op
		/// </summary>
		/// <param name="handler">The handler.</param>
		/// <param name="sender">The sender.</param>
		/// <param name="propertyName">Name of the property.</param>
		public static void RaiseEvent(this PropertyChangedEventHandler handler, object sender, string propertyName)
		{
			if(handler != null)
			{
				handler(sender, new PropertyChangedEventArgs(propertyName));
			}
		}


		/// <summary>
		/// Raises the event on the handler passed in with default empty arguments
		/// </summary>
		/// <param name="handler">The handler.</param>
		/// <param name="sender">The sender.</param>
		public static void RaiseEvent(this EventHandler handler, object sender)
		{
			if(handler != null)
			{
				handler(sender, EventArgs.Empty);
			}
		}	
	}
}