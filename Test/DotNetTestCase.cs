using System;
using System.Reflection ;

using NUnit.Framework ;

using java ;

using org.ognl.test.objects ;

namespace org.ognl.test
{
	/// <summary>
	/// NumberTestCase 的摘要说明。
	/// </summary>
	[TestFixture]
	public class DotNetTestCase
	{
		[Test]
		public void testHexString ()
		{
			int i = 123 ;
			Console.WriteLine (i.ToString ("x4"));
			Console.Write (typeof (float));
		}
		[Test]
		public void TestLong ()
		{
			long l = 0x12aD ;
			string s = "12aD" ;
			Assert.AreEqual (l , Util.ParseLong (s , 16));

			l = 44 ;
			s = "54" ;
			Assert.AreEqual (l , Util.ParseLong (s , 8));

			l = -l ;
			s = "-54" ;
			Assert.AreEqual (l , Util.ParseLong (s , 8));
		}

		[Test]
		public void TestConvert ()
		{
			/*
			Assert.IsTrue (Convert.ToBoolean ("True"));
			Assert.IsFalse (Convert.ToBoolean ("False"));
			Assert.IsFalse (Convert.ToBoolean ("aaaa"));
			*/
			Assert.IsTrue (Convert.ToBoolean (1));
			Assert.IsFalse (Convert.ToBoolean (0));

			Assert.IsTrue (Convert.ToBoolean (0.001));
			Assert.IsFalse (Convert.ToBoolean (0));
			
		}
		[Test]
		public void TestIndexer ()
		{
			Type type = typeof (Indexer) ;
			PropertyInfo[] ps = type.GetProperties () ;
			for (int i = 0; i < ps.Length; i++)
			{
				PropertyInfo p = ps [i] ;

				Console.Out.WriteLine ("p.MemberType = {0}", p.MemberType) ;
				Console.Out.WriteLine ("p.GetMethod = {0}", p.GetGetMethod ()) ;
				Console.Out.WriteLine ("p.SetMethod = {0}", p.GetSetMethod ()) ;
				Console.Out.WriteLine ("p.Name = {0}", p.Name) ;
				if (p.GetIndexParameters ().Length > 0)
				Console.Out.WriteLine ("p.Index = {0}", p.GetIndexParameters () [0].ParameterType) ;


			}
		}

		[Test]
		public void testULong ()
		{
			long l = unchecked ((long)0xf800000000000000L) ;
			ulong u1 = 0xf800000000000000L ;
			ulong u2 = (ulong) l ;
			Assert.AreEqual (u1 , u2);
			// No oct supported.
			// Assert.AreEqual (63 , 077);
			Assert.AreEqual (17 , 81 & 63);
			Assert.AreEqual (131072 , 1L << (17));
		}

		[Test]
		public void testLoadType ()
		{
			Type t = Type.GetType ("org.ognl.test.objects.Simple,Test") ;
			Assert.IsNotNull (t);

			// t = Type.GetType ("System.Collections.Specialized.ListDictionary,System") ;
			// Assert.IsNotNull (t);
		}

		[Test]
		public void testEnum ()
		{
			Assert.AreEqual (Enum.Parse (typeof (SomeEnum) , "Item1" , true) , SomeEnum.Item1);
			Assert.AreEqual (Enum.Parse (typeof (SomeEnum) , "item2" , true) , SomeEnum.Item2);
		}
	}
	public class Indexer
	{
		public object Item0
		{
			get {return new object() ;}
			set { ; }
		}
		public string this [int index]
		{
			get { return index.ToString () ; }
			set
			{
			}
		}
	}

	
}
