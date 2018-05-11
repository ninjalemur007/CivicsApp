/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:Test"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using System;
using System.Reflection;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;

namespace AZED.CivicsApp.ViewModels
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ConfigurationUtility.ConfigureServices();
            ConfigurationUtility.ConfigureViewModels();
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }

        /// <summary>
        /// Get a viewmodel for a page based on convention.
        /// e.g. returns a MainViewModel for MainPage.
        /// </summary>
        /// <typeparam name="T">content page</typeparam>
        /// <param name="page">page type</param>
        /// <returns>view model instance</returns>
        public object GetViewModel<T>(T page)
            where T : Xamarin.Forms.ContentPage
        {
            string pageName = page.GetType().Name;

            string viewModelName = pageName.Replace("Page", "ViewModel");

            var types = this.GetType()
                             .GetTypeInfo()
                             .Assembly
                             .DefinedTypes;

            var vmtype = this.GetType()
                             .GetTypeInfo()
                             .Assembly
                             .DefinedTypes
                             .FirstOrDefault(t => t.Name.Equals(viewModelName))
                             .AsType();

            return SimpleIoc.Default.GetInstance(vmtype);
        }

    }
}