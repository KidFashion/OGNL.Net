using System.Collections ;

using java ;

using ognl ;
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

	public class Root
	{
		public const string      SIZE_STRING = "size";
		public const int         STATIC_INT = 23;

		private int[]                   array = { 1, 2, 3, 4 };
		private IDictionary                     map = new Hashtable(23);
		private MyMap                   myMap = new MyMapImpl();
		private IList                    list ;
		private IList                    settableList = new ArrayList( Util.asList(new object[] { "foo", "bar", "baz" }));
		private int                     index = 1;
		private int                     intValue = 0;
		private string                  stringValue;
		private int                     yetAnotherIntValue = 46;
		private bool                 privateAccessorBooleanValue = true;
		private int                     privateAccessorIntValue = 67;
		private int                     privateAccessorIntValue2 = 67;
		private int                     privateAccessorIntValue3 = 67;
		public string                   anotherStringValue = "foo";
		public int                      anotherIntValue = 123;
		public int                      six = 6;

		/*===================================================================
			Public static methods
		  ===================================================================*/
		public static int getStaticInt()
		{
			return STATIC_INT;
		}

		/*===================================================================
			Constructors
		  ===================================================================*/
		public Root()
		{
			list = Util.asList (new object[] { null, this, array }) ;
			map.Add( "test", this );
			map.Add( "array", array );
			map.Add( "list", list );
			map.Add( "size", 5000 );
			map.Add( DynamicSubscript.first, 99 );

			/* make myMap identical */
			Util.putAll( map , myMap );
		}

		/*===================================================================
			Private methods
		  ===================================================================*/
	
		private bool isPrivateAccessorBooleanValue()
		{
			return privateAccessorBooleanValue;
		}

		private void setPrivateAccessorBooleanValue(bool value)
		{
			privateAccessorBooleanValue = value;
		}

		private int getPrivateAccessorIntValue()
		{
			return privateAccessorIntValue;
		}

		private void setPrivateAccessorIntValue(int value)
		{
			privateAccessorIntValue = value;
		}

		/*===================================================================
			Protected methods
		  ===================================================================*/
		protected int getPrivateAccessorIntValue2()
		{
			return privateAccessorIntValue2;
		}

		protected void setPrivateAccessorIntValue2(int value)
		{
			privateAccessorIntValue2 = value;
		}

		/*===================================================================
			Package protected methods
		  ===================================================================*/
		int getPrivateAccessorIntValue3()
		{
			return privateAccessorIntValue3;
		}

		void setPrivateAccessorIntValue3(int value)
		{
			privateAccessorIntValue3 = value;
		}

		/*===================================================================
			Public methods
		  ===================================================================*/
		public int[] getArray()
		{
			return array;
		}

		public void setArray(int[] value)
		{
			array = value;
		}

		public IDictionary getMap()
		{
			return map;
		}

		public MyMap getMyMap()
		{
			return myMap;
		}

		public IList getList()
		{
			return list;
		}

		public IList getSettableList()
		{
			return settableList;
		}

		public int getIndex()
		{
			return index;
		}

		public int getIntValue()
		{
			return intValue;
		}

		public void setIntValue(int value)
		{
			intValue = value;
		}

		public string getStringValue()
		{
			return stringValue;
		}

		public void setStringValue(string value)
		{
			stringValue = value;
		}

		public object getNullObject()
		{
			return null;
		}
	}
}
