using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace project.Models.Room
{
    public class Room : BindableObject
    {
        private bool onLights;
        private bool isVisible;

        public bool IsVisible
        {
            get => isVisible;
            set
            {
                isVisible = value;
                OnPropertyChanged("IsVisible");
            }
        }
        public bool LightsAreOn
        {
            get => onLights;
        }
        public bool LightsAreNotOn
        {
            get => !onLights;
        }
        public bool OnLights
        {
            get
            {
                return this.onLights;
            }
            set
            {
                onLights = value;
                OnPropertyChanged("OnLights");
                OnPropertyChanged("LightsAreOn");
                OnPropertyChanged("LightsAreNotOn");
            }
        }
        public Room()
        {
            IsVisible = false;
            OnLights = false;
        }
    }
}
