using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System;
using System.Collections.Generic;

namespace App1
{
    [Activity(Label = "PizzaActivity")]
    public class PizzaActivity : Activity
    {
        private CheckBox cbBacon;
        private CheckBox cbCebola;
        private CheckBox cbCheddar;
        private CheckBox cbFigoAbacaxi;
        private CheckBox cbGorgonzola;
        private CheckBox cbPeperoni;
        private CheckBox cbPresutoParma;
        private Spinner spMassa;
        private Spinner spTamanho;
        private Button btnFinalizar;
        private List<String> listaIngredientes = new List<String>();
        private String massaSel;
        private String tamanhoSel;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.PizzaLayout);

            //referenciando Layout
            cbBacon = FindViewById<CheckBox>(Resource.Id.checkIngBacon);
            cbCebola = FindViewById<CheckBox>(Resource.Id.checkIngCebola);
            cbCheddar = FindViewById<CheckBox>(Resource.Id.checkIngCheddar);
            cbFigoAbacaxi = FindViewById<CheckBox>(Resource.Id.checkIngFigo);
            cbGorgonzola = FindViewById<CheckBox>(Resource.Id.checkIngGorgonzola);
            cbPeperoni = FindViewById<CheckBox>(Resource.Id.checkIngPeperoni);
            cbPresutoParma = FindViewById<CheckBox>(Resource.Id.checkIngPresutoParma);
            spMassa = FindViewById<Spinner>(Resource.Id.spMassa);
            spTamanho = FindViewById<Spinner>(Resource.Id.spTamanho);
            btnFinalizar = FindViewById<Button>(Resource.Id.btnOk);

            cbBacon.Click += (o, e) => { carregaIngredientes(cbBacon); };
            cbCebola.Click += (o, e) => { carregaIngredientes(cbCebola); };
            cbCheddar.Click += (o, e) => { carregaIngredientes(cbCheddar); };
            cbFigoAbacaxi.Click += (o, e) => { carregaIngredientes(cbFigoAbacaxi); };
            cbGorgonzola.Click += (o, e) => { carregaIngredientes(cbGorgonzola); };
            cbPeperoni.Click += (o, e) => { carregaIngredientes(cbPeperoni); };
            cbPresutoParma.Click += (o, e) => { carregaIngredientes(cbPresutoParma); };

            spMassa.SetTag(Resource.String.tagPizza, "massa");
            spTamanho.SetTag(Resource.String.tagPizza, "tamanho");

            spMassa.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>
           (spinner_ItemSelected);
            spTamanho.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>
           (spinner_ItemSelected);

            //Populando spinner massa
            var adapterMassa = ArrayAdapter.CreateFromResource(this, Resource.Array.massa,
                                                               Android.Resource.Layout.SimpleSpinnerItem);
            adapterMassa.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spMassa.Adapter = adapterMassa;

            //Populando spinner tamanho
            var adapterTamanho = ArrayAdapter.CreateFromResource(this, Resource.Array.tamanho,
                                                               Android.Resource.Layout.SimpleSpinnerItem);
            adapterTamanho.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spTamanho.Adapter = adapterTamanho;

            //Envia dados para outra Activity
            btnFinalizar.Click += delegate
            {
                var activity2 = new Intent(this, typeof(ResultadoAreaCilindroActivity));
                activity2.PutExtra("result", "pizza");
                activity2.PutExtra("myPizza", geraJson());
                StartActivity(activity2);
            };
        }

        private void carregaIngredientes(CheckBox c)
        {
            String ingrediente = c.Text.ToString();
            if (c.Checked)
            {
                listaIngredientes.Add(ingrediente);
                Toast.MakeText(this, "Selecionado " + ingrediente, ToastLength.Short).Show();
            }
        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            String tag = spinner.GetTag(Resource.String.tagPizza).ToString();

            String toast = "";
            if (tag == "massa")
            {
                toast = string.Format("Massa {0} selecionada", spinner.GetItemAtPosition(e.Position));
                massaSel = string.Format("{0}",
                spinner.GetItemAtPosition(e.Position));
            }
            else
            {
                toast = string.Format("Tamanho {0}", spinner.GetItemAtPosition(e.Position));
                tamanhoSel = string.Format("{0}",
                spinner.GetItemAtPosition(e.Position));
            }

            if (!(e.Position == 0)) Toast.MakeText(this, toast, ToastLength.Long).Show();

            Console.Write(tag);
        }

        private String geraJson()
        {
            string json = "{'ingredientes':[";
            foreach (var item in listaIngredientes)
            {
                json += "'" + item + "',";
            }
            json = json.Remove(json.Length - 1); //remove última vírgula da lista de ingredientes
            json += "],";
            json += "'massa':'" + massaSel + "',";
            json += "'tamanho':'" + tamanhoSel + "'}";
            return json;
        }
    }
}