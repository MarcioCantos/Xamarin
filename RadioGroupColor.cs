using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System;

namespace App1
{
    [Activity(Label = "RadioGroupColor")]
    public class RadioGroupColor : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.RadioGroupColorLayout);

            RadioButton rbRed = FindViewById<RadioButton>(Resource.Id.rbVermelho);
            RadioButton rbAzul = FindViewById<RadioButton>(Resource.Id.rbAzul);

            rbRed.Click += RadioButtonClick;
            rbAzul.Click += RadioButtonClick;
        }

        private void RadioButtonClick(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            Toast.MakeText(this, rb.Text, ToastLength.Short).Show();

            var activity2 = new Intent(this, typeof(ResultadoAreaCilindroActivity));
            activity2.PutExtra("result", "radioButton");
            activity2.PutExtra("myColor", rb.Text);            
            StartActivity(activity2);
        }
    }
}