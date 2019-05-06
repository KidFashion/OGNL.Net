using System ;
using System.Collections ;

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

	public class PropertyNotFoundTest : OgnlTestCase
	{
		private static Blah       BLAH = new Blah();

		private static object[][]       TESTS = {
										new object [] { BLAH, "webwork.token.name", typeof (OgnlException), "W value", typeof (OgnlException) },
		};

		/*===================================================================
			Public static classes
		  ===================================================================*/
		public class Blah
		{
			string          x;
			string          y;

			public string getX() 
			{
				return x;
			}

			public void setX(string x) 
			{
				this.x = x;
			}

			public string getY() 
			{
				return y;
			}

			public void setY(string y) 
			{
				this.y = y;
			}
		}

		public class BlahPropertyAccessor : PropertyAccessor
		{
			public void setProperty(IDictionary context, object target, object name, object value) // throws OgnlException
			{
			}

			public object getProperty(IDictionary context, object target, object name) // throws OgnlException
			{
				if ("x".Equals(name) || "y".Equals(name)) 
				{
					return OgnlRuntime.getProperty((OgnlContext)context, target, name);
				}
				return null;
			}
		}
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
					result.addTest(new PropertyNotFoundTest((string)TESTS[i][1], TESTS[i][0], (string)TESTS[i][1], TESTS[i][2]));
				} 
				else 
				{
					if (TESTS[i].Length == 4) 
					{
						result.addTest(new PropertyNotFoundTest((string)TESTS[i][1], TESTS[i][0], (string)TESTS[i][1], TESTS[i][2], TESTS[i][3]));
					} 
					else 
					{
						if (TESTS[i].Length == 5) 
						{
							result.addTest(new PropertyNotFoundTest((string)TESTS[i][1], TESTS[i][0], (string)TESTS[i][1], TESTS[i][2], TESTS[i][3], TESTS[i][4]));
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
		public PropertyNotFoundTest()
		{
	    
		}

		public PropertyNotFoundTest(string name) : base(name)
		{
	    
		}

		public PropertyNotFoundTest(string name, object root, string expressionString, object expectedResult, object setValue, object expectedAfterSetResult)
			: base(name, root, expressionString, expectedResult, setValue, expectedAfterSetResult)
		{
        
		}

		public PropertyNotFoundTest(string name, object root, string expressionString, object expectedResult, object setValue)
			: base(name, root, expressionString, expectedResult, setValue)
		{
        
		}

		public PropertyNotFoundTest(string name, object root, string expressionString, object expectedResult)
			:base(name, root, expressionString, expectedResult)
		{
        
		}

		[TestFixtureSetUp]
		public override void setUp()
		{
			base.setUp();
			OgnlRuntime.setPropertyAccessor(typeof (Blah), new BlahPropertyAccessor());
		}
	}
}
