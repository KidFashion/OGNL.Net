
using System ;

using NUnit.Framework ;

using ognl ;

using org.ognl.test.objects ;
using org.ognl.test.util ;

//--------------------------------------------------------------------------
//  Copyright (c) 2004, Drew Davidson and Luke Blanshard 
//	Copyright (c) 2005, Foxcoming
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

	public class IndexerTest : OgnlTestCase
	{
		private static NumberIndexer          INDEXED = new NumberIndexer();

		private static object[][]       TESTS = {
													// Indexed properties
													new object [] { INDEXED, "[0]", INDEXED [0] },                                 /* gets this [0] */
													new object [] { INDEXED, "[\"0\"]", null },                           /* return null */
													new object [] { INDEXED.Index , "[1]", INDEXED.Index[1] },                     /* 1 */
													new object [] { INDEXED, "Index[0]", "0" },                      /* 0 */
													new object [] { INDEXED, "[\"index\"][1]", "1" },                      /* 0 */
													new object [] { INDEXED, "Index[0, \"1\"]", 1 },                      /* convert */
													// this [index1 , index2] ;
													new object [] { INDEXED, "[0, 0]", 0 },                      /* map [0] */
													new object [] { INDEXED, "[0, 1]", 1 },                      /* map [1] */
													new object [] { INDEXED, "[0, 2]", 2 },                      /* map [2] */
													new object [] { INDEXED, "[1, 1]", 2 },                      /* map [2] */
													new object [] { INDEXED, "[2, 1]", 3 },                      /* map [3] */						
													new object [] { INDEXED, "[2, 1]", 3 , 5 , 5},                      /* map [3] */						
													new object [] { INDEXED, "[2, 1]", 5 , 10 , 10 },                      /* map [3] */						
													new object [] { INDEXED, "Index[0, 0]", 0 },                      /* map [0] */
													new object [] { INDEXED, "Index[0, 1]", 1 },                      /* map [1] */
													new object [] { INDEXED, "Index[0, 2]", 2 },                      /* map [2] */
													new object [] { INDEXED, "Index[1, 1]", 2 },                      /* map [2] */
													new object [] { INDEXED, "Index[2, 1]", 3 },                      /* map [3] */						
													new object [] { INDEXED, "Index[2, 1]", 3 , 5 , 5},                      /* map [3] */						
													new object [] { INDEXED, "Index[2, 1]", 5 , 10 , 10 },                      /* map [3] */						
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
					result.addTest(new IndexedPropertyTest((string)TESTS[i][1], TESTS[i][0], (string)TESTS[i][1], TESTS[i][2]));
				} 
				else 
				{
					if (TESTS[i].Length == 4) 
					{
						result.addTest(new IndexedPropertyTest((string)TESTS[i][1], TESTS[i][0], (string)TESTS[i][1], TESTS[i][2], TESTS[i][3]));
					} 
					else 
					{
						if (TESTS[i].Length == 5) 
						{
							result.addTest(new IndexedPropertyTest((string)TESTS[i][1], TESTS[i][0], (string)TESTS[i][1], TESTS[i][2], TESTS[i][3], TESTS[i][4]));
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

		/*[Test]
		public void Test11 ()
		{
			suite () [11].runTest ();
		}*/
		/*===================================================================
			Constructors
		  ===================================================================*/
		public IndexerTest()
		{
	   
		}

		public IndexerTest(string name) : base(name)
		{
	    
		}

		public IndexerTest(string name, object root, string expressionString, object expectedResult, object setValue, object expectedAfterSetResult)
			: base(name, root, expressionString, expectedResult, setValue, expectedAfterSetResult)
		{
        
		}

		public IndexerTest(string name, object root, string expressionString, object expectedResult, object setValue)
			: base(name, root, expressionString, expectedResult, setValue)
		{
        
		}

		public IndexerTest(string name, object root, string expressionString, object expectedResult)
			: base(name, root, expressionString, expectedResult)
		{
        
		}
	}
}
