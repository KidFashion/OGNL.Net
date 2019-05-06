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
namespace org.ognl.test.objects
{

	public class Simple
	{
		private string          stringValue;
		private float           floatValue;
		private int             intValue;
		private bool         booleanValue;
		// private BigInteger      bigIntValue = BigInteger.valueOf(0);
		private decimal      bigDecValue = (decimal) 0.0;

		public Simple()
		{
        
		}

		public Simple(object[] values)
		{
        
		}

		public Simple(string stringValue, float floatValue, int intValue)
		{
        
			this.stringValue = stringValue;
			this.floatValue = floatValue;
			this.intValue = intValue;
		}

		public void setValues(string stringValue, float floatValue, int intValue)
		{
			this.stringValue = stringValue;
			this.floatValue = floatValue;
			this.intValue = intValue;
		}

		public string getStringValue()
		{
			return stringValue;
		}

		public void setStringValue(string value)
		{
			stringValue = value;
		}

		public float getFloatValue()
		{
			return floatValue;
		}

		public void setFloatValue(float value)
		{
			floatValue = value;
		}

		public int getIntValue()
		{
			return intValue;
		}

		public void setIntValue(int value)
		{
			intValue = value;
		}

		public bool getBooleanValue()
		{
			return booleanValue;
		}

		public void setBooleanValue(bool value)
		{
			booleanValue = value;
		}

		/*public BigInteger getBigIntValue()
		{
			return bigIntValue;
		}
	

		public void setBigIntValue(BigInteger value)
		{
			bigIntValue = value;
		}
		*/
		public decimal getBigDecValue()
		{
			return bigDecValue;
		}

		public void setBigDecValue(decimal value)
		{
			bigDecValue = value;
		}

		public override bool Equals(object other)
		{
			bool     result = false;

			if (other is Simple) 
			{
				Simple      os = (Simple)other;

				result = OgnlTestCase.isEqual(os.getStringValue(), getStringValue()) && (os.getIntValue() == getIntValue());
			}
			return result;
		}
	}
}
