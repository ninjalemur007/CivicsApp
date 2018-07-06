using AZED.CivicsApp.Models;

using Xamarin.Forms;

namespace AZED.CivicsApp.Views
{
    public partial class QuizAttemptsListPage : ContentPage
    {
        public QuizAttemptsListPage()
        {
            InitializeComponent();

            this.Title = "Quiz Attempts";

   //         var toolbarItem = new ToolbarItem
   //         {
   //             Text = "Add +"
   //         };

			//toolbarItem.Clicked += async (  sender,   e) => {
            
            //    await Navigation.PushAsync(new FAKEQuizAttemptPage()
            //    {
            //        BindingContext = new QAQuizAttempt()
            //    });
            //};

            //ToolbarItems.Add(toolbarItem);
        }
        
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            QuizAttemptsListView.ItemsSource = await App.Database.GetQuizAttemptsAsync();
        }

        async void QuizAttempt_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new QuizAttemptDetailPage()
                {
                    BindingContext = e.SelectedItem as QuizAttempt
                });
            }
        }
        

    }
}
