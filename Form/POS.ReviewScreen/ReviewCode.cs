using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.ReviewScreen
{
    public partial class ReviewCode : Form
    {
        public ReviewCode()
        {
            InitializeComponent();
        }

        private async void StartButton_Click(object sender, EventArgs e)
        {
            ResultsTextBox.Text += "\n";
            try
            {
                int length = await ExampleMethodAsync();
                // Note that you could put "await ExampleMethodAsync()" in the next line where
                // "length" is, but due to when '+=' fetches the value of ResultsTextBox, you
                // would not see the global side effect of ExampleMethodAsync setting the text.
                ResultsTextBox.Text += String.Format("Length: {0}\n", length);
            }
            catch (Exception)
            {
                // Process the exception if one occurs.
            }
        }
        public async Task<int> ExampleMethodAsync()
        {

            var httpClient = new HttpClient();
            string data = (await httpClient.GetStringAsync("http://msdn.microsoft.com"));
            int exampleInt = data.Length;

            ResultsTextBox.Text += data;
            // After the following return statement, any method that's awaiting
            // ExampleMethodAsync (in this case, StartButton_Click) can get the 
            // integer result.
            return exampleInt;
        }
    }
}
