using System.Collections ;
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

///
///Implementation of PropertyAccessor that provides "property" reference to
///"next" and "hasNext".
///@author Luke Blanshard (blanshlu@netscape.net)
///@author Drew Davidson (drew@ognl.org)
///
/* // TODO: Ignore Iterator
public class IteratorPropertyAccessor : ObjectPropertyAccessor , PropertyAccessor 
	// This is here to make javadoc show this class as an implementor
{
    public object getProperty( IDictionary context, object target, object name ) // throws OgnlException
    {
        object      result;
        Iterator    iterator = (Iterator)target;

        if ( name is string ) {
            if (name.Equals("next")) {
                result = iterator.next();
            } else {
                if (name.Equals("hasNext")) {
                    result = iterator.hasNext() ? Boolean.TRUE : Boolean.FALSE;
                } else {
                    result = base.getProperty( context, target, name );
                }
            }
        } else {
            result = base.getProperty(context, target, name);
        }
        return result;
    }

    public void setProperty( IDictionary context, object target, object name, object value ) // throws OgnlException
    {
        throw new IllegalArgumentException( "can't set property " + name + " on Iterator" );
    }
}*/
}
