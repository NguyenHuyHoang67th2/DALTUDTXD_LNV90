using System;
using System.Windows;
using System.Windows.Controls;

namespace DALTUDTXD_KIEMTRADAMTHEP_0024167_67TH2.Views.Pages
{
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void btnKichThuoc_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService != null)
                this.NavigationService.Navigate(new KichThuocPage());
        }

        private void btnVatLieu_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService != null)
                this.NavigationService.Navigate(new VatLieuPage());
        }

        private void btnNoiLuc_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService != null)
                this.NavigationService.Navigate(new NoiLucPage());
        }

        private void btnKiemTra_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService != null)
                this.NavigationService.Navigate(new TinhToanPage());
        }

        // Sự kiện click nút quay lại màn hình chào mừng ban đầu của MainWindow
        private void btnQuayLaiStart_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.QuayLaiManHinhKhoiDong();
            }
        }
    }
}
