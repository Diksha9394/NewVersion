using System.ComponentModel;

// Creating a custom type converter part 3: Types to string
// https://www.cyotek.com/blog/creating-a-custom-type-converter-part-3-types-to-string

// This work is licensed under the Creative Commons Attribution 4.0 International License.
// To view a copy of this license, visit http://creativecommons.org/licenses/by/4.0/.

// Found this example useful?
// https://www.paypal.me/cyotek

namespace Cyotek.Demo.CustomTypeConverter3
{
  internal sealed class UserClass : INotifyPropertyChanged
  {
    #region Private Fields

    private UserTuple _tupleA;

    private UserTuple _tupleB;

    #endregion Private Fields

    #region Public Events

    public event PropertyChangedEventHandler PropertyChanged;

    #endregion Public Events

    #region Public Properties

    public UserTuple TupleA
    {
      get { return _tupleA; }
      set
      {
        _tupleA = value;

        this.OnPropertyChanged(nameof(TupleA));
      }
    }

    public UserTuple TupleB
    {
      get { return _tupleB; }
      set
      {
        _tupleB = value;

        this.OnPropertyChanged(nameof(TupleB));
      }
    }

    #endregion Public Properties

    #region Private Methods

    private void OnPropertyChanged(string propertyName)
    {
      PropertyChangedEventHandler handler;

      handler = this.PropertyChanged;

      if (handler != null)
      {
        handler(this, new PropertyChangedEventArgs(propertyName));
      }
    }

    #endregion Private Methods
  }
}