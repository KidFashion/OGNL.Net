using java ;

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
	public class ConstantTest : OgnlTestCase
	{
		private static object[][]       TESTS = {
										new object [] { "12345", (12345) },
										new object [] { "0x100", (256) },
										new object [] { "0xfE", (254) },
										new object [] { "01000", (512) },
										new object [] { "1234L", (1234L) },
										new object [] { "12.34", (12.34) },
										new object [] { ".1234", (.12340000000000) },
										new object [] { "12.34f", (12.34f) },
										new object [] { "12.", (double)(12) },
										new object [] { "12e+1d", (double)(120) },
										new object [] { "'x'", ('x') },
										new object [] { "'\\n'", ('\n') },
										new object [] { "'\\u048c'", ('\u048c') },
										new object [] { "'\\47'", ('\x27') },
										new object [] { "'\\367'", ('\xF7') },
										new object [] { "'\\367", typeof (ExpressionSyntaxException) },
										new object [] { "'\\x'", typeof (ExpressionSyntaxException) },
										new object [] { "\"hello world\"", "hello world" },
										new object [] { "\"\\u00a0\\u0068ell\\'o\\\\\\n\\r\\f\\t\\b\\\"\\167orld\\\"\"", "\u00a0hell'o\\\n\r\f\t\b\"world\"" },
										new object [] { "\"hello world", typeof (ExpressionSyntaxException) },
										new object [] { "\"hello\\x world\"", typeof (ExpressionSyntaxException) },
										new object [] { "null", null },
										new object [] { "true", true },
										new object [] { "false", false },
										new object [] { "{ false, true, null, 0, 1. }", Util.asList(new object[] { false , true, null, (0), (1d) } ) },
										new object [] { "'HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\"'", "HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\"" },
		};

		/*===================================================================
			Public static methods
		  ===================================================================*/
		public override TestSuite suite()
		{
			TestSuite       result = new TestSuite();

			for (int i = 0; i < TESTS.Length; i++) 
			{
				result.addTest(new ConstantTest((string)TESTS[i][0] + " (" + TESTS[i][1] + ")", null, (string)TESTS[i][0], TESTS[i][1]));
			}
			return result;
		}

		[Test]
		public void Test24 ()
		{
			suite () [24].runTest ();
		}
		/*===================================================================
			Constructors
		  ===================================================================*/
		public ConstantTest()
		{
	   
		}

		public ConstantTest(string name) : base(name)
		{
	    
		}

		public ConstantTest(string name, object root, string expressionString, object expectedResult, object setValue, object expectedAfterSetResult)
			: base(name, root, expressionString, expectedResult, setValue, expectedAfterSetResult)
		{
        
		}

		public ConstantTest(string name, object root, string expressionString, object expectedResult, object setValue)
			: base(name, root, expressionString, expectedResult, setValue)
		{
        
		}

		public ConstantTest(string name, object root, string expressionString, object expectedResult)
			: base(name, root, expressionString, expectedResult)
		{
       
		}
	}
}
