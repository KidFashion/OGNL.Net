using System ;

using java ;

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

	public class CollectionDirectPropertyTest : OgnlTestCase
	{
		private static Root             ROOT = new Root();

		private static object[][]       TESTS = {
													// Collection direct properties
										new object [] { Util.asList(new string[]{"hello", "world"}), "size", 2 },
										new object [] { Util.asList(new string[]{"hello", "world"}), "isEmpty", false },
										new object [] { Util.asList(new string[]{}), "isEmpty", true },
										new object [] { Util.asList(new string[]{"hello", "world"}), "iterator.next", "hello" },
										new object [] { Util.asList(new string[]{"hello", "world"}), "iterator.hasNext", true },
										new object [] { Util.asList(new string[]{"hello", "world"}), "#it = iterator, #it.next, #it.next, #it.hasNext", false },
										new object [] { Util.asList(new string[]{"hello", "world"}), "#it = iterator, #it.next, #it.next", "world" },
										new object [] { Util.asList(new string[]{"hello", "world"}), "size", 2 },
										new object [] { ROOT, "Map[\"test\"]", ROOT },
										new object [] { ROOT, "Map.size", ROOT.getMap().Count },
										new object [] { ROOT, "Map.keys", ROOT.getMap().Keys },
										new object [] { ROOT, "Map.values", ROOT.getMap().Values },
										new object [] { ROOT, "Map.keys.size", ROOT.getMap().Keys.Count },
										new object [] { ROOT, "Map[\"size\"]", ROOT.getMap() [("size")] },
										new object [] { ROOT, "Map.isEmpty", ROOT.getMap().Count == 0 },
										new object [] { ROOT, "Map[\"isEmpty\"]", null },
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
					result.addTest(new CollectionDirectPropertyTest((string)TESTS[i][1], TESTS[i][0], (string)TESTS[i][1], TESTS[i][2]));
				} 
				else 
				{
					if (TESTS[i].Length == 4) 
					{
						result.addTest(new CollectionDirectPropertyTest((string)TESTS[i][1], TESTS[i][0], (string)TESTS[i][1], TESTS[i][2], TESTS[i][3]));
					} 
					else 
					{
						if (TESTS[i].Length == 5) 
						{
							result.addTest(new CollectionDirectPropertyTest((string)TESTS[i][1], TESTS[i][0], (string)TESTS[i][1], TESTS[i][2], TESTS[i][3], TESTS[i][4]));
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

		[Test]
		public void Test5 ()
		{
			suite () [5].runTest ();
		}

		/*===================================================================
			Constructors
		  ===================================================================*/
		public CollectionDirectPropertyTest()
		{
	 
		}

		public CollectionDirectPropertyTest(string name) : base(name)
		{
			;
		}

		public CollectionDirectPropertyTest(string name, object root, string expressionString, object expectedResult, object setValue, object expectedAfterSetResult)
			: base(name, root, expressionString, expectedResult, setValue, expectedAfterSetResult)
		{
        
		}

		public CollectionDirectPropertyTest(string name, object root, string expressionString, object expectedResult, object setValue)
			: base(name, root, expressionString, expectedResult, setValue)
		{
        
		}

		public CollectionDirectPropertyTest(string name, object root, string expressionString, object expectedResult)
			: base(name, root, expressionString, expectedResult)
		{
        
		}
	}
}
