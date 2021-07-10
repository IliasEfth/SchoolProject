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
            GoToKitchen = new DelegateCommand(gotokitchenAction, () => true);//done
            GoBack = new DelegateCommand(goBack, () => true);//done
            OpenCloseLights = new DelegateCommand(openCloseLights, () => true);//done
            GoToBedRoom = new DelegateCommand(gotoBedRoomAction, () => true);
            GoToLivingRoom = new DelegateCommand(gotoLivingRoomAction, () => true);
            GoToHallway = new DelegateCommand(gotoHallwayAction, () => true);
            GoToBathRoom = new DelegateCommand(gotoBathRoomAction, () => true);
            GoToCloset = new DelegateCommand(gotoClosetAction, () => true);
            GoToGarage = new DelegateCommand(gotoGarageAction, () => true);
            Help = new DelegateCommand(helpAction, () => true);
            #endregion

            this.ShowMainPageGrid = true;

            #region rooms
            Kitchen = new Room();
            BedRoom = new Room();
            LivingRoom = new Room();
            BathRoom = new Room();
            Closet = new Room();
            Garage = new Room();
            #endregion
        }
        //commands
        public DelegateCommand GoToKitchen { get; private set; }
        public DelegateCommand GoBack { get; private set; }
        public DelegateCommand OpenCloseLights { get; private set; }
        public DelegateCommand GoToBedRoom { get; private set; }
        public DelegateCommand GoToLivingRoom { get; private set; }
        public DelegateCommand GoToHallway { get; private set; }
        public DelegateCommand GoToBathRoom { get; private set; }
        public DelegateCommand GoToCloset { get; private set; }
        public DelegateCommand GoToGarage { get; private set; }
        public DelegateCommand GoToSecondFloor { get; private set; }
        public DelegateCommand Help { get; private set; }
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

        private async void gotoBedRoomAction()
        {
            this.ShowMainPageGrid = false;
            this.BedRoom.IsVisible = true;
            previousGoBackState = this.BedRoom;
        }

        private async void gotoLivingRoomAction()
        {
            this.ShowMainPageGrid = false;
            this.LivingRoom.IsVisible = true;
            previousGoBackState = this.LivingRoom;
        }

        private async void gotoHallwayAction()
        {
            await Shell.Current.GoToAsync("//SecondFloor");
        }

        private async void gotoBathRoomAction()
        {
            this.ShowMainPageGrid = false;
            this.BathRoom.IsVisible = true;
            previousGoBackState = this.BathRoom;
        }

        private async void gotoClosetAction()
        {
            this.ShowMainPageGrid = false;
            this.Closet.IsVisible = true;
            previousGoBackState = this.Closet;
        }

        private async void gotoGarageAction()
        {
            this.ShowMainPageGrid = false;
            this.Garage.IsVisible = true;
            previousGoBackState = this.Garage;
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
    }
}
