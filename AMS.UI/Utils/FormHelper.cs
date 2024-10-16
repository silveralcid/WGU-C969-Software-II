using Org.BouncyCastle.Asn1.Crmf;
using System;
using System.Windows.Forms;

namespace AMS.UI.Utils
{
    internal static class FormHelper
    {
        public static void Open(Form currentForm, Form formToOpen)
        {
            currentForm.Hide();
            formToOpen.ShowDialog();
            currentForm.Close();
        }

        public static void ReOpenAfterClose(Form currentForm, Form formToOpen)
        {
            currentForm.Hide();
            formToOpen.ShowDialog();
            formToOpen.Close();

            currentForm.Show();
        }

        public static void ResetForm(Form form)
        {
            foreach (var control in form.Controls)
            {
                switch (control)
                {
                    case TextBox txt:
                        txt.Text = string.Empty;
                        break;
                    case DateTimePicker dtp:
                        dtp.Value = DateTime.Now;
                        break;
                    case ComboBox cmb:
                        cmb.SelectedItem = null;
                        break;
                    default:
                        break;
                }
            }
        }

        public static void HideErrorLabels(Form form)
        {
            foreach (var control in form.Controls)
            {
                switch (control)
                {
                    case Label lbl:
                        if (lbl.Name.EndsWith("Error"))
                        {
                            lbl.Visible = false;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
