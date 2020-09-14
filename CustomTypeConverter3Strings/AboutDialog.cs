using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Cyotek.Demo.CustomTypeConverter3;

// Setting tab stops in a Windows Forms TextBox control
// https://www.cyotek.com/blog/setting-tab-stops-in-a-windows-forms-textbox-control

// This work is licensed under the Creative Commons Attribution 4.0 International License.
// To view a copy of this license, visit http://creativecommons.org/licenses/by/4.0/.

// Found this example useful?
// https://www.paypal.me/cyotek

namespace Cyotek.Demo.TextBoxTabStops
{
  internal partial class AboutDialog : Form
  {
    #region Public Constructors

    public AboutDialog()
    {
      this.InitializeComponent();
    }

    #endregion Public Constructors

    #region Public Methods

    public static DialogResult ShowAboutDialog()
    {
      using (AboutDialog dialog = new AboutDialog())
      {
        return dialog.ShowDialog();
      }
    }

    #endregion Public Methods

    #region Protected Methods

    protected override void OnFontChanged(EventArgs e)
    {
      base.OnFontChanged(e);

      nameLabel.Font = new Font(this.Font, FontStyle.Bold);
    }

    protected override void OnLoad(EventArgs e)
    {
      FileVersionInfo versionInfo;
      int x;

      if (!this.DesignMode)
      {
        this.Font = SystemFonts.DialogFont;
      }

      versionInfo = FileVersionInfo.GetVersionInfo(typeof(MainForm).Assembly.Location);
      nameLabel.Text = versionInfo.ProductName;
      versionLabel.Text = "Version " + versionInfo.ProductVersion;
      copyrightLabel.Text = versionInfo.LegalCopyright;

      iconPictureBox.Size = SystemInformation.IconSize;
      iconPictureBox.Image = Application.OpenForms.Cast<Form>().Single(f => f.GetType() == typeof(MainForm)).Icon.ToBitmap();

      x = iconPictureBox.Right + iconPictureBox.Margin.Right + nameLabel.Margin.Left;

      nameLabel.Left = x;
      copyrightLabel.Left = x;

      base.OnLoad(e);
    }

    #endregion Protected Methods

    #region Private Methods

    private void closeButton_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void webLinkLabel_LinkClicked(object sender, EventArgs e)
    {
      try
      {
        Process.Start("http://www.cyotek.com");
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.GetBaseException().Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    #endregion Private Methods
  }
}