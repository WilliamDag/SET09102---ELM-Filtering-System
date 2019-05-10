using ELM_Filtering_Service.ViewModels;
using System.Windows.Controls;

namespace ELM_Filtering_Service.Views
{
    /// <summary>
    /// Interaction logic for ViewMessage.xaml
    /// </summary>
    public partial class ViewMessage : UserControl
    {
        public ViewMessage()
        {
            InitializeComponent();
            this.DataContext = new ReviewMessageViewModel();
        }
    }
}
