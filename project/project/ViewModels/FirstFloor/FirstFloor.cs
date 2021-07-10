using Prism.Commands;
using project.Models.Room;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace project.ViewModels.FirstFloor
{
    public class FirstFloor : BindableObject
    {
        private Room previousGoBackState;
        public FirstFloor()
        {
            debugging = true;
            GoToKitchen = new DelegateCommand(gotokitchenAction, () => true);
            GoBack = new DelegateCommand(goBack, () => true);
            OpenCloseLights = new DelegateCommand(openCloseLights, () => true);
            this.ShowMainPageGrid = true;
            //else buttons to false
            Kitchen = new Room();
        }
        private bool debugging;
        public double OpacityDebugging
        {
            get => debugging ? 1 : 0;
            set
            {
                OnPropertyChanged("OpacityDebugging");
            }
        }
        public DelegateCommand GoToKitchen { get; private set; }
        public DelegateCommand GoBack { get; private set; }
        public DelegateCommand OpenCloseLights { get; private set; }
        //we start here
        private bool showGrid;
        public bool ShowMainPageGrid
        {
            get => showGrid;
            set
            {
                showGrid = value;
                OnPropertyChanged("ShowMainPageGrid");
                OnPropertyChanged("HideMainPageGrid");
            }
        }
        public bool HideMainPageGrid
        {
            get => !this.showGrid;
        }
        private Room kitchen;
        public Room Kitchen
        {
            get => kitchen;
            set
            {
                kitchen = value;
                OnPropertyChanged("Kitchen");
            }
        }

        private async void gotokitchenAction()
        {
            this.ShowMainPageGrid = false;
            this.Kitchen.IsVisible = true;
            previousGoBackState = this.Kitchen;
        }
        private async void goBack()
        {
            previousGoBackState.IsVisible = false;
            this.ShowMainPageGrid = true;
        }

        private async void openCloseLights()
        {
            previousGoBackState.OnLights = !previousGoBackState.OnLights;
        }
    }
}
