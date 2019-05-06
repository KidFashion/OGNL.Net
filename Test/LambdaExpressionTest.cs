using java ;

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
	public class LambdaExpressionTest : OgnlTestCase
	{
		private static object[][]       TESTS = {
													// Lambda expressions
										new object [] { null, "#a=:[33](20).{0}.ToArray().Length", (33) },
										new object [] { null, "#fact=:[#this<=1? 1 : #fact(#this-1) * #this], #fact(30)", (1409286144) },
										new object [] { null, "#fact=:[#this<=1? 1 : #fact(#this-1) * #this], #fact(30L)", (-8764578968847253504L) },
										/* // No BigInteger in C#, Ignored
										new object [] { null, "#fact=:[#this<=1? 1 : #fact(#this-1) * #this], #fact(30h)", ("265252859812191058636308480000000") },*/
										new object [] { null, "#bump = :[ #this.{ #this + 1 } ], (#bump)({ 1, 2, 3 })", (Util.asList(new int[] { (2), (3), (4) })) },
										new object [] { null, "#call = :[ \"calling \" + [0] + \" on \" + [1] ], (#call)({ \"x\", \"y\" })", "calling x on y" },
		};

		/*===================================================================
			Public static methods
		  ===================================================================*/
		public override TestSuite suite()
		{
			TestSuite       result = new TestSuite();

			for (int i = 0; i < TESTS.Length; i++) 
			{
				result.addTest(new LambdaExpressionTest((string)TESTS[i][1], TESTS[i][0], (string)TESTS[i][1], TESTS[i][2]));
			}
			return result;
		}

		/*===================================================================
			Constructors
		  ===================================================================*/
		public LambdaExpressionTest()
		{
	    
		}

		public LambdaExpressionTest(string name)
			: base(name)
		{
	    
		}

		public LambdaExpressionTest(string name, object root, string expressionString, object expectedResult, object setValue, object expectedAfterSetResult)
			: base(name, root, expressionString, expectedResult, setValue, expectedAfterSetResult)
		{
        
		}

		public LambdaExpressionTest(string name, object root, string expressionString, object expectedResult, object setValue)
			: base(name, root, expressionString, expectedResult, setValue)
		{
        
		}

		public LambdaExpressionTest(string name, object root, string expressionString, object expectedResult)
			: base(name, root, expressionString, expectedResult)
		{
        
		}
	}
}
