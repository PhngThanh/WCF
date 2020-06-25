using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS.Repository.ViewModels;

namespace POS.PrintManager.Invoice
{
    public partial class PaymentInvoicePanel : UserControl
    {
        public PaymentInvoicePanel()
        {
            InitializeComponent();
        }

        private string ReadNumbersToLetters(string number)
        {
            string[] unit = { "", "mươi", "trăm", "nghìn", "triệu", "tỉ" };//Don vi
            string[] basicNumber = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" }; // co so
            string numberLetter;

            int i, j, k, n, lengthNumber, found, smallNumber, isRound;

            lengthNumber = number.Length;
            number += "ss";
            numberLetter = "";
            found = 0;
            smallNumber = 0;
            isRound = 0;

            i = 0;
            while (i < lengthNumber)
            {
                //So chu so o hang dang duyet
                n = (lengthNumber - i + 2) % 3 + 1;

                //Kiem tra so 0
                found = 0;
                for (j = 0; j < n; j++)
                {
                    if (number[i + j] != '0')
                    {
                        found = 1;
                        break;
                    }
                }

                //Duyet n chu so
                if (found == 1)
                {
                    isRound = 1;
                    for (j = 0; j < n; j++)
                    {
                        smallNumber = 1;
                        switch (number[i + j])
                        {
                            case '0':
                                if (n - j == 3) numberLetter += basicNumber[0] + " ";
                                if (n - j == 2)
                                {
                                    if (number[i + j + 1] != '0') numberLetter += "lẻ ";
                                    smallNumber = 0;
                                }
                                break;
                            case '1':
                                if (n - j == 3) numberLetter += basicNumber[1] + " ";
                                if (n - j == 2)
                                {
                                    numberLetter += "mười ";
                                    smallNumber = 0;
                                }
                                if (n - j == 1)
                                {
                                    if (i + j == 0) k = 0;
                                    else k = i + j - 1;

                                    if (number[k] != '1' && number[k] != '0')
                                        numberLetter += "mốt ";
                                    else
                                        numberLetter += basicNumber[1] + " ";
                                }
                                break;
                            case '5':
                                if (i + j == lengthNumber - 1)
                                    numberLetter += "lăm ";
                                else
                                    numberLetter += basicNumber[5] + " ";
                                break;
                            default:
                                numberLetter += basicNumber[(int)number[i + j] - 48] + " ";
                                break;
                        }

                        //Doc don vi nho
                        if (smallNumber == 1)
                        {
                            numberLetter += unit[n - j - 1] + " ";
                        }
                    }
                }


                //Doc don vi lon
                if (lengthNumber - i - n > 0)
                {
                    if ((lengthNumber - i - n) % 9 == 0)
                    {
                        if (isRound == 1)
                            for (k = 0; k < (lengthNumber - i - n) / 9; k++)
                                numberLetter += "tỉ ";
                        isRound = 0;
                    }
                    else
                        if (found != 0) numberLetter += unit[((lengthNumber - i - n + 1) % 9) / 3 + 2] + " ";
                }

                i += n;
            }

            if (lengthNumber == 1)
                if (number[0] == '0' || number[0] == '5') return basicNumber[(int)number[0] - 48];
            numberLetter = numberLetter.Replace("  ", " ");
            return numberLetter;
        }

        public void LoadPayment(OrderEditViewModel order)
        {
            var total = order.TotalAmount;
            var vat = order.TotalAmount / 10;
            var final = total + vat;
            var finalInWord = ReadNumbersToLetters(final.ToString()) + "đồng";

            lblTotalAmountInput.Text = total.ToString("N0");
            lblVATRateInput.Text = "10 %";
            lblVATAmoutInput.Text = vat.ToString("N0");
            lblFinalAmountInput.Text = final.ToString("N0");

            lblAmountInWord.Text = "Số tiền viết bằng chữ (In word) : " + finalInWord.ToUpper();
        }
    }
}
