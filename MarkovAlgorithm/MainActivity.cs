using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;


namespace MarkovAlgorithm
{
    [Activity(Label = "MarkovAlgorithm", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 0;
        string[,] rule = new string[100, 2];
        string tmp;
        int i=0;
        int k=0;


        public string replace (string original, string substring, string changing)
        {
            int i = original.IndexOf(substring);
            return original.Remove(i, substring.Length).Insert(i, changing);
        }

        static string Delete(String str, String substr)
        {
            
            
            int n = str.IndexOf("_");
            str.Remove(n, substr.Length);
            return str;
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
           
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);


            string originalString = "TEST";
            var RESULT = FindViewById<EditText>(Resource.Id.RESULT);
            // Get our button from the layout resource,
            // and attach an event to it
            Button nextRule = FindViewById<Button>(Resource.Id.nextRule);
            Button ansver = FindViewById<Button>(Resource.Id.ansver);
            Button ACCEPT = FindViewById<Button>(Resource.Id.ACCEPT);

            ACCEPT.Click += delegate
            {
                originalString = FindViewById<EditText>(Resource.Id.original).Text; ;
            };

            nextRule.Click += delegate
            {                
                rule[count, 0] = FindViewById<EditText>(Resource.Id.rule1).Text;
                if (rule[count, 0] == "_") { rule[count, 0] = ""; };
                rule[count, 1] = FindViewById<EditText>(Resource.Id.rule2).Text;
                if (rule[count, 0] == "._") { rule[count, 0] = "."; };
                count = count + 1;
                RESULT.Text = originalString+rule[0,0] + rule [0,1];
            };

            ansver.Click += delegate {
                k = 1;

             

                if (k==1)
                {
                    while (true)
                    {


                        if (originalString.IndexOf(rule[i, 0]) >= 0)
                        {
                            originalString = replace(originalString, rule[i, 0], rule[i, 1]);
                            i = 0;
                            if (originalString.IndexOf("._") >= 0)
                            {
                                Delete(originalString, "._");
                                break; 
                            }

                            if (originalString.IndexOf("_") >= 0)
                            {
                                Delete(originalString, "_");
                            }

                            if (rule[i, 1].IndexOf(".") == 1) break;
                        }

                        else
                        {
                            
                            i++;
                            
                        }
                    };
                    
                    RESULT.Text = originalString;
                }





            };
        }
    }
}

