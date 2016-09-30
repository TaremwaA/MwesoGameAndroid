using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace MwesoGame
{
    [Activity(Label = "MwesoGame", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        private Button mBtnPlayGame;
        public EditText mUserName;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //get a reference to the button that we created for playing the game
            mBtnPlayGame = FindViewById<Button>(Resource.Id.btnPlayGame);
            //get a reference to the text in the username edit text
            mUserName = FindViewById<EditText>(Resource.Id.txtUserName);
            //subscribe to an event
            mBtnPlayGame.Click += (object sender, EventArgs args) =>
              {
                  //pull up dialog
                  FragmentTransaction transaction = FragmentManager.BeginTransaction();//the fragment we have created
                  dialog_playGame playGameDialog = new dialog_playGame();
                  playGameDialog.Show(transaction, "dialog Fragment");
              };
        }
    }
}

