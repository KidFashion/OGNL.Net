using NUnit.Framework ;

using ognl ;

using org.ognl.test.util ;
//--------------------------------------------------------------------------
//	Copyright (c) 2004, Drew Davidson and Luke Blanshard
//  All rights reserved.
//
//	Redistribution and use in source and binary forms, with or without
//  modification, are permitted provided that the following conditions are
//  met:
//
//	Redistributions of source code must retain the above copyright notice,
//  this list of conditions and the following disclaimer.
//	Redistributions in binary form must reproduce the above copyright
//  notice, this list of conditions and the following disclaimer in the
//  documentation and/or other materials provided with the distribution.
//	Neither the name of the Drew Davidson nor the names of its contributors
//  may be used to endorse or promote products derived from this software
//  without specific prior written permission.
//
//	THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
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

	/**
	 * This is a test program for private access in OGNL.
	 * shows the failures and a summary.
	 */
	[TestFixture]
	public class PrivateMemberTest 
	{
		private string                  _privateProperty = "private value";
		protected OgnlContext           context;


		/*===================================================================
			Public static methods
		  ===================================================================*/
		public TestSuite suite()
		{
			// return new TestSuite(typeof (PrivateMemberTest));
			// TODO: Simple Test
			return null ;
		}

		/*===================================================================
			Constructors
		  ===================================================================*/
		public PrivateMemberTest(string name)
		{
	   
		}

		/*===================================================================
			Public methods
		  ===================================================================*/
		private string getPrivateProperty()
		{
			return _privateProperty;
		}

		private void setPrivateProperty(string value)
		{
			_privateProperty = value;
		}

		[Test]
		public void testPrivateAccessor() // throws OgnlException
		{
			NUnit.Framework.Assert.AreEqual(Ognl.getValue("privateProperty", context, this), getPrivateProperty());
		}
		[Test]
		public void testPrivateField() // throws OgnlException
		{
			NUnit.Framework.Assert.AreEqual(Ognl.getValue("_privateProperty", context, this), _privateProperty);
		}

		/*===================================================================
			Overridden methods
		  ===================================================================*/
		[TestFixtureSetUp]
		public void setUp()
		{
			context = (OgnlContext)Ognl.createDefaultContext(null);
			context.setMemberAccess(new DefaultMemberAccess(true));
		}
	}
}
