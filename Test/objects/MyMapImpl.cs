using System ;
using System.Collections ;
//--------------------------------------------------------------------------
//	Copyright (c) 2004, Drew Davidson and Luke Blanshard
//  All rights reserved.
//
//	Redistribution and use in source and binary forms, with or without
//  modification, are permitted provided that the following conditions are
//  met:
//
//	Redistributions of source code must retain the above copyright notice,
//  this list of conditions and the following disclaimer.
//	Redistributions in binary form must reproduce the above copyright
//  notice, this list of conditions and the following disclaimer in the
//  documentation and/or other materials provided with the distribution.
//	Neither the name of the Drew Davidson nor the names of its contributors
//  may be used to endorse or promote products derived from this software
//  without specific prior written permission.
//
//	THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
//  "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
//  LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS
//  FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE
//  COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT,
//  INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
//  BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS
//  OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED
//  AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
//  OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF
//  THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH
//  DAMAGE.
//--------------------------------------------------------------------------
namespace org.ognl.test.objects
{

	/**
		This tests the interface inheritence test.  This test implements
		MyMap->Map but extends object, therefore should be coded using
		MapPropertyAccessor instead of ObjectPropertyAccessor.
	 */
	public class MyMapImpl : MyMap
	{
		public ICollection Keys
		{
			get { return map.Keys ; }
		}

		public ICollection Values
		{
			get { return map.Values ; }
		}

		public bool IsReadOnly
		{
			get { return map.IsReadOnly ; }
		}

		public bool IsFixedSize
		{
			get { return map.IsFixedSize ; }
		}

		public bool Contains (object key)
		{
			return map.Contains (key) ;
		}

		public void Add (object key, object value)
		{
			map.Add (key, value) ;
		}

		public void Clear ()
		{
			map.Clear () ;
		}

		public IDictionaryEnumerator GetEnumerator ()
		{
			return map.GetEnumerator () ;
		}

		IEnumerator IEnumerable.GetEnumerator ()
		{
			return map.GetEnumerator () ;
		}
		public void Remove (object key)
		{
			map.Remove (key) ;
		}

		public object this [object key]
		{
			get { return map [key] ; }
			set { map [key] = value ; }
		}

		public int Count
		{
			get { return map.Count ; }
		}

		public object SyncRoot
		{
			get { return map.SyncRoot ; }
		}

		public bool IsSynchronized
		{
			get { return map.IsSynchronized ; }
		}

		public void CopyTo (Array array, int index)
		{
			map.CopyTo (array, index) ;
		}

		private IDictionary				map = new Hashtable();

		public override bool Equals (object obj)
		{
			return map.Equals (obj) ;
		}

		public override int GetHashCode ()
		{
			return map.GetHashCode () ;
		}

		public string getDescription()
		{
			return "MyMap implementation";
		}
	}
}
