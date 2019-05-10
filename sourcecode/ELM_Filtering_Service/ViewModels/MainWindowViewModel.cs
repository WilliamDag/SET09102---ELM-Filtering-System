using ELM_Filtering_Service.Commands;
using ELM_Filtering_Service.Models;
using ELM_Filtering_Service.ViewModels;
using ELM_Filtering_Service.Views;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ELM_Filtering_Service.ViewModels
{
    class MainWindowViewModel : DefaultViewModel
    {
        //Button Bindings
        public ICommand HomeButtonCommand { get; set; }
        public ICommand AddMessageButtonCommand { get; set; }
        public ICommand ReviewMessageButtonCommand { get; set; }
        public ICommand FiguresButtonCommand { get; set; }
        public ICommand LoginButtonCommand { get; set; }
        public Brush HomeColour { get; set; }
        public Brush AddColour { get; set; }
        public Brush ReviewColour { get; set; }
        public Brush FiguresColour { get; set; }
        public string LoginButtonText { get; set; }
        //Control Binding
        public UserControl ContentControlBinding { get; set; }
        //Text Bindings
        public string TextLogin { get; set; }
        //TextBox Bindings
        public string TextBoxUsername { get; set; }
        private string Username { get; set; }
        private bool LoggedIn { get; set; }

        private void UpdateBindings()
        {
            onChanged(nameof(HomeColour));
            onChanged(nameof(AddColour));
            onChanged(nameof(ReviewColour));
            onChanged(nameof(FiguresColour));
            onChanged(nameof(ContentControlBinding));
        }

        public MainWindowViewModel()
        {
            HomeColour = (SolidColorBrush)(new BrushConverter().ConvertFrom("#00728A"));
            AddColour = null;
            ReviewColour = null;
            FiguresColour = null;
            ContentControlBinding = new HomeView();
            HomeButtonCommand = new RelayCommand(HomeButtonClick);
            AddMessageButtonCommand = new RelayCommand(AddMessageButtonClick);
            ReviewMessageButtonCommand = new RelayCommand(ReviewMessageButtonClick);
            FiguresButtonCommand = new RelayCommand(FiguresButtonClick);
            LoginButtonCommand = new RelayCommand(LoginButtonClick);
            TextLogin = "Welcome, Please Login";
            LoginButtonText = "Login";
            Username = "User";
            LoggedIn = false;
        }

        //Logs the user in
        private void LoginButtonClick()
        {
            if (TextBoxUsername == Username)
            {
                LoggedIn = true;
                MessageBox.Show("Login Successful.\nWelcome to ELM.");
            }
            else
            {
                MessageBox.Show("Enter Valid Username & Password", "Login Error");
            }
        }

        //Goes to home View
        private void HomeButtonClick()
        {
            HomeColour = (SolidColorBrush)(new BrushConverter().ConvertFrom("#00728A"));
            ReviewColour = null;
            AddColour = null;
            FiguresColour = null;
            ContentControlBinding = new HomeView();
            UpdateBindings();
        }

        //Goes to the Add Message View
        private void AddMessageButtonClick()
        {
            if (LoggedIn)
            {
                AddColour = (SolidColorBrush)(new BrushConverter().ConvertFrom("#00728A"));
                HomeColour = null;
                ReviewColour = null;
                FiguresColour = null;
                ContentControlBinding = new AddMessage();
                UpdateBindings();
            }
            else
            {
                MessageBox.Show("Please Login.");
            }
        }

        //Goes to the Review Message View
        private void ReviewMessageButtonClick()
        {
            if (LoggedIn)
            {
                ReviewColour = (SolidColorBrush)(new BrushConverter().ConvertFrom("#00728A"));
                HomeColour = null;
                AddColour = null;
                FiguresColour = null;
                ContentControlBinding = new ViewMessage();
                UpdateBindings();
            }
            else
            {
                MessageBox.Show("Please Login.");
            }
        }

        //Goes to the Figures View
        private void FiguresButtonClick()
        {
            if (LoggedIn)
            {
                FiguresColour = (SolidColorBrush)(new BrushConverter().ConvertFrom("#00728A"));
                HomeColour = null;
                AddColour = null;
                ReviewColour = null;
                ContentControlBinding = new FiguresView();
                UpdateBindings();
            }
            else
            {
                MessageBox.Show("Please Login.");
            }
        }
    }
}