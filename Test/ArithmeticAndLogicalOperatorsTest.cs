using System ;

using NUnit.Framework ;

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

	
	public class ArithmeticAndLogicalOperatorsTest : OgnlTestCase
	{
		private static object[][]       TESTS = {
													// Double-valued arithmetic expressions
										new object [] { "-1d", (double)-1 },
										new object [] { "+1d", (double)(1) },
										new object [] { "--1f", (1f) },
										new object [] { "2*2.0", (double)(4) },
										new object [] { "5/2.", (double)(2.5) },
										new object [] { "5+2D", (double)(7) },
										new object [] { "5f-2F", (float)(3) },
										new object [] { "5.+2*3", (double)(11) },
										new object [] { "(5.+2)*3", (double)(21) },

													// BigDecimal-valued arithmetic expressions
										new object [] { "-1b", (decimal)(-1) },
										new object [] { "+1b", (decimal)(1) },
										new object [] { "--1b", (decimal)(1) },
										new object [] { "2*2.0b", (decimal)(4.0) },
										new object [] { "5/2.B", (decimal)(2.5) },
										new object [] { "5.0B/2", (decimal)(2.5) },
										new object [] { "5+2b", (decimal)(7) },
										new object [] { "5-2B", (decimal)(3) },
										new object [] { "5.+2b*3", (decimal)(11) },
										new object [] { "(5.+2b)*3", (decimal)(21) },

													// Integer-valued arithmetic expressions
										new object [] { "-1", (-1) },
										new object [] { "+1", (1) },
										new object [] { "--1", (1) },
										new object [] { "2*2", (int)(4) },
										new object [] { "5/2", (int)(2) },
										new object [] { "5+2", (int)(7) },
										new object [] { "5-2", (int)(3) },
										new object [] { "5+2*3", (int)(11) },
										new object [] { "(5+2)*3", (int)(21) },
										new object [] { "~1", (int)(~1) },
										new object [] { "5%2", (int)(1) },
										new object [] { "5<<2", (int)(20) },
										new object [] { "5>>2", (int)(1) },
										new object [] { "5>>1+1", (int)(1) },
										new object [] { "-5>>2", (int)(-5>>2) },
										new object [] { "-5L>>2", (long)(-5L>>2) },
										new object [] { "5. & 3", (double)(1) },
										new object [] { "5 ^3", (int)(6) },
										new object [] { "5l&3|5^3", (7L) },
										new object [] { "5&(3|5^3)", (int)(5) },

													// BigInteger-valued arithmetic expressions
													/*{ "-1h", BigInteger.valueOf(-1) },
													{ "+1H", BigInteger.valueOf(1) },
													{ "--1h", BigInteger.valueOf(1) },
													{ "2h*2", BigInteger.valueOf(4) },
													{ "5/2h", BigInteger.valueOf(2) },
													{ "5h+2", BigInteger.valueOf(7) },
													{ "5-2h", BigInteger.valueOf(3) },
													{ "5+2H*3", BigInteger.valueOf(11) },
													{ "(5+2H)*3", BigInteger.valueOf(21) },
													{ "~1h", BigInteger.valueOf(~1) },
													{ "5h%2", BigInteger.valueOf(1) },
													{ "5h<<2", BigInteger.valueOf(20) },
													{ "5h>>2", BigInteger.valueOf(1) },
													{ "5h>>1+1", BigInteger.valueOf(1) },
													{ "-5h>>>2", BigInteger.valueOf(-2) },
													{ "5.b & 3", BigInteger.valueOf(1) },
													{ "5h ^3", BigInteger.valueOf(6) },
													{ "5h&3|5^3", BigInteger.valueOf(7) },
													{ "5H&(3|5^3)", BigInteger.valueOf(5) },*/

													// Logical expressions
										new object [] { "!1", false },
										new object [] { "!null", true },
										new object [] { "5<2", false },
										new object [] { "5>2", true },
										new object [] { "5<=5", true },
										new object [] { "5>=3", true },
										// new object [] { "5<-5>>>2", true },
										new object [] { "5==5.0", true },
										new object [] { "5!=5.0", false },
										new object [] { "null in {true,false,null}", true },
										new object [] { "null not in {true,false,null}", false },
										new object [] { "null in {true,false,null}.ToArray()", true },
										new object [] { "5 in {true,false,null}", false },
										new object [] { "5 not in {true,false,null}", true },
										new object [] { "5 instanceof System.Int32", true },
										new object [] { "5. instanceof System.Int32", false },

													// Logical expressions (string versions)
										new object [] { "2 or 0", (int)(2) },
										new object [] { "1 and 0", (int)(0) },
										new object [] { "1 bor 0", (int)(1) },
										new object [] { "1 xor 0", (int)(1) },
										new object [] { "1 band 0", (int)(0) },
										new object [] { "1 eq 1", true },
										new object [] { "1 neq 1", false },
										new object [] { "1 lt 5", true },
										new object [] { "1 lte 5", true },
										new object [] { "1 gt 5", false },
										new object [] { "1 gte 5", false },
										new object [] { "1 lt 5", true },
										new object [] { "1 shl 2", (int)(4) },
										new object [] { "4 shr 2", (int)(1) },
										new object [] { "4 ushr 2", (int)(1) },
										new object [] { "not null", true },
										new object [] { "not 1", false },

										new object [] { "#x > 0", true },
										new object [] { "#x < 0", false },
										new object [] { "#x == 0", false },
										new object [] { "#x == 1", true },
										new object [] { "0 > #x", false },
										new object [] { "0 < #x", true },
										new object [] { "0 == #x", false },
										new object [] { "1 == #x", true },
										new object [] { "\"1\" > 0", true },
										new object [] { "\"1\" < 0", false },
										new object [] { "\"1\" == 0", false },
										new object [] { "\"1\" == 1", true },
										new object [] { "0 > \"1\"", false },
										new object [] { "0 < \"1\"", true },
										new object [] { "0 == \"1\"", false },
										new object [] { "1 == \"1\"", true },
										new object [] { "#x + 1", "11" },
										new object [] { "1 + #x", "11" },
										new object [] { "#y == 1", true },
										new object [] { "#y == \"1\"", true },
										new object [] { "#y + \"1\"", "11" },
										new object [] { "\"1\" + #y", "11" }
												};

		/*===================================================================
			Public static methods
		  ===================================================================*/
		public override TestSuite suite()
		{
			TestSuite       result = new TestSuite();

			for (int i = 0; i < TESTS.Length; i++) 
			{
				result.addTest(new ArithmeticAndLogicalOperatorsTest((string)TESTS[i][0] + " (" + TESTS[i][1] + ")", null, (string)TESTS[i][0], TESTS[i][1]));
			}
			return result;
		}

		/*===================================================================
			Constructors
		  ===================================================================*/
		public ArithmeticAndLogicalOperatorsTest()
		{
	    
		}

		public ArithmeticAndLogicalOperatorsTest(string name) : base(name)
		{
	    
		}

		public ArithmeticAndLogicalOperatorsTest(string name, object root, string expressionString, object expectedResult, object setValue, object expectedAfterSetResult)
			: base(name, root, expressionString, expectedResult, setValue, expectedAfterSetResult)
		{
        
		}

		public ArithmeticAndLogicalOperatorsTest(string name, object root, string expressionString, object expectedResult, object setValue)
			: base(name, root, expressionString, expectedResult, setValue)
		{
        
		}

		public ArithmeticAndLogicalOperatorsTest(string name, object root, string expressionString, object expectedResult)
			: base(name, root, expressionString, expectedResult)
		{
        
		}

		/*===================================================================
			Overridden methods
		  ===================================================================*/
		[TestFixtureSetUp]
		public override void setUp()
		{
			base.setUp();
			context.Add("x", "1");
			context.Add("y", (decimal)(1));
		}

		[Test]
		public void Test0 ()
		{
			suite () [0].runTest () ;
		}
		[Test]
		public void Test3 ()
		{
			suite () [3].runTest () ;
		}
		[Test]
		public void Test13 ()
		{
			suite () [13].runTest () ;
		}
		[Test]
		public void Test43 ()
		{
			suite () [43].runTest () ;
		}

		[Test]
		public void Test47 ()
		{
			suite () [47].runTest () ;
		}
	}
}
