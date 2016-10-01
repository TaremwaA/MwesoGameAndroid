using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Java.Lang;

namespace MwesoGame
{
    [Activity(Label = "MwesoGame", MainLauncher = true, Icon = "@drawable/icon")]
    //Create our customized event args class
    public class OnPlayGameEventArgs : EventArgs
    {
        private string mUserNametxt;

        public string UserNametxt
        {
            get { return mUserNametxt; }
            set { mUserNametxt = value; }
        }

        public OnPlayGameEventArgs(string username):base() //call the base method of our parent class
        {
            UserNametxt = username;
        }
    }
    public class MainActivity : Activity
    {

        private Button mBtnPlayGame;
        public EditText mUserName;
        public TextView mUserNameDisplay;
        public event EventHandler<OnPlayGameEventArgs> mOnSignUpComplete;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            //get a reference to the button that we created for playing the game
            mBtnPlayGame = FindViewById<Button>(Resource.Id.btnPlayGame);
            //get a reference to the text in the username edit text
            mUserName = FindViewById<EditText>(Resource.Id.txtUserName);

            mUserNameDisplay = FindViewById<TextView>(Resource.Id.welcometxt);
            //subscribe to an event
            mBtnPlayGame.Click += (object sender, EventArgs args) =>
              {
                  //pull up dialog
                  FragmentTransaction transaction = FragmentManager.BeginTransaction();//the fragment we have created
                  dialog_playGame playGameDialog = new dialog_playGame();
                  playGameDialog.Show(transaction, "dialog Fragment");

                  //User to enter name
                  mOnSignUpComplete.Invoke(this, new OnPlayGameEventArgs(mUserName.Text));

                  this.mOnSignUpComplete += MainActivity_mOnSignUpComplete;
              };
        }

        private void MainActivity_mOnSignUpComplete(object sender, OnPlayGameEventArgs e)
        {
            //create a thread
            Thread thread = new Thread(ActLikeARequest);
            thread.Start();
            string username = e.UserNametxt;
            mUserNameDisplay.Text = username;
        }

        private void ActLikeARequest()
        {
            Thread.Sleep(5000);
        }
    }
}

