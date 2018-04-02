using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Org.Json;
using System;

namespace App1
{
    [Activity(Label = "ResultadoAreaCilindroActivity")]
    public class ResultadoAreaCilindroActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ResultadoAreaCilindro);

            View ll = FindViewById<LinearLayout>(Resource.Id.linearLayout);
            TextView resultado = FindViewById<TextView>(Resource.Id.txtResultado);

          
            var myResult = Intent.GetStringExtra("result") ?? "Falha no carregamento de dados";

            var myCilindro = Intent.GetStringExtra("myCalculo") ?? "Falha no carregamento de dados";
            var myRadioGroup = Intent.GetStringExtra("myColor") ?? "Falha no carregamento de dados";
            var myPizza = Intent.GetStringExtra("myPizza") ?? "Falha no carregamento de dados";


            switch (myResult)
            {
                case "radioButton":
                    resultadoRadioGroup(myRadioGroup, ll);
                    break;

                case "calculo":
                    resultado.Text = myCilindro;
                    break;

                case "pizza":
                    resultadoPizza(myPizza);
                    break;

            }

        }

        private void resultadoRadioGroup(string c, View v)
        {
            TextView resultado = FindViewById<TextView>(Resource.Id.txtResultado);
            resultado.Text = c;

            v.SetBackgroundColor(Android.Graphics.Color.ParseColor(c));
        }

        private void resultadoPizza(string myPizza)
        {
            TextView tvIng = FindViewById<TextView>(Resource.Id.txtIngredientes);
            TextView tvMassa = FindViewById<TextView>(Resource.Id.txtMassa);
            TextView tvTamanho = FindViewById<TextView>(Resource.Id.txtTamanho);

            JSONObject parentObject = new JSONObject(myPizza); //json completo
            JSONArray ingredientesJson = parentObject.OptJSONArray("ingredientes");
            var listaIngredientes = "Ingredientes: ";

            for (int i = 0; i < ingredientesJson.Length(); i++)
            {
                listaIngredientes = listaIngredientes + ingredientesJson.GetString(i) + ",";
            }

            listaIngredientes = listaIngredientes.Remove(listaIngredientes.Length - 1); //remove última vírgula da lista de ingredientes

            tvIng.Text = listaIngredientes;
            tvMassa.Text = "Massa: " + parentObject.OptString("massa");
            tvTamanho.Text = "Tamanho" + parentObject.OptString("tamanho");
        }
    }
}