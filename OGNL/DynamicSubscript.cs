 //--------------------------------------------------------------------------
//	Copyright (c) 1998-2004, Drew Davidson and Luke Blanshard
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

namespace ognl
{
	/// <summary>
	///This class has predefined instances that stand for OGNL's special "dynamic subscripts"
	///for getting at the first, middle, or last elements of a list.  
	///</summary>
	///<remarks>In OGNL expressions,
	///these subscripts look like special kinds of array indexes: 
	///<list type="">
	///<item><term>[^]</term><description>means the first element</description></item>
	///<item><term>[$]</term><description>means the last</description></item>
	///<item><term>[|]</term><description>means the middle</description></item>
	///<item><term>[*]</term><description>means the whole list</description></item>
	///</list>
	///</remarks>
	///@author Luke Blanshard (blanshlu@netscape.net)
	///@author Drew Davidson (drew@ognl.org)
	///
	public class DynamicSubscript
	{
		/// <summary>
		/// First element: ^.
		/// </summary>
		public const int FIRST = 0 ;
		/// <summary>
		/// Middle element: |.
		/// </summary>
		public const int MID = 1 ;
		/// <summary>
		/// Last element: $.
		/// </summary>
		public const int LAST = 2 ;
		/// <summary>
		/// All Element: *.
		/// </summary>
		public const int ALL = 3 ;

		public static DynamicSubscript first = new DynamicSubscript (FIRST) ;
		public static DynamicSubscript mid = new DynamicSubscript (MID) ;
		public static DynamicSubscript last = new DynamicSubscript (LAST) ;
		public static DynamicSubscript all = new DynamicSubscript (ALL) ;

		int flag ;

		private DynamicSubscript (int flag)
		{
			this.flag = flag ;
		}

		/// <summary>
		/// Gets  dynamic subscript flag.
		/// </summary>
		/// <returns></returns>
		public int getFlag ()
		{
			return flag ;
		}

		public override string ToString ()
		{
			switch (flag)
			{
			case FIRST:
				return "^" ;
			case MID:
				return "|" ;
			case LAST:
				return "$" ;
			case ALL:
				return "*" ;
			default:
				return "?" ; // Won't happen
			}
		}
	}
}