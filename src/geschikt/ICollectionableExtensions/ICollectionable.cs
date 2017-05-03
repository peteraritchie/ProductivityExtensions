﻿//////////////////////////////////////////////////////////////////////
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
using System.Collections.Generic;

namespace PRI.ProductivityExtensions.ICollectionableExtensions
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ICollectionable'
	public static partial class ICollectionable
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ICollectionable'
	{
		/// <summary>
		/// Determines whether the passed in list is null or empty.
		/// </summary>
		/// <typeparam name="T">the type of the elements in the list to check</typeparam>
		/// <param name="toCheck">the list to check.</param>
		/// <returns>true if the passed in list is null or empty, false otherwise</returns>
		// PR: was originally extension IList<T>
		public static bool IsNullOrEmpty<T>(this ICollection<T> toCheck)
		{
			return ((toCheck == null) || (toCheck.Count <= 0));
		}

		/// <summary>
		/// Adds the range defined by source to the destination.
		/// </summary>
		/// <param name="destination">The destination.</param>
		/// <param name="source">The source.</param>
		// PR: was originally an extension on HashSet<T>
		public static void AddRange<T>(this ICollection<T> destination, IEnumerable<T> source)
		{
			if (destination == null) throw new ArgumentNullException("destination");
			if (source == null) return;

			foreach (T element in source)
			{
				destination.Add(element);
			}
		}
	}
}