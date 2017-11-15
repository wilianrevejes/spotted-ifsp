using System;
using Android.App;
using Android.OS;
using Android.Widget;

namespace Spotted
{
    [Activity(Label = "Cadastrar Usuário", MainLauncher =true)]
    public class CadastroActivity : Activity
    {
        TextView dataNascimentoDisplay;
        ImageButton dateSelect;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Cadastro);

            dataNascimentoDisplay = FindViewById<TextView>(Resource.Id.data_nascimento);
            dateSelect = FindViewById<ImageButton>(Resource.Id.btn_data_nascimento);
            dateSelect.Click += handleDateSelectClick;

        }

        void handleDateSelectClick(object sender, EventArgs eventArgs) {
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
               dataNascimentoDisplay.Text = time.Day.ToString() + "/" + time.Month.ToString() + "/" + time.Year.ToString() ;
            });
            frag.Show(FragmentManager, DatePickerFragment.TAG);
        }
    }
}