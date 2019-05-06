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

	public class MemberAccessTest : OgnlTestCase
	{
		private static Simple           ROOT = new Simple();
		private static object[][]       TESTS = {
										// new object [] { "@Runtime@getRuntime()", typeof (OgnlException) },
										// new object [] { "@System.AppDomain@GetCurrentThreadId()", AppDomain.GetCurrentThreadId () },
										new object [] { "bigIntValue", typeof (OgnlException) },
										new object [] { "bigIntValue", typeof (OgnlException), (25), typeof (OgnlException) },
										new object [] { "getBigIntValue()", typeof (OgnlException) },
										new object [] { "StringValue", ROOT.getStringValue() },
		};

		/*===================================================================
			Public static methods
		  ===================================================================*/
		public override TestSuite suite()
		{
			TestSuite       result = new TestSuite();

			for (int i = 0; i < TESTS.Length; i++) 
			{
				result.addTest(new MemberAccessTest((string)TESTS[i][0] + " (" + TESTS[i][1] + ")", ROOT, (string)TESTS[i][0], TESTS[i][1]));
			}
			return result;
		}

		/*===================================================================
			Constructors
		  ===================================================================*/
		public MemberAccessTest()
		{
	   
		}

		public MemberAccessTest(string name) : base(name)
		{
	    
		}

		public MemberAccessTest(string name, object root, string expressionString, object expectedResult, object setValue, object expectedAfterSetResult)
			: base(name, root, expressionString, expectedResult, setValue, expectedAfterSetResult)
		{
        
		}

		public MemberAccessTest(string name, object root, string expressionString, object expectedResult, object setValue)
			: base(name, root, expressionString, expectedResult, setValue)
		{
        
		}

		public MemberAccessTest(string name, object root, string expressionString, object expectedResult)
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
			/* Should allow access at all to the Simple class except for the bigIntValue property */
			context.setMemberAccess(new InnerDefaultMemberAccess ());
		}
	}

	class InnerDefaultMemberAccess : DefaultMemberAccess
	{
		public InnerDefaultMemberAccess () : base (false) 
		{
		}
		public override bool isAccessible(IDictionary context, object target, MemberInfo member, string propertyName)
		{
			if (target == typeof (AppDomain)) 
			{
				return false;
			}
			if (target is Simple) 
			{
				if (propertyName != null) 
				{
					return !propertyName.Equals("bigIntValue") &&
						base.isAccessible(context, target, member, propertyName);
				} 
				else 
				{
					if (member is MethodInfo) 
					{
						return !member.Name.Equals("getBigIntValue") &&
							!member.Name.Equals("setBigIntValue") &&
							base.isAccessible(context, target, member, propertyName);
					}
				}
			}
			return base.isAccessible(context, target, member, propertyName);
		}
	}
}



