using System ;
using System.Collections ;
using System.Collections.Specialized ;

using NUnit.Framework ;

using org.ognl.test.objects ;
using org.ognl.test.util ;
//--------------------------------------------------------------------------
//  Copyright (c) 2004, Drew Davidson and Luke Blanshard
//  All rights reserved.
//
//  Redistribution and use in source and binary forms, with or without
//  modification, are permitted provided that the following conditions are
//  met:
//
//  Redistributions of source code must retain the above copyright notice,
//  this list of conditions and the following disclaimer.
//  Redistributions in binary form must reproduce the above copyright
//  notice, this list of conditions and the following disclaimer in the
//  documentation and/or other materials provided with the distribution.
//  Neither the name of the Drew Davidson nor the names of its contributors
//  may be used to endorse or promote products derived from this software
//  without specific prior written permission.
//
//  THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
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
namespace org.ognl.test
{

	public class MapCreationTest : OgnlTestCase
	{
		private static Root             ROOT = new Root();
		private static IDictionary              fooBarMap1 = new Hashtable();
		private static IDictionary              fooBarMap2 = new Hashtable();
		private static IDictionary              fooBarMap3 = new Hashtable();
		private static IDictionary              fooBarMap4 = new ListDictionary();
		private static IDictionary              fooBarMap5 = new SortedList();

		static MapCreationTest ()
		{
			fooBarMap1.Add("foo", "bar");
			fooBarMap2.Add("foo", "bar");
			fooBarMap2.Add("bar", "baz");
			fooBarMap3.Add("foo", null);
			fooBarMap3.Add("bar", "baz");
			fooBarMap4.Add("foo", "bar");
			fooBarMap4.Add("bar", "baz");
			fooBarMap5.Add("foo", "bar");
			fooBarMap5.Add("bar", "baz");
		}

		private static object[][]       TESTS = {
													// Map creation
										new object [] { ROOT, "#{ \"foo\" : \"bar\" }",                                               fooBarMap1 },
										new object [] { ROOT, "#{ \"foo\" : \"bar\", \"bar\" : \"baz\"  }",                           fooBarMap2 },
										new object [] { ROOT, "#{ \"foo\", \"bar\" : \"baz\"  }",                                     fooBarMap3 },
										// TODO: Can't load type ListDictionary.
										/*new object [] { ROOT, "#@System.Collections.Specialized.ListDictionary@{ \"foo\" : \"bar\", \"bar\" : \"baz\"  }",  fooBarMap4 },*/
										new object [] { ROOT, "#@System.Collections.SortedList@{ \"foo\" : \"bar\", \"bar\" : \"baz\"  }",        fooBarMap5 },
		};

		/*===================================================================
			Public static methods
		  ===================================================================*/
		public override TestSuite suite()
		{
			TestSuite       result = new TestSuite();

			for (int i = 0; i < TESTS.Length; i++) 
			{
				if (TESTS[i].Length == 3) 
				{
					result.addTest(new MapCreationTest((string)TESTS[i][1], TESTS[i][0], (string)TESTS[i][1], TESTS[i][2]));
				} 
				else 
				{
					if (TESTS[i].Length == 4) 
					{
						result.addTest(new MapCreationTest((string)TESTS[i][1], TESTS[i][0], (string)TESTS[i][1], TESTS[i][2], TESTS[i][3]));
					} 
					else 
					{
						if (TESTS[i].Length == 5) 
						{
							result.addTest(new MapCreationTest((string)TESTS[i][1], TESTS[i][0], (string)TESTS[i][1], TESTS[i][2], TESTS[i][3], TESTS[i][4]));
						} 
						else 
						{
							throw new Exception("don't understand TEST format");
						}
					}
				}
			}
			return result;
		}

		/*===================================================================
			Constructors
		  ===================================================================*/
		public MapCreationTest()
		{
	    
		}

		public MapCreationTest(string name) :base(name)
		{
	    
		}

		public MapCreationTest(string name, object root, string expressionString, object expectedResult, object setValue, object expectedAfterSetResult)
			: base(name, root, expressionString, expectedResult, setValue, expectedAfterSetResult)
		{
        
		}

		public MapCreationTest(string name, object root, string expressionString, object expectedResult, object setValue)
			: base(name, root, expressionString, expectedResult, setValue)
		{
        
		}

		public MapCreationTest(string name, object root, string expressionString, object expectedResult)
			: base(name, root, expressionString, expectedResult)
		{
        
		}

		[Test]
		public void Test3 ()
		{
			suite () [3].runTest ();
		}
	}
}