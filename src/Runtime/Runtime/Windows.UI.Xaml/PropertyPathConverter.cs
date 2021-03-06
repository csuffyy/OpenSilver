﻿

/*===================================================================================
* 
*   Copyright (c) Userware/OpenSilver.net
*      
*   This file is part of the OpenSilver Runtime (https://opensilver.net), which is
*   licensed under the MIT license: https://opensource.org/licenses/MIT
*   
*   As stated in the MIT license, "the above copyright notice and this permission
*   notice shall be included in all copies or substantial portions of the Software."
*  
\*====================================================================================*/


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#if MIGRATION
namespace System.Windows
#else
namespace Windows.UI.Xaml
#endif
{
#if FOR_DESIGN_TIME
    /// <summary>
    /// Provides a type converter for System.Windows.PropertyPath objects.
    /// </summary>
    public sealed partial class PropertyPathConverter : TypeConverter
    {
        /// <summary>
        /// Returns whether this converter can convert an object of one type to the System.Windows.PropertyPath
        /// type.
        /// </summary>
        /// <param name="context">An System.ComponentModel.ITypeDescriptorContext that provides a format context.</param>
        /// <param name="sourceType">A System.Type that represents the type you want to convert from.</param>
        /// <returns>true if sourceType is type System.String; otherwise, false.</returns>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }

            return base.CanConvertFrom(context, sourceType);
        }
       
        /// <summary>
        /// Returns whether this converter can convert the object to the System.Windows.PropertyPath
        /// type.
        /// </summary>
        /// <param name="context">An System.ComponentModel.ITypeDescriptorContext that provides a format context.</param>
        /// <param name="destinationType">A System.Type that represents the type you want to convert to.</param>
        /// <returns>true if destinationType is type System.String; otherwise, false.</returns>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return false;
        }
        
        // Exceptions:
        //   System.ArgumentNullException:
        //     The source was provided as null.
        //
        //   System.ArgumentException:
        //     The source was not null, but was not of the expected System.String type.
        /// <summary>
        /// Converts the specified value to the System.Windows.PropertyPath type.
        /// </summary>
        /// <param name="context">An System.ComponentModel.ITypeDescriptorContext that provides a format context.</param>
        /// <param name="culture">The System.Globalization.CultureInfo to use as the current culture.</param>
        /// <param name="value">
        /// The object to convert to a System.Windows.PropertyPath. This is expected
        /// to be a string.
        /// </param>
        /// <returns>The converted System.Windows.PropertyPath.</returns>
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value == null)
                throw GetConvertFromException(value);

            if (value is string)
                return PropertyPath.INTERNAL_ConvertFromString((string)value);

            return base.ConvertFrom(context, culture, value);
        }
        
        // Exceptions:
        //   System.ArgumentNullException:
        //     The value was provided as null.
        //
        //   System.ArgumentException:
        //     The value was not null, but was not of the expected System.Windows.PropertyPath
        //     type.- or -The destinationType was not the System.String type.
        /// <summary>
        /// Converts the specified value object to the System.Windows.PropertyPath type.
        /// </summary>
        /// <param name="context">An System.ComponentModel.ITypeDescriptorContext that provides a format context.</param>
        /// <param name="culture">The System.Globalization.CultureInfo to use as the current culture.</param>
        /// <param name="value">The System.Windows.PropertyPath to convert.</param>
        /// <param name="destinationType">The destination type. This is expected to be the System.String type.</param>
        /// <returns>The converted destination System.String.</returns>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            throw new NotImplementedException();
        }
    }
#endif
}