using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace IsEnabledIssue.Views
{
    public partial class IsEnabledIssuePage
    {
        public IsEnabledIssuePage()
        {
            InitializeComponent();
        }

        async void OnShouldEnableButtonsTextChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var label = sender as Label;

            if(e.PropertyName == nameof(Label.Text)
                && label != null 
                && !string.IsNullOrWhiteSpace(label.Text))
            {
                if(label.Text == "True")
                {
                    label.TextColor = Color.Green;
                }
                else
                {
                    label.TextColor = Color.Red;
                }
                await label.ScaleTo(2.0, 250);
                await label.ScaleTo(1.0, 250);
            }
        }
    }
}
