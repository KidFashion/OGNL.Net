using System ;

using NUnit.Framework ;

using ognl ;

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

	public class EnumTest : OgnlTestCase
	{
		private static EnumBean             ROOT = new EnumBean();

		private static object[][]       TESTS = {
													// indexed access of with navigation chain (should start back at root)
													new object [] { ROOT, "ItemValue", ROOT.ItemValue },
													new object [] { ROOT, "ItemValue == 0 ", true },
													// new object [] { ROOT, "ItemValue == '0' ", true },
													new object [] { ROOT, "ItemValue == \"0\" ", true },
													new object [] { ROOT, "ItemValue == 'Item1' ", true },
													new object [] { ROOT, "ItemValue == 'item1' ", true },
													new object [] { ROOT, "ItemValue", SomeEnum.Item1 },
													new object [] { ROOT, "ItemValue = 'Item2'", "Item2" },
													new object [] { ROOT, "ItemValue", SomeEnum.Item2 , "Item1" , SomeEnum.Item1},
													new object [] { ROOT, "ItemValue = 2", 2 },
													new object [] { ROOT, "ItemValue", SomeEnum.Item3 , "Item1" , SomeEnum.Item1},
													new object [] { ROOT, "ItemValue", SomeEnum.Item1 , "item2" , SomeEnum.Item2},
													new object [] { ROOT, "ItemValue", SomeEnum.Item2 , "2" , SomeEnum.Item3},
													
		};

		/*===================================================================
			Public static methods
		  ===================================================================*/
		public override TestSuite suite()
		{
			TestSuite       result = new TestSuite();

			for (int i = 0; i < TESTS.Length; i++) 
			{
				if (TESTS[i].Length == 2) 
				{
					result.addTest(new EnumTest(TESTS [i][0] + "(" + TESTS [i][1] + ")" , null , (string) TESTS [i][0] , TESTS [i][1]));
				} 
				else 
				{
					if (TESTS [i].Length == 3)
					{
						result.addTest(new EnumTest((string)TESTS[i][1], TESTS[i][0], (string)TESTS[i][1], TESTS[i][2]));
					}
					else
					if (TESTS[i].Length == 4) 
					{
						result.addTest(new EnumTest((string)TESTS[i][1], TESTS[i][0], (string)TESTS[i][1], TESTS[i][2], TESTS[i][3]));
					} 
					else 
					{
						if (TESTS[i].Length == 5) 
						{
							result.addTest(new EnumTest((string)TESTS[i][1], TESTS[i][0], (string)TESTS[i][1], TESTS[i][2], TESTS[i][3], TESTS[i][4]));
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
		public EnumTest()
		{
	    
		}

		public EnumTest(string name) : base(name)
		{
	    
		}

		public EnumTest(string name, object root, string expressionString, object expectedResult, object setValue, object expectedAfterSetResult)
			:base(name, root, expressionString, expectedResult, setValue, expectedAfterSetResult)
		{
        
		}

		public EnumTest(string name, object root, string expressionString, object expectedResult, object setValue)
			: base(name, root, expressionString, expectedResult, setValue)
		{
        
		}

		public EnumTest(string name, object root, string expressionString, object expectedResult)
			: base(name, root, expressionString, expectedResult)
		{
			
		}
	}
}
