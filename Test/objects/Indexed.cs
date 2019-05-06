//--------------------------------------------------------------------------
//	Copyright (c) 2004, Drew Davidson ,  Luke Blanshard and Foxcoming
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
namespace org.ognl.test.objects
{

	public class Indexed 
	{
		private string[]        values = new string[] { "foo", "bar", "baz" };

		public Indexed()
		{
    
		}

		public Indexed(string[] values)
		{
     
			this.values = values;
		}

		/* Indexed property "values" */
		public string[] getValues()
		{
			return values;
		}

		public void setValues(string[] value)
		{
			values = value;
		}

		/**
			This method returns the string from the array and appends "xxx" to
			distinguish the "get" method from the direct array access.
		 */
		public string getValues(int index)
		{
			return values[index] + "xxx";
		}

		public void setValues(int index, string value)
		{
			if (value.EndsWith("xxx")) 
			{
				values[index] = value.Substring(0, value.Length - 3);
			} 
			else 
			{
				values[index] = value;
			}
		}

		// Add a Item bean property.
		/*public string [] GetItem ()
		{
			return getValues () ;
		}*/
		public string this [int index]
		{
			get {return values[index] + "xxx"; }
			set 
			{
				if (value.EndsWith("xxx")) 
				 {
					 values[index] = value.Substring(0, value.Length - 3);
				 } 
				 else 
				 {
					 values[index] = value;
				 }
				}
		}

	}
}
