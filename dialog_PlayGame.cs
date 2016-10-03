using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MwesoGameAndroid2D
{
    class dialog_PlayGame:DialogFragment
    {
        public Button mBtnPlayAgainstPC;
        private Button mBtnPlayAgainstHuman;
        private TextView mUserNameDisplay;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
          base.OnCreateView(inflater, container, savedInstanceState);
            //create the view but dont attach it to the container
            var view = inflater.Inflate(Resource.Layout.dialog_PlayGame, container, false);

            mBtnPlayAgainstPC = view.FindViewById<Button>(Resource.Id.btnPlayAgainstPc);
            mBtnPlayAgainstHuman = view.FindViewById<Button>(Resource.Id.btnPlayAgainstHuman);
            mUserNameDisplay = view.FindViewById<TextView>(Resource.Id.txtDisplayName);

            //trying to display username on dialog
            /*
            MainActivity main = new MainActivity();
            string userName = main.mUserName.Text;
            mUserNameDisplay.Text = userName;
            */
           // mBtnPlayAgainstPC.Click += MBtnPlayAgainstPC_Click;
            return view;
        }

        //public void MBtnPlayAgainstPC_Click(object sender, EventArgs e)
        //{
        //    //user has clicked the play aginst Pc button
        //    this.Dismiss();
        //}

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);//sets the title bar to invisible
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;//sets the animation
        }
    }
}