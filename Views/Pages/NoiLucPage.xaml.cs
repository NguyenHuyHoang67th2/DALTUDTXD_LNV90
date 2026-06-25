using System;
using System.Windows;
using System.Windows.Controls;
using DALTUDTXD_KIEMTRADAMTHEP_0024167_67TH2.ViewModels;

namespace DALTUDTXD_KIEMTRADAMTHEP_0024167_67TH2.Views.Pages
{
    public partial class NoiLucPage : Page
    {
        public NoiLucPage()
        {
            InitializeComponent();
            this.DataContext = BeamViewModel.Instance;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e) { }

        private void rdoManual_Checked(object sender, RoutedEventArgs e)
        {
            if (PanelManualInput != null)
            {
                PanelManualInput.Visibility = Visibility.Visible;
                PanelEtabsInput.Visibility = Visibility.Collapsed;
                btnSave.IsEnabled = true;
            }
        }

        private void rdoEtabs_Checked(object sender, RoutedEventArgs e)
        {
            if (PanelManualInput != null)
            {
                PanelManualInput.Visibility = Visibility.Collapsed;
                PanelEtabsInput.Visibility = Visibility.Visible;
                btnSave.IsEnabled = false;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Lưu thông số nội lực thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnQuayLai_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService != null)
                this.NavigationService.Navigate(new HomePage());
        }
    }
}