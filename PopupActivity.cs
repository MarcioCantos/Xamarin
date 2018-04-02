using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System;

namespace App1
{
    [Activity(Label = "PopupActivity", MainLauncher = true)]
    public class PopupActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.PopupLayout);

            Button showMenu = FindViewById<Button>(Resource.Id.btnMenu);

            showMenu.Click += (s, arg) =>
            {
                PopupMenu menu = new PopupMenu(this, showMenu);
                menu.Inflate(Resource.Menu.menuPopup);

                menu.MenuItemClick += (s1, arg1) =>
                {
                   
                    switch (arg1.Item.ItemId)
                    {
                        case Resource.Id.btnMenuCilindro:
                            StartActivity(new Intent(this, typeof(CalculosActivity)));
                            break;

                        case Resource.Id.btnMenuRadioColor:
                            StartActivity(new Intent(this, typeof(RadioGroupColor)));
                            break;

                        case Resource.Id.btnMenuPizza:
                            StartActivity(new Intent(this, typeof(PizzaActivity)));
                            break;
                    }
                };

                menu.Show();
            };
        }

        private void Menu_MenuItemClick(object sender, PopupMenu.MenuItemClickEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}