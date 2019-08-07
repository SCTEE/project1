using System;
using System.IO;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.Design.Widget;
using Android.Support.V7.App;

namespace FunMath
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = false)]
    public class Game2 : AppCompatActivity
    {
        String question, msg;
        double ans = 0.0;
        int rndans, point;
        bool vis = false;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Game2);
            Button nextgame = FindViewById<Button>(Resource.Id.game2nextgame);
            Button savebutton = FindViewById<Button>(Resource.Id.game2savebutton);
            TextView message = FindViewById<TextView>(Resource.Id.game2message);
            TextView pointtext = FindViewById<TextView>(Resource.Id.game2point1);
            String pointtxt = "You get " + point.ToString() + " points.";
            if (savedInstanceState != null)
            {
                rndans = savedInstanceState.GetInt("rndans", 0);
                point = savedInstanceState.GetInt("point", 0);
                ans = savedInstanceState.GetDouble("ans", 0);
                question = savedInstanceState.GetString("question");
                msg = savedInstanceState.GetString("msg");
                vis = savedInstanceState.GetBoolean("vis", false);
                TextView questiontext = FindViewById<TextView>(Resource.Id.game2Question1);
                questiontext.Text = question;
                pointtxt = "You get " + point.ToString() + " points.";
                pointtext.Text = pointtxt;
                message.Text = msg;
                Button ans1 = FindViewById<Button>(Resource.Id.game2answer1);
                Button ans2 = FindViewById<Button>(Resource.Id.game2answer2);
                Button ans3 = FindViewById<Button>(Resource.Id.game2answer3);
                Button ans4 = FindViewById<Button>(Resource.Id.game2answer4);

                if(vis == true)
                {
                    nextgame.Visibility = ViewStates.Visible;
                }

                ans1.Click += delegate { checkans(1, rndans); };
                ans2.Click += delegate { checkans(2, rndans); };
                ans3.Click += delegate { checkans(3, rndans); };
                ans4.Click += delegate { checkans(4, rndans); };
            }
            else
            {
                game();
            }

            
            //Button nextgame = FindViewById<Button>(Resource.Id.game2nextgame);
            //TextView message = FindViewById<TextView>(Resource.Id.game2message);
            nextgame.Click += delegate
            {
                nextgame.Visibility = ViewStates.Invisible;
                message.Text = "";
                vis = false;
                msg = "";
                point = point + 1;
                game();

            };

            savebutton.Click += delegate { savepoint();  };

            Button btn = FindViewById<Button>(Resource.Id.game2button5);
            btn.Click += delegate { StartActivity(typeof(SecondActivity)); };
            // Create your application here
        }

        public void savepoint()
        {
            //String filename = Path.Combine(App.FolderPath, "Point.txt");
            String filename = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "Point.txt");
            String pointtxt = "You get " + point.ToString() + " points.";
            //Console.WriteLine(filename);
            File.WriteAllText(filename, pointtxt);
            //File.WriteAllText("C:\\project\\FunMath\\FunMath\\Point.txt", pointtxt);
            //File.WriteAllText(filename, pointtxt);
            //filename = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Point.txt");
            //Console.WriteLine(filename);
            //File.WriteAllText(filename, pointtxt);
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            outState.PutInt("rndans", rndans);
            outState.PutInt("point", point);
            outState.PutDouble("ans", ans);
            outState.PutString("question", question);
            outState.PutString("msg", msg);
            outState.PutBoolean("vis", vis);
            base.OnSaveInstanceState(outState);
        }

        public void game()
        {
            Random question1 = new Random();
            Random question2 = new Random();
            Random number1 = new Random();
            Random number2 = new Random();
            Random number3 = new Random();
            Random randomans = new Random();
            TextView pointtext = FindViewById<TextView>(Resource.Id.game2point1);
            String pointtxt = "You get " + point.ToString() + " points.";
            pointtext.Text = pointtxt;
            int ques1 = question1.Next(2, 50);
            int ques2;
            do
            {
                ques2 = question2.Next(1, 50);
            } while (ques2 >= ques1);

            rndans = randomans.Next(1, 5);
            
            
            if (rndans == 1)
            {
                ans = ques1 + ques2;
            }
            if (rndans == 2)
            {
                ans = ques1 - ques2;
            }
            if (rndans == 3)
            {
                ans = ques1 * ques2;
            }
            if (rndans == 4)
            {
                double q1 = ques1;
                double q2 = ques2;
                ans = q1 / q2;
            }
            

            question = ques1.ToString() + " (?) " + ques2.ToString() + " = " + ans.ToString();

            TextView questiontext = FindViewById<TextView>(Resource.Id.game2Question1);
            questiontext.Text = question;

            Button ans1 = FindViewById<Button>(Resource.Id.game2answer1);
            Button ans2 = FindViewById<Button>(Resource.Id.game2answer2);
            Button ans3 = FindViewById<Button>(Resource.Id.game2answer3);
            Button ans4 = FindViewById<Button>(Resource.Id.game2answer4);

            ans1.Click += delegate { checkans(1, rndans); };
            ans2.Click += delegate { checkans(2, rndans); };
            ans3.Click += delegate { checkans(3, rndans); };
            ans4.Click += delegate { checkans(4, rndans); };
        }

        public void checkans(int ansno, int ans)
        {
            TextView message = FindViewById<TextView>(Resource.Id.game2message);
            if (ansno == ans)
            {
                message.Text = "Congratulation!";
                msg = "Congratulation!";
                Button nextgame = FindViewById<Button>(Resource.Id.game2nextgame);
                nextgame.Visibility = ViewStates.Visible;
                vis = true;
            }
            else
            {
                message.Text = "You guess the wrong answer.";
                msg = "You guess the wrong answer.";
                Button nextgame = FindViewById<Button>(Resource.Id.game2nextgame);
                nextgame.Visibility = ViewStates.Invisible;
                vis = false;
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View)sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }
    }
}