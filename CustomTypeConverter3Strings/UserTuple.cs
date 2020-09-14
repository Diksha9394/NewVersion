using System;
using System.ComponentModel;

// Creating a custom type converter part 3: Types to string
// https://www.cyotek.com/blog/creating-a-custom-type-converter-part-3-types-to-string

// This work is licensed under the Creative Commons Attribution 4.0 International License.
// To view a copy of this license, visit http://creativecommons.org/licenses/by/4.0/.

// Found this example useful?
// https://www.paypal.me/cyotek

namespace Cyotek.Demo.CustomTypeConverter3
{
  [TypeConverter(typeof(UserTupleConverter))]
  internal struct UserTuple
  {
    #region Private Fields

    private readonly double _w;

    private readonly double _x;

    private readonly double _y;

    private readonly double _z;

    #endregion Private Fields

    #region Public Constructors

    public UserTuple(double x, double y, double z, double w)
    {
      _x = x;
      _y = y;
      _z = z;
      _w = w;
    }

    #endregion Public Constructors

    #region Public Properties

    public double W
    {
      get { return _w; }
    }

    public double X
    {
      get { return _x; }
    }

    public double Y
    {
      get { return _y; }
    }

    public double Z
    {
      get { return _z; }
    }

    #endregion Public Properties

    #region Public Methods

    public static UserTuple Parse(string s)
    {
      string[] parts;
      double x;
      double y;
      double z;
      double w;

      if (string.IsNullOrEmpty(s))
      {
        throw new ArgumentNullException(s);
      }

      parts = s.Split(',');

      if (parts.Length != 4)
      {
        throw new ArgumentException("Value is not a tuple.", nameof(s));
      }

      x = double.Parse(parts[0]);
      y = double.Parse(parts[1]);
      z = double.Parse(parts[2]);
      w = double.Parse(parts[3]);

      return new UserTuple(x, y, z, w);
    }

    public static bool TryParse(string s, out UserTuple result)
    {
      bool success;

      try
      {
        result = UserTuple.Parse(s);
        success = true;
      }
      catch
      {
        success = false;
        result = default;
      }

      return success;
    }

    public override string ToString()
    {
      return "{X=" + _x + ",Y=" + _y + ",Z=" + _z + ",W=" + _w + "}";
    }

    #endregion Public Methods
  }
}