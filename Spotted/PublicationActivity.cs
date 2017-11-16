using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using System;

namespace Spotted {
    [Activity(Label = "PublicationActivity")]
    public class PublicationActivity : AppCompatActivity {

        EditText publicationContent;

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Publication);

            // Initialize toolbar
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.publication_bar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetTitle(Resource.String.publication_toolbar_title);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            
            publicationContent = FindViewById<EditText>(Resource.Id.content);
        }

        public override bool OnCreateOptionsMenu(IMenu menu) {
            MenuInflater.Inflate(Resource.Menu.publication_toolbar_menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item) {
            switch (item.ItemId) {
                case Android.Resource.Id.Home:
                    exitPublication();
                    break;
                case Resource.Id.publicar:
                    Toast.MakeText(this, "Publicando...", ToastLength.Short).Show();
                    try {
                        PublicationFactory pf = new PublicationFactory();

                        string response = pf.create(publicationContent.Text);

                        Toast.MakeText(this, response, ToastLength.Short).Show();
                        Finish();
                    }
                    catch(Exception error) {
                        Console.Write(error.Message);
                        Toast.MakeText(this, error.Message, ToastLength.Long).Show();
                    }
                    break;
                default:
                    Toast.MakeText(this, "Default " + item.ItemId, ToastLength.Short).Show();
                    break;
            }
            
            return base.OnOptionsItemSelected(item);
        }

        private void exitPublication() {
            if (this.publicationContent.Text != "") {
                //set alert for executing the task
                Android.App.AlertDialog.Builder alert = new Android.App.AlertDialog.Builder(this);
                alert.SetTitle("Voltar");
                alert.SetMessage("Há alterações não salvas, deseja voltar?");
                alert.SetPositiveButton("Sim", (senderAlert, args) => {
                    Finish();
                });
                alert.SetNegativeButton("Não", (senderAlert, args) => {
                    return;
                });

                Dialog dialog = alert.Create();
                dialog.Show();
            }
            else {
                Finish();
            }
        }
    }
}