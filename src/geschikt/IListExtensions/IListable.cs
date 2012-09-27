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
using System.Collections.Generic;

namespace PRI.ProductivityExtensions.IListExtensions
{
	public static class IListable
	{
		/// <summary>
		/// Swaps the values at indexA and indexB.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source">The source.</param>
		/// <param name="indexA">The index for A.</param>
		/// <param name="indexB">The index for B.</param>
		public static void SwapValues<T>(this IList<T> source, int indexA, int indexB)
		{
			if (source == null) throw new ArgumentNullException("source");
			if ((indexA < uint.MinValue) || (indexA >= source.Count))
			{
				throw new IndexOutOfRangeException("indexA is out of range");
			}
			if ((indexB < uint.MinValue) || (indexB >= source.Count))
			{
				throw new IndexOutOfRangeException("indexB is out of range");
			}

			if (indexA == indexB)
			{
				return;
			}

			T tempValue = source[indexA];
			source[indexA] = source[indexB];
			source[indexB] = tempValue;
		}

		/// <summary>
		/// Searches for the element specified in the sorted list specified using binary search http://en.wikipedia.org/wiki/Binary_search. The algorithm
		/// is re-implemented here to be able to search in any sorted IList implementing data structure (.NET's BCL only implements BinarySearch on arrays and
		/// List(Of T). If no IComparer(Of T) is available, try using Algorithmia's ComparisonBasedComparer, 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="sortedList">The sorted list.</param>
		/// <param name="element">The element.</param>
		/// <param name="comparer">The comparer.</param>
		/// <returns>The index of the element searched or the bitwise complement of the index of the next element that is larger than 
		/// <i>element</i> or if there is no larger element the bitwise complement of Count. Bitwise complements have their original bits negated. Use
		/// the '~' operator in C# to get the real value. Bitwise complements are used to avoid returning a value which is in the range of valid indices so 
		/// callers can't check whether the value returned is an index or if the element wasn't found. If the value returned is negative, the bitwise complement
		/// can be used as index to insert the element in the sorted list to keep the list sorted</returns>
		/// <remarks>Assumes that sortedList is sorted ascending. If you pass in a descending sorted list, be sure the comparer is adjusted as well.</remarks>
		public static int BinarySearch<T>(this IList<T> sortedList, T element, IComparer<T> comparer)
		{
			if (sortedList == null) throw new ArgumentNullException("sortedList");
			if (sortedList.Count <= 0)
			{
				return -1;
			}

			int left = 0;
			int right = sortedList.Count - 1;
			while (left <= right)
			{
				// determine the index in the list to compare with. This is the middle of the segment we're searching in.
				int index = left + (right - left) / 2;
				int compareResult = comparer.Compare(sortedList[index], element);
				if (compareResult == 0)
				{
					// found it, done. Return the index
					return index;
				}
				if (compareResult < 0)
				{
					// element is bigger than the element at index, so we can skip all elements at the left of index including the element at index.
					left = index + 1;
				}
				else
				{
					// element is smaller than the element at index, so we can skip all elements at the right of index including the element at index.
					right = index - 1;
				}
			}
			return ~left;
		}
	}
}