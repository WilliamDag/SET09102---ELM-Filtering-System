using ELM_Filtering_Service.ViewModels;
using System.Collections.Generic;
using System.Windows.Controls;

namespace ELM_Filtering_Service.Views
{
    /// <summary>
    /// Interaction logic for Figures.xaml
    /// </summary>
    public partial class FiguresView : UserControl
    {
        public FiguresView()
        {
            InitializeComponent();
            this.DataContext = new FiguresViewModel();
        }
    }
}
