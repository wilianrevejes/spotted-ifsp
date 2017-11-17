using System;
using Android.App;
using Android.OS;
using Android.Widget;
using Android.Support.V7.App;
using Android.Views;
using System.Collections.Generic;
using Android.Content;

namespace Spotted {
    [Activity(Label = "Cadastrar Usuário", MainLauncher=true)]
    public class CadastroActivity : AppCompatActivity {
        TextView nome;
        TextView login;
        TextView senha;
        Spinner instituicaoEnsino;
        TextView dataNascimentoDisplay;
        ImageButton dateSelect;
        Button btnCadastrar;

        private IList<SelectItem> instituicaoEnsinoList;

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Cadastro);

            // toolbar
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.cadastro_bar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetTitle(Resource.String.cadastro_toolbar_title);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            // DatePicker
            dataNascimentoDisplay = FindViewById<TextView>(Resource.Id.data_nascimento);
            dateSelect = FindViewById<ImageButton>(Resource.Id.btn_data_nascimento);
            dateSelect.Click += handleDateSelectClick;

            // getFields
            nome = FindViewById<TextView>(Resource.Id.nome);
            login = FindViewById<TextView>(Resource.Id.login);
            senha = FindViewById<TextView>(Resource.Id.senha);
            instituicaoEnsino = FindViewById<Spinner>(Resource.Id.instituicao_ensino);
            btnCadastrar = FindViewById<Button>(Resource.Id.btnCadastrar);

            //btn click
            btnCadastrar.Click += handleBtnCadastrarClick;

            //spinner things
            InstituicaoEnsinoFactory ief = new InstituicaoEnsinoFactory();
            instituicaoEnsinoList = ief.toSelect();
            
            instituicaoEnsino.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(handleSelect);

            var adapter = new SpinnerAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, instituicaoEnsinoList);
            
            //adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            instituicaoEnsino.Adapter = adapter;
        }

        void handleDateSelectClick(object sender, EventArgs eventArgs) {
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
               dataNascimentoDisplay.Text = time.Day.ToString() + "/" + time.Month.ToString() + "/" + time.Year.ToString() ;
            });
            frag.Show(FragmentManager, DatePickerFragment.TAG);
        }

        public override bool OnOptionsItemSelected(IMenuItem item) {
            if(item.ItemId == Android.Resource.Id.Home) {
                exitCadastro();
            }

            return base.OnOptionsItemSelected(item);
        }

        private void exitCadastro() {
            if (this.nome.Text != "" || this.login.Text != "" || this.senha.Text != "") {
                //set alert for executing the task
                Android.App.AlertDialog.Builder alert = new Android.App.AlertDialog.Builder(this);
                alert.SetTitle("Voltar");
                alert.SetMessage("Se você voltar, perderá os dados do cadastro, tem certeza?");
                alert.SetPositiveButton("Sim", (senderAlert, args) => {
                    var NxtAct = new Intent(this, typeof(MainActivity));
                    StartActivity(NxtAct);
                });
                alert.SetNegativeButton("Não", (senderAlert, args) => {
                    return;
                });

                Dialog dialog = alert.Create();
                dialog.Show();
            }
            else {
                var NxtAct = new Intent(this, typeof(MainActivity));
                StartActivity(NxtAct);
            }
        }

        private void handleBtnCadastrarClick(object sender, EventArgs e) {
            //UserFactory uf = new UserFactory();
            Toast.MakeText(this, "Clicou", ToastLength.Short).Show();
            //uf.create(nome.Text, login.Text, senha.Text, instituicaoEnsino);


        }

        private void handleSelect(object sender, AdapterView.ItemSelectedEventArgs e) {
            Spinner spinner = (Spinner)sender;
        }
    }
}