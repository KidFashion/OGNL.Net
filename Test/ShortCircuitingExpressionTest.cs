using System ;

using NUnit.Framework ;

using ognl ;

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


	public class ShortCircuitingExpressionTest : OgnlTestCase
	{
		private static object[][]       TESTS = {
										new object [] { "#root ? someProperty : 99", (99) },
										new object [] { "#root ? 99 : someProperty", typeof (OgnlException) },
										new object [] { "(#x=99)? #x.someProperty : #x", typeof (OgnlException)},
										new object [] { "#xyzzy.doubleValue()", typeof (NullReferenceException) },
										new object [] { "#xyzzy && #xyzzy.doubleValue()", null },
										new object [] { "(#x=99) && #x", (99) },
										new object [] { "#xyzzy || 101", (101) },
										new object [] { "99 || 101",(99) },
		};

		/*===================================================================
			Public static methods
		  ===================================================================*/
		public override TestSuite suite()
		{
			TestSuite       result = new TestSuite();

			for (int i = 0; i < TESTS.Length; i++) 
			{
				result.addTest(new ShortCircuitingExpressionTest((string)TESTS[i][0] + " (" + TESTS[i][1] + ")", null, (string)TESTS[i][0], TESTS[i][1]));
			}
			return result;
		}
		[Test]
		public void Test2 ()
		{
			suite () [2].runTest ();
		}

		/*===================================================================
			Constructors
		  ===================================================================*/
		public ShortCircuitingExpressionTest()
		{
	    
		}

		public ShortCircuitingExpressionTest(string name)
			: base(name)
		{
	    
		}

		public ShortCircuitingExpressionTest(string name, object root, string expressionString, object expectedResult, object setValue, object expectedAfterSetResult)
			: base(name, root, expressionString, expectedResult, setValue, expectedAfterSetResult)
		{
        
		}

		public ShortCircuitingExpressionTest(string name, object root, string expressionString, object expectedResult, object setValue)
			: base(name, root, expressionString, expectedResult, setValue)
		{
        
		}

		public ShortCircuitingExpressionTest(string name, object root, string expressionString, object expectedResult)
			: base(name, root, expressionString, expectedResult)
		{
        
		}
	}
}
