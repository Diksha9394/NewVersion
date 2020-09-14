using System;
using System.ComponentModel;
using System.Globalization;

// Creating a custom type converter part 3: Types to string
// https://www.cyotek.com/blog/creating-a-custom-type-converter-part-3-types-to-string

// This work is licensed under the Creative Commons Attribution 4.0 International License.
// To view a copy of this license, visit http://creativecommons.org/licenses/by/4.0/.

// Found this example useful?
// https://www.paypal.me/cyotek

namespace Cyotek.Demo.CustomTypeConverter3
{
  internal class UserTupleConverter : TypeConverter
  {
    #region Public Methods

    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
    {
      return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
    }

    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
    {
      return destinationType == typeof(string) || base.CanConvertTo(context, destinationType);
    }

    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
      object result;

      if (value is string s && !string.IsNullOrEmpty(s))
      {
        result = UserTuple.Parse(s);
      }
      else
      {
        result = null;
      }

      return result ?? base.ConvertFrom(context, culture, value);
    }

    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
      object result;

      if (value is UserTuple tuple && destinationType == typeof(string))
      {
        result = string.Format("{0}, {1}, {2}, {3}", tuple.X, tuple.Y, tuple.Z, tuple.W);
      }
      else
      {
        result = base.ConvertTo(context, culture, value, destinationType);
      }

      return result;
    }

    #endregion Public Methods
  }
}