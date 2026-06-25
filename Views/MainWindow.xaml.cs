using System;
using System.Windows;
using DALTUDTXD_KIEMTRADAMTHEP_0024167_67TH2.Views.Pages;

namespace DALTUDTXD_KIEMTRADAMTHEP_0024167_67TH2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnTaoMoi_Click(object sender, RoutedEventArgs e)
        {
            // Ẩn hoàn toàn giao diện khởi động cũ
            StartupGrid.Visibility = Visibility.Collapsed;

            // Hiển thị Frame chiếm trọn màn hình 
            MainFrame.Visibility = Visibility.Visible;

            // Điều hướng chuyển sang HomePage
            MainFrame.Navigate(new HomePage());
        }

        private void imgNen_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            // Tránh crash nếu thiếu ảnh nền
        }

        public void QuayLaiManHinhKhoiDong()
        {
            MainFrame.Visibility = Visibility.Collapsed; // Ẩn Frame tính toán đi
            StartupGrid.Visibility = Visibility.Visible;  // Hiện lại màn hình gốc ban đầu
        }
        private void btnMoTaiLieu_Click(object sender, RoutedEventArgs e)
        {
            // 1. Ẩn giao diện ban đầu
            StartupGrid.Visibility = Visibility.Collapsed;

            // 2. Hiện Frame
            MainFrame.Visibility = Visibility.Visible;

            // 3. Chuyển hướng Frame đến trang TaiLieuPage
            MainFrame.Navigate(new TaiLieuPage());
        }
    }
}