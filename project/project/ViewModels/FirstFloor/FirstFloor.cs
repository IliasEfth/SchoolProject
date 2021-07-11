using Prism.Commands;
using project.Models;
using project.Models.Room;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace project.ViewModels.FirstFloor
{
    public class FirstFloor : BindableObject
    {
        public DebugHelper debug { get; private set; }
        private Room previousGoBackState;
        public FirstFloor()
        {
            #region debug information
            debug = new DebugHelper();
            #endregion

            #region commands
            GoBack = new DelegateCommand(goBack, () => true);
            OpenCloseLights = new DelegateCommand<object>(openCloseLights, (_) => true);
            Help = new DelegateCommand(helpAction, () => true);
            GoTo = new DelegateCommand<object>(goToAction,(_)=>true);
            GoToSecondFloor = new DelegateCommand(gotoHallwayAction, () => true);
            #endregion

            #region grid params
            this.ShowMainPageGrid = true;
            #endregion

            #region rooms
            Kitchen = new Room();
            BedRoom = new Room();
            LivingRoom = new Room();
            BathRoom = new Room();
            Closet = new Room();
            Garage = new Room();
            #endregion
        }
        #region commands
        public DelegateCommand GoBack { get; private set; }
        public DelegateCommand<object> OpenCloseLights { get; private set; }
        public DelegateCommand<object> GoTo { get; private set; }
        public DelegateCommand GoToSecondFloor { get; private set; }
        public DelegateCommand Help { get; private set; }
        #endregion

        #region grid properties
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
        #endregion

        #region rooms
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
        private Room bedRoom;
        public Room BedRoom
        {
            get => bedRoom;
            set
            {
                bedRoom = value;
                OnPropertyChanged("BedRoom");
            }
        }
        private Room livingRoom;
        public Room LivingRoom
        {
            get => livingRoom;
            set
            {
                livingRoom = value;
                OnPropertyChanged("LivingRoom");
            }
        }
        private Room bathRoom;
        public Room BathRoom
        {
            get => bathRoom;
            set
            {
                bathRoom = value;
                OnPropertyChanged("BathRoom");
            }
        }
        private Room closet;
        public Room Closet
        {
            get => closet;
            set
            {
                closet = value;
                OnPropertyChanged("Closet");
            }
        }
        private Room garage;
        public Room Garage
        {
            get => garage;
            set
            {
                garage = value;
                OnPropertyChanged("Garage");
            }
        }
        #endregion

        private async void goBack()
        {
            previousGoBackState.IsVisible = false;
            this.ShowMainPageGrid = true;
        }

        private async void openCloseLights(object room)
        {
            Room r = room as Room;
            if (r == null)
                return;
            r.OnLights = !r.OnLights;
        }

        private async void gotoHallwayAction()
        {
            await Shell.Current.GoToAsync("//SecondFloor");
        }

        private async void helpAction()
        {
            if (this.HideMainPageGrid)
            {
                await App.Current.MainPage.DisplayAlert(null, "Για να ανάψετε / σβήσετε τα φώτα πρέπει να πατήσεται πάνω σε κάποια λάμπα ή στον διακόπτη εάν υπάρχει", "Κατάλαβα");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert(null, "Για να δείτε και να αλληλεπιδράσετε με κάποιο δομάτιο πρέπει να πατήσεται πάνω στο όνομα του δωματίου", "Κατάλαβα");
            }
        }

        private async void goToAction(object room)
        {
            Room r = room as Room;
            if (r == null)
                return;
            this.ShowMainPageGrid = false;
            r.IsVisible = true;
            previousGoBackState = r;
        }
    }
}
