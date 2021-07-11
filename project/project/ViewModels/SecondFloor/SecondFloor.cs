using Prism.Commands;
using project.Models;
using project.Models.Room;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace project.ViewModels.SecondFloor
{
    public class SecondFloor : BindableObject
    {
        public DebugHelper debug { get; private set; }
        private Room previousGoBackState;
        public SecondFloor()
        {
            #region debug information
            debug = new DebugHelper();
            #endregion

            #region commands
            GoBack = new DelegateCommand(goBack, () => true);
            OpenCloseLights = new DelegateCommand<object>(openCloseLights, (_) => true);
            Help = new DelegateCommand(helpAction, () => true);
            GoTo = new DelegateCommand<object>(goToAction, (_) => true);
            #endregion

            #region grid params
            this.ShowPage1Grid = true;
            #endregion

            #region rooms
            GuestRoom = new Room();
            BedRoom = new Room();
            Hallway = new Room();
            BathRoom = new Room();
            LaundryRoom = new Room();
            Office = new Room();
            #endregion
        }
        #region commands
        public DelegateCommand GoBack { get; private set; }
        public DelegateCommand<object> OpenCloseLights { get; private set; }
        public DelegateCommand<object> GoTo { get; private set; }
        public DelegateCommand Help { get; private set; }
        #endregion

        #region grid properties
        private bool showGrid;
        public bool ShowPage1Grid
        {
            get => showGrid;
            set
            {
                showGrid = value;
                OnPropertyChanged("ShowPage1Grid");
                OnPropertyChanged("HidePage1Grid");
            }
        }
        public bool HidePage1Grid
        {
            get => !this.showGrid;
        }
        #endregion

        #region rooms
        private Room guestRoom;
        public Room GuestRoom
        {
            get => guestRoom;
            set
            {
                guestRoom = value;
                OnPropertyChanged("GuestRoom");
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
        private Room hallway;
        public Room Hallway
        {
            get => hallway;
            set
            {
                hallway = value;
                OnPropertyChanged("Hallway");
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
        private Room laundryRoom;
        public Room LaundryRoom
        {
            get => laundryRoom;
            set
            {
                laundryRoom = value;
                OnPropertyChanged("LaundryRoom");
            }
        }
        private Room office;
        public Room Office
        {
            get => office;
            set
            {
                office = value;
                OnPropertyChanged("Office");
            }
        }
        #endregion

        private async void goBack()
        {
            previousGoBackState.IsVisible = false;
            this.ShowPage1Grid = true;
        }

        private async void openCloseLights(object room)
        {
            Room r = room as Room;
            if (r == null)
                return;
            r.OnLights = !r.OnLights;
        }

        private async void helpAction()
        {
            if (this.HidePage1Grid)
            {
                await App.Current.MainPage.DisplayAlert(null, "Για να ανάψετε/σβήσετε τα φώτα πρέπει να πατήσετε πάνω σε κάποια λάμπα ή στον διακόπτη, εάν υπάρχει", "Κατάλαβα");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert(null, "Για να δείτε και να αλληλεπιδράσετε με κάποιο δωμάτιο πρέπει να πατήσετε επάνω στο όνομα του δωματίου", "Κατάλαβα");
            }
        }

        private async void goToAction(object room)
        {
            Room r = room as Room;
            if (r == null)
                return;
            this.ShowPage1Grid = false;
            r.IsVisible = true;
            previousGoBackState = r;
        }
    }
}
