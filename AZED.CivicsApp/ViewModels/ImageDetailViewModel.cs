using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace AZED.CivicsApp.ViewModels
{
    public class ImageDetailViewModel : AppViewModelBase
    {

        public ICommand ShowImageDetailView { get; private set; }
        public ICommand ShowImageFullScreen { get; private set; }

     
        private bool showFullImage;
        public bool ShowFullImage
        {
            get { return showFullImage; }
            set
            {
                if (Set(() => ShowFullImage, ref showFullImage, value))
                { RaisePropertyChanged(() => ShowFullImage); }
            }
        }

        private bool showSmallImage;
        public bool ShowSmallImage
        {
            get { return showSmallImage; }
            set
            {
                if (Set(() => ShowSmallImage, ref showSmallImage, value))
                { RaisePropertyChanged(() => ShowSmallImage); }
            }
        }

        private bool showDetails;
        public bool ShowDetails
        {
            get { return showDetails; }
            set
            {
                if (Set(() => ShowDetails, ref showDetails, value))
                { RaisePropertyChanged(() => ShowDetails); }
            }
        }

        public ImageDetailViewModel() {
            ShowImageDetailView = new Command(ShowInitialView);
            ShowImageFullScreen = new Command(ZoomImage);
            Initialize();
        }
       


        public void Initialize()
        {
            this.ShowInitialView();
        }

        private void ImageFullScreen()
        {
            ZoomImage();
        }

        private void ImageDetailView()
        {
            ShowInitialView();
        }


        private void ShowInitialView()
        {
            ShowFullImage = false;
            ShowDetails = true;
            ShowSmallImage = true;
        }

        private void ZoomImage()
        {
            ShowFullImage = true;
            ShowDetails = false;
            ShowSmallImage = false;
        }




    }
}

