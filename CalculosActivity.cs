using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System;

namespace App1
{
    [Activity(Label = "CalculosActivity")]
    public class CalculosActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.AreaCilindro);

            var altura = FindViewById<EditText>(Resource.Id.edTextAltura);
            var raio = FindViewById<EditText>(Resource.Id.edTextRaio);
            var btn01 = FindViewById<Button>(Resource.Id.btn01);

            btn01.Click += delegate
            {
                if (altura.Text == "" || raio.Text == "")
                {
                    AlertDialog.Builder alerta = new AlertDialog.Builder(this);
                    alerta.SetTitle("Alerta");
                    alerta.SetMessage("Campos não preenchidos!");
                    alerta.SetNeutralButton("OK", delegate
                    {
                        alerta.Dispose();
                    });

                    Dialog dialog = alerta.Create();
                    dialog.Show();
                }
                else
                {
                    var result = CalcularPintura(altura.Text, raio.Text); //Calcula e Recebe o resultado

                    var activity2 = new Intent(this, typeof(ResultadoAreaCilindroActivity));
                    activity2.PutExtra("result", "calculo");
                    activity2.PutExtra("myCalculo", result);
                    StartActivity(activity2);
                }
            };
        }

        public string CalcularPintura(string altura, string raio)
        {
            double capacidadeLata = 15;
            double h = Convert.ToInt32(altura);
            double r = Convert.ToInt32(raio);

            double pi1 = 3.14;

            double areaBase = pi1 * Math.Pow(r, 2);

            double comprimento = 2 * pi1 * r;

            double areaLateral = h * comprimento;

            double areaTotal = areaBase * areaLateral;

            double quant = Math.Round((areaLateral / capacidadeLata), 2); //quantidade real (fracionada) que será utilizada

            double quantInt = Math.Ceiling(quant); // quantidade de latas que deverão ser compradas de fato

            //valor calculado sobre a quantidade de latas necessárias e não somente sobre o que será utilizado
            //não é possível comprar "meia lata" por exemplo
            double custo = quantInt * 50;

            return "Serão necessárias " + quantInt + " (" + quant + ")  latas de tinta com um custo de " + custo + " reais.";
        }
    }
}