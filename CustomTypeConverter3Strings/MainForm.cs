using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using Cyotek.Demo.TextBoxTabStops;

// Creating a custom type converter part 3: Types to string
// https://www.cyotek.com/blog/creating-a-custom-type-converter-part-3-types-to-string

// This work is licensed under the Creative Commons Attribution 4.0 International License.
// To view a copy of this license, visit http://creativecommons.org/licenses/by/4.0/.

// Found this example useful?
// https://www.paypal.me/cyotek

namespace Cyotek.Demo.CustomTypeConverter3
{
  public partial class MainForm : Form
  {
    #region Private Fields

    private UserClass _sample;

    #endregion Private Fields

    #region Public Constructors

    public MainForm()
    {
      this.InitializeComponent();
    }

    #endregion Public Constructors

    #region Protected Methods

    protected override void OnShown(EventArgs e)
    {
      base.OnShown(e);

      _sample = new UserClass();
      _sample.PropertyChanged += this.SamplePropertyChangedHandler;

      propertyGrid.SelectedObject = _sample;

      _sample.TupleA = new UserTuple(1, 2, 3, 4);
      _sample.TupleB = new UserTuple(5.6, 6.7, 7.8, 8.9);
    }

    #endregion Protected Methods

    #region Private Methods

    private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      AboutDialog.ShowAboutDialog();
    }

    private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void SamplePropertyChangedHandler(object sender, PropertyChangedEventArgs e)
    {
      eventsListBox.AddEvent(null, nameof(UserClass.PropertyChanged), e);
    }

    private void WebLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      try
      {
        Process.Start("https://www.cyotek.com");
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.GetBaseException().Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    #endregion Private Methods
  }
}