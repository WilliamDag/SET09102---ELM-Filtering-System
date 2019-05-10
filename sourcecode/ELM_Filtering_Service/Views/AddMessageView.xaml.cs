using ELM_Filtering_Service.ViewModels;
using System.Windows.Controls;

namespace ELM_Filtering_Service.Views
{
    /// <summary>
    /// Interaction logic for AddMessage.xaml
    /// </summary>
    public partial class AddMessage : UserControl
    {
        public AddMessage()
        {
            InitializeComponent();
            this.DataContext = new AddMessageViewModel();
        }
    }
}
