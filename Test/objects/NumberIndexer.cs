using System;
using System.Collections ;

namespace org.ognl.test.objects
{
	/// <summary>
	/// NumberIndexer 的摘要说明。
	/// </summary>
	public class NumberIndexer
	{
		private Hashtable map = new Hashtable() ;
		private NumberIndexer _index ;

		public NumberIndexer ()
		{
			// init map 
			map [0] = 0 ;
			map [1] = 1 ;
			map [2] = 2 ;
			map [3] = 3 ;
		}
		public string this [int index]
		{
			get { return index.ToString () ;}
			set { ; }
		}

		public object this [string index]
		{
			get
			{
				if ("index".Equals (index)) 
					return Index ;
				else
					return null ;
			}
		}
		public NumberIndexer Index
		{
			get
			{
				if (_index == null)
					_index = new NumberIndexer();

				return _index ;
			}
			set { _index = value ; }
		}

		public int this [int index1 , int index2]
		{
			get {return  (int) map [index1 + index2] ;} 
			set {map [index1 + index2] = value ; }
		}
	}
}
