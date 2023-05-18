using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using UI.ChuBao.ViewModels;

namespace UI.ChuBao
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.DataContext = App.AppHost.Services.GetRequiredService<MainViewModel>();
            InitializeComponent();
        }
    }
}
