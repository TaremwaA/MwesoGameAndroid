using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Views.InputMethods;

namespace MwesoGameAndroid2D
{
    [Activity(Label = "MwesoGameAndroid2D", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        LinearLayout mLinearLayout;
        private Button mBtnPlayGame;
        public EditText mUserName;
        private Button mBtnOption;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Window.RequestFeature(WindowFeatures.NoTitle);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //Get a reference to the play button
            mBtnPlayGame = FindViewById<Button>(Resource.Id.btnPlayGame);
            mUserName = FindViewById<EditText>(Resource.Id.userNametxt);
            mLinearLayout = FindViewById<LinearLayout>(Resource.Id.MainView);
            mBtnOption = FindViewById<Button>(Resource.Id.btnOptions);
            mLinearLayout.Click += MLinearLayout_Click;
            mBtnOption.Click += MBtnOption_Click;

            mBtnPlayGame.Click += (object sender, EventArgs args) =>
            {
                //Pull Up dialog
                FragmentTransaction transaction = FragmentManager.BeginTransaction();//Pull up dialog from the activity
                dialog_PlayGame dialogPlayGame = new dialog_PlayGame(); //instantiate dialog play game object
                dialogPlayGame.Show(transaction, "dialog fragment");

            };



        }

        private void MBtnOption_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(GameBoardActivity));
        }

        private void MLinearLayout_Click(object sender, EventArgs e)
        {
            //Hide the keyboard when the sides are clicked on
            InputMethodManager inputManager = (InputMethodManager)this.GetSystemService(Activity.InputMethodService);
            inputManager.HideSoftInputFromWindow(this.CurrentFocus.WindowToken, HideSoftInputFlags.None);
        }
    }
}

