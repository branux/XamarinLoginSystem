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

namespace XamarinLoginSystem
{
    public class OnSignUpEventArgs : EventArgs
    {
        private string mFullName;
        private string mEmail;
        private string mPassword;

        public string FullName { get { return mFullName; } set { mFullName = value; } }
        public string Email { get { return mEmail; } set { mEmail = value; } }
        public string Password { get { return mPassword; } set { mPassword = value; } }

        public OnSignUpEventArgs (string fullname, string email, string password) : base()
        {
            FullName = fullname;
            Email = email;
            Password = password;
        }
    }

    class dialog_SignUp : DialogFragment
    {
        private EditText mTxtFullName;
        private EditText mTxtEmail;
        private EditText mTxtPassword;
        private Button mBtnSignUp;

        public event EventHandler<OnSignUpEventArgs> mOnSignUpComplete;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.dialog_SignUp, container, false);

            mTxtFullName = view.FindViewById<EditText>(Resource.Id.edittxtFullName);
            mTxtEmail = view.FindViewById<EditText>(Resource.Id.edittextEMail);
            mTxtPassword = view.FindViewById<EditText>(Resource.Id.edittxtPassword);
            mBtnSignUp = view.FindViewById<Button>(Resource.Id.btnDialogEmail);

            mBtnSignUp.Click += MBtnSignUp_Click;

            return view;
        }

        private void MBtnSignUp_Click(object sender, EventArgs e)
        {
            //User has clicked the Sign up button
            mOnSignUpComplete.Invoke(this, new OnSignUpEventArgs(mTxtFullName.Text, mTxtEmail.Text, mTxtPassword.Text));
            this.Dismiss();
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);  //Sets the title bar to Invisible
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation; //set the animation
        }
    }
}