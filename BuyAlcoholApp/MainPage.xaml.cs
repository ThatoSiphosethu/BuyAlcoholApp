using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BuyAlcoholApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            myDatePicker.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        }
        private int LegalAge = 21;
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            var CurrentYear = DateTime.Now.Year;
            var DOB_Year = myDatePicker.Date.Year;

            var Age = CurrentYear - DOB_Year;
            var Wait = LegalAge - Age;

            if (Age < 21)
            {
                DisplayAlert("Message", $"You're {Age}, You are underage!!! {Wait}yrs to go", "Ok" );
            } 
            else if (Age > 21)
            {
                DisplayAlert("Message", $"You're {Age}, You are safe!!!", "Ok");
            }
           

        }

        void OnDateSelected(object sender, DateChangedEventArgs args)
        {
            Recalculate();
        }

        void OnSwitchToggled(object sender, ToggledEventArgs args)
        {
            Recalculate();
        }

        void Recalculate()
        {
            TimeSpan timeSpan = endDatePicker.Date - startDatePicker.Date +
                (includeSwitch.IsToggled ? TimeSpan.FromDays(1) : TimeSpan.Zero);

            resultLabel.Text = String.Format("{0} day{1} between dates",
                                             timeSpan.Days, timeSpan.Days == 1 ? "" : "s");
        }
    }
}
