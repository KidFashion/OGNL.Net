using System ;
using System.Collections ;
using System.Reflection ;

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

	public class ArrayElementsTest : OgnlTestCase
	{
		private static string[]         STRING_ARRAY = new string[] { "hello", "world" };
		private static int[]            INT_ARRAY = new int[] { 10, 20 };
		private static Root             ROOT = new Root();

		private static object[][]       TESTS = new object[][]{
													// Array elements test
										new object [] { STRING_ARRAY,     "length",       (2) },
										new object [] { STRING_ARRAY,     "#root[1]",     "world" },
										new object [] { INT_ARRAY,        "#root[1]",     (20) },
										new object [] { INT_ARRAY,        "#root[1]",     (20), "50", (50) },
										new object [] { INT_ARRAY,        "#root[1]",     (50), new string[] { "50", "100" }, (50) },
										new object [] { ROOT,             "IntValue",     (0), new string[] { "50", "100" }, (50) },
										new object [] { ROOT,             "Array",        ROOT.getArray(), new string[] { "50", "100" }, new int[] { 50, 100 } },
		};

		/*===================================================================
			Private static methods
		  ===================================================================*/
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
					result.addTest(new ArrayElementsTest((string)TESTS[i][1], TESTS[i][0], (string)TESTS[i][1], TESTS[i][2]));
				} 
				else 
				{
					if (TESTS[i].Length == 4) 
					{
						result.addTest(new ArrayElementsTest((string)TESTS[i][1], TESTS[i][0], (string)TESTS[i][1], TESTS[i][2], TESTS[i][3]));
					} 
					else 
					{
						if (TESTS[i].Length == 5) 
						{
							result.addTest(new ArrayElementsTest((string)TESTS[i][1], TESTS[i][0], (string)TESTS[i][1], TESTS[i][2], TESTS[i][3], TESTS[i][4]));
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
		public ArrayElementsTest()
		{
	   
		}

		public ArrayElementsTest(string name) : base(name)
		{
	    
		}

		public ArrayElementsTest(string name, object root, string expressionString, object expectedResult, object setValue, object expectedAfterSetResult)
			: base(name, root, expressionString, expectedResult, setValue, expectedAfterSetResult)
		{
			;
		}

		public ArrayElementsTest(string name, object root, string expressionString, object expectedResult, object setValue)
			: base(name, root, expressionString, expectedResult, setValue)
		{
        
		}

		public ArrayElementsTest(string name, object root, string expressionString, object expectedResult)
			: base(name, root, expressionString, expectedResult)
		{
			;
		}

		/*===================================================================
			Overridden methods
		  ===================================================================*/
		[TestFixtureSetUp]
		public override void setUp()
		{
			TypeConverter       arrayConverter;

			base.setUp();
			arrayConverter = new ArrayDefaultTypeConverter ();
			context.setTypeConverter(arrayConverter);
		}

		

		class ArrayDefaultTypeConverter : DefaultTypeConverter
		{
			public override object convertValue(IDictionary context, object target, MemberInfo member, string propertyName, object value, Type toType)
			{
				if (value.GetType().IsArray) 
				{
					if (!toType.IsArray) 
					{
						value = ((Array) value).GetValue (0);
					}
				}
				return base.convertValue(context, target, member, propertyName, value, toType);
			}
		}
	}
}
