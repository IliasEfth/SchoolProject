using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace project.ViewModels.FirstFloor
{
    public class FirstFloor : BindableObject
    {
        private bool debugging;
        public double OpacityDebugging
        {
            get => debugging ? 1 : 0;
            set
            {
                OnPropertyChanged("OpacityDebugging");
            }
        }
        public FirstFloor()
        {
            debugging = true;
        }

    }
}
