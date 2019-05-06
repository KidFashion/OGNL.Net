using System ;
using System.Collections ;
using System.IO ;
using System.Text ;

using NUnit.Framework ;

using ognl ;

using org.ognl.test.util ;
//--------------------------------------------------------------------------
//  Copyright (c) 2004, Drew Davidson ,  Luke Blanshard and Foxcoming
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

	[TestFixture]
	public abstract class OgnlTestCase  : ITestSuiteProvider 
	{
		protected string name ;
		protected OgnlContext               context;
		private string                      expressionString;
		private SimpleNode                  expression;
		private object                      expectedResult;
		private object                      root;
		private bool                     hasSetValue;
		private object                      setValue;
		private bool                     hasExpectedAfterSetResult;
		private object                      expectedAfterSetResult;

		/*===================================================================
			Public static methods
		  ===================================================================*/
		/**
			Returns true if object1 is equal to object2 in either the
			sense that they are the same object or, if both are non-null
			if they are equal in the <CODE>equals()</CODE> sense.
		 */
		public static bool isEqual(object object1, object object2)
		{
			bool     result = false;

			if (object1 == object2) 
			{
				result = true;
			} 
			else 
			{
				if ((object1 != null) && object1.GetType().IsArray) 
				{
					if ((object2 != null) && object2.GetType ().IsArray && (object2.GetType() == object1.GetType())) 
					{
						result = (((Array)object1).GetLength (0) == ((Array)object2).GetLength (0));
						if (result) 
						{
							for (int i = 0, icount = ((Array)object1).GetLength (0); result && (i < icount); i++) 
							{
								result = isEqual(((Array)object1).GetValue (i), ((Array)object2).GetValue (i));
								if (! result)
									break ;
							}
						}
					}
				}
				else // support ICollection.
				if ((object1 != null) && typeof (ICollection).IsAssignableFrom (object1.GetType ()))
				{
					if ((object2 != null) && typeof (ICollection).IsAssignableFrom (object2.GetType ()) && 
						(object2.GetType() == object1.GetType()))
					{
						result = (object1 != null) && (object2 != null) && object1.Equals(object2);
						result = (((ICollection)object1).Count == ((ICollection)object2).Count);
						if (result) 
						{
							IEnumerator e1 = ((ICollection)object1).GetEnumerator (); 
							IEnumerator e2 = ((ICollection)object2).GetEnumerator (); 
						
							while (e1.MoveNext () && e2.MoveNext ())
							{
								result = isEqual (e1.Current, e2.Current) ;
								if (! result)
									break ;
							}
						}
					}
				}
				/*else // support IDictionary.
				if ((object1 != null) && typeof (IDictionary).IsAssignableFrom (object1.GetType ()))
				{
					if ((object2 != null) && typeof (IDictionary).IsAssignableFrom (object2.GetType ()) && 
						(object2.GetType() == object1.GetType()))
					{
						result = (object1 != null) && (object2 != null) && object1.Equals(object2);
						result = (((IDictionary)object1).Count == ((IDictionary)object2).Count);
						if (result) 
						{
							IEnumerator e1 = ((IDictionary)object1).Keys.GetEnumerator (); 
						
							while (e1.MoveNext ())
							{
								object key = e1.Current ;
								result = isEqual (((IDictionary)object1) [key] , 
									((IDictionary)object2) [key]) ;
								if (! result)
									break ;
							}
						}
					}
				}*/
				else 
				{
					result = (object1 != null) && (object2 != null) && object1.Equals(object2);
				}
			}
			return result;
		}

		/*===================================================================
			Constructors
		  ===================================================================*/
		public OgnlTestCase()
		{
	   
		}

		public OgnlTestCase(string name)
		{
			this.name = name ;
		}

		public OgnlTestCase(string name, object root, string expressionString, object expectedResult, object setValue, object expectedAfterSetResult)
			: this(name, root, expressionString, expectedResult, setValue)
		{
        
			this.hasExpectedAfterSetResult = true;
			this.expectedAfterSetResult = expectedAfterSetResult;
		}

		public OgnlTestCase(string name, object root, string expressionString, object expectedResult, object setValue)
			: this(name, root, expressionString, expectedResult)
		{
			;
			this.hasSetValue = true;
			this.setValue = setValue;
		}

		public OgnlTestCase(string name, object root, string expressionString, object expectedResult)
			: this(name)
		{
        
			this.root = root;
			this.expressionString = expressionString;
			this.expectedResult = expectedResult;
		}

		/*===================================================================
			Public methods
		  ===================================================================*/
		public string getExpressionDump(SimpleNode node)
		{
			StringWriter        writer = new StringWriter();

			node.dump(writer, "   ");
			return writer.ToString();
		}

		public string getExpressionString()
		{
			return expressionString;
		}

		public SimpleNode getExpression() // throws OgnlException
		{
			if (expression == null) 
			{
				expression = (SimpleNode)Ognl.parseExpression(expressionString);
			}
			return expression;
		}

		public object getExpectedResult()
		{
			return expectedResult;
		}

		/*===================================================================
			Overridden methods
		  ===================================================================*/
		protected internal virtual void runTest() // throws Exception
		{
			object          testedResult = null;
			
			setUp ();
			try 
			{
				SimpleNode  expr;

				testedResult = expectedResult;
				expr = getExpression();
				/*
				PrintWriter writer = new PrintWriter(System.err);
				System.err.println(expr.toString());
				expr.dump(writer, "");
				writer.flush();
				*/
				Assert.IsTrue(isEqual(Ognl.getValue(expr, context, root), expectedResult));
				if (hasSetValue) 
				{
					testedResult = hasExpectedAfterSetResult ? expectedAfterSetResult : setValue;
					Ognl.setValue(expr, context, root, setValue);
					Assert.IsTrue(isEqual(Ognl.getValue(expr, context, root), testedResult));
				}
			} 
			catch (Exception ex) 
			{
				if (testedResult is Type) 
				{
					Assert.IsTrue (((Type)testedResult).IsAssignableFrom(ex.GetType()));
				} 
				else 
				{
					Console.WriteLine (ex);
					throw ex;
				}
			}
		}

		[TestFixtureSetUp]
		public virtual void setUp()
		{
			context = (OgnlContext)Ognl.createDefaultContext(null);
		}

		public abstract TestSuite suite () ;

		[Test]
		public virtual void RunTestSuite ()
		{
			TestSuite s = suite ();
			IEnumerator e = s.enumerate () ;
			ArrayList errors = new ArrayList() ;

			int index = 0 ;
			while (e != null && e.MoveNext ())
			{
				OgnlTestCase test = (OgnlTestCase) e.Current ;

				test.setUp ();
				try
				{
					Console.Write ("Run TestCase " + index + " [  " + test.name + "  ] ...");
					test.runTest ();
					Console.WriteLine ("SUCCESS.");
				}
				catch (Exception ex)
				{
					errors.Add (new Error (test , ex , index)) ;
					// throw ex ;
					Console.WriteLine ("Falied!");
					Console.WriteLine (ex);
				}
				index ++ ;
			}
			if (errors.Count > 0)
			{
				// report error
				StringBuilder sb = new StringBuilder(1024*4) ;
				sb.Append ("Failed with following TestCase:") ;
				for (int i = 0; i < errors.Count; i++)
				{
					sb.Append ('\n') ;
					Error error = (Error) errors [i] ;
					sb.Append (error.index) ;
					sb.Append (" [  ") ;
					sb.Append(error.test.expression) ;
					sb.Append ("  ]") ;
					sb.Append (" With error: ") ;
					sb.Append (error.ex) ;
					
				}
				


				Assert.Fail ();
			}

		}
	}

	class Error
	{
		internal OgnlTestCase test ;
		internal Exception ex ;
		internal int index;

		public Error (OgnlTestCase test, Exception ex , int index)
		{
			this.test = test ;
			this.ex = ex ;
			this.index = index;
		}
	}
}
