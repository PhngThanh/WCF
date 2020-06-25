using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Common
{
    class PosMessageDialog
    {
        public static void ShowMessage(string message)
        {
            using (var md = new MessageDialog(message, MainForm.ResManager.GetString("Sys_OK", MainForm.CultureInfo)))
            {
                md.ShowDialog();
            }
        }

        public static bool ConfirmMessage(string message, string okText, string cancelText)
        {
            using (var md = new MessageDialog(message, okText, cancelText))
            {
                var rs = md.ShowDialog();
                return rs == DialogResult.OK;
            }
        }

        public static bool ConfirmMessage(string message)
        {
            return ConfirmMessage(message, MainForm.ResManager.GetString("Sys_Yes",MainForm.CultureInfo), MainForm.ResManager.GetString("Sys_No", MainForm.CultureInfo));
        }

        public static bool? YesNoCancelDialog(string message, string yesText, string noText, string cancelText)
        {
            using (var md = new MessageDialog(message, yesText, noText, cancelText))
            {
                var rs = md.ShowDialog();
                if (rs == DialogResult.OK)
                    return true;
                else if (rs == DialogResult.No)
                    return null;
                else
                    return false;
            }
        }

        public static List<string> YesNoCancelDialogWithInput(string message, string yesText, string noText, string cancelText, bool isEnableOnscreenKeyboard, string inputString)
        {
            using (var md = new MessageDialogWithInput(message, yesText, noText, cancelText, isEnableOnscreenKeyboard, inputString ))
            {
                var rs = md.ShowDialog();
                if (rs == DialogResult.OK)
                    return new List<string>() { md.Input, MainForm.ResManager.GetString("Sys_OK",MainForm.CultureInfo) }; 
                else if (rs == DialogResult.No)
                    return new List<string>() { md.Input, MainForm.ResManager.GetString("Sys_No",MainForm.CultureInfo) };
                else
                    return null;
            }
        }

        public static List<string> YesNoDialogWithInput(string message, string yesText, string cancelText, bool isEnableOnscreenKeyboard, string inputString)
        {
            using (var md = new MessageDialogWithInput(message, yesText, cancelText, isEnableOnscreenKeyboard, inputString))
            {
                var rs = md.ShowDialog();
                if (rs == DialogResult.OK)
                    return new List<string>() { md.Input, MainForm.ResManager.GetString("Sys_OK", MainForm.CultureInfo) };
                else
                    return null;
            }
        }

        public static string ConfirmMessageWithInput(string message, string oktext, string canceltext, bool isEnableOnscreenKeyboard, char passwordChar)
        {
            using (var md = new MessageDialogWithInput(message, oktext, canceltext, isEnableOnscreenKeyboard, passwordChar))
            {
                var rs = md.ShowDialog();
                if (rs == DialogResult.OK)
                {
                    return md.Input;
                }
                return null;
            }
        }

        public static List<string> ConfirmMessageWith2Input(string message, string title1, string title2, string okText,
            string cancelText, bool isEnableOnscreenKeyboard)
        {
            using (var md = new MessageDialogWith2Input(message, title1, title2, okText, cancelText, isEnableOnscreenKeyboard))
            {
                var rs = md.ShowDialog();
                if (rs == DialogResult.OK)
                {
                    return md.Input;
                }
                return null;
            }
        }


    }
}
