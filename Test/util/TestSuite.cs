using System;
using System.Collections ;

using NUnit.Framework ;

namespace org.ognl.test.util
{
	/// <summary>
	/// TestSuite 的摘要说明。
	/// </summary>
	public class TestSuite
	{
		private ArrayList cases ;
		public void addTest (OgnlTestCase testCase)
		{
			if (cases == null)
				cases =new ArrayList();

			cases.Add (testCase) ;
		}

		public IEnumerator enumerate ()
		{
			if (cases == null)
				return null ;
			else
				return cases.GetEnumerator ();
		}

		public OgnlTestCase this [int index]
		{
			get
			{
				if (cases == null)
					return null ;
				else
					return (OgnlTestCase) cases [index] ;
			}
		}
	}

	public interface ITestSuiteProvider
	{
		TestSuite suite() ;
	}
}
