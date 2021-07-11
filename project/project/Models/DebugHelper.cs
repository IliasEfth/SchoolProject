using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace project.Models
{
    public class DebugHelper : BindableObject
    {
        private static bool debugging;
        public double OpacityDebugging
        {
            get => debugging ? 1 : 0;
            set
            {
                OnPropertyChanged("OpacityDebugging");
            }
        }

        static DebugHelper()
        {
            debugging = false;  //set to 'true' for 'behind the scenes'
        }
    }
}
