using Android.App;
using Android.OS;
using Android.Widget;

namespace App1
{
    [Activity(Label = "App1")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var btnCalcAreaCilindro = FindViewById<Button>(Resource.Id.calcAreaCilindro);

            btnCalcAreaCilindro.Click += delegate
            {
                //    var activity2 = new Intent(this, typeof(CalculosActivity));
                //    StartActivity(activity2);

                StartActivity(typeof(CalculosActivity));
            };
        }

        private void Btn01_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}