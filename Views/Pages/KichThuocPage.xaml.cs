using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DALTUDTXD_KIEMTRADAMTHEP_0024167_67TH2.ViewModels;

namespace DALTUDTXD_KIEMTRADAMTHEP_0024167_67TH2.Views.Pages
{
    public partial class KichThuocPage : Page
    {
        public KichThuocPage()
        {
            InitializeComponent();
            this.DataContext = BeamViewModel.Instance; // Đồng bộ DataContext
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            CapNhatHinhVe();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            CapNhatHinhVe();
            MessageBox.Show("Đã lưu và cập nhật thông số hình học dầm!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CapNhatHinhVe()
        {
            try
            {
                var vm = BeamViewModel.Instance;
                double hw = vm.Hw;
                double tw = vm.Tw;
                double bf = vm.Bf;
                double tf = vm.Tf;

                double H_tong = hw + 2 * tf;
                double canvasWidth = DrawingCanvas.ActualWidth <= 0 ? 450 : DrawingCanvas.ActualWidth;
                double canvasHeight = DrawingCanvas.ActualHeight <= 0 ? 400 : DrawingCanvas.ActualHeight;

                double centerC_X = canvasWidth / 2;
                double centerC_Y = canvasHeight / 2;
                double drawWidthMax = canvasWidth - 120;
                double drawHeightMax = canvasHeight - 80;

                double S = Math.Min(drawWidthMax / bf, drawHeightMax / H_tong);

                double sBf = bf * S;
                double sTf = tf * S;
                double sHw = hw * S;
                double sTw = tw * S;
                double sH_tong = H_tong * S;

                PointCollection points = new PointCollection();
                points.Add(new Point(centerC_X - sBf / 2, centerC_Y - sH_tong / 2));
                points.Add(new Point(centerC_X + sBf / 2, centerC_Y - sH_tong / 2));
                points.Add(new Point(centerC_X + sBf / 2, centerC_Y - sH_tong / 2 + sTf));
                points.Add(new Point(centerC_X + sTw / 2, centerC_Y - sH_tong / 2 + sTf));
                points.Add(new Point(centerC_X + sTw / 2, centerC_Y + sH_tong / 2 - sTf));
                points.Add(new Point(centerC_X + sBf / 2, centerC_Y + sH_tong / 2 - sTf));
                points.Add(new Point(centerC_X + sBf / 2, centerC_Y + sH_tong / 2));
                points.Add(new Point(centerC_X - sBf / 2, centerC_Y + sH_tong / 2));
                points.Add(new Point(centerC_X - sBf / 2, centerC_Y + sH_tong / 2 - sTf));
                points.Add(new Point(centerC_X - sTw / 2, centerC_Y + sH_tong / 2 - sTf));
                points.Add(new Point(centerC_X - sTw / 2, centerC_Y - sH_tong / 2 + sTf));
                points.Add(new Point(centerC_X - sBf / 2, centerC_Y - sH_tong / 2 + sTf));

                BeamPolygon.Points = points;

                Canvas.SetLeft(lblBf, centerC_X - 25);
                Canvas.SetTop(lblBf, centerC_Y - sH_tong / 2 - 22);
                lblBf.Text = $"bf = {bf} mm";

                Canvas.SetLeft(lblHw, centerC_X + sTw / 2 + 10);
                Canvas.SetTop(lblHw, centerC_Y - 8);
                lblHw.Text = $"hw = {hw} mm";

                Canvas.SetLeft(lblTf, centerC_X + sBf / 2 + 12);
                Canvas.SetTop(lblTf, centerC_Y + sH_tong / 2 - sTf - 8);
                lblTf.Text = $"tf = {tf} mm";

                Canvas.SetLeft(lblTw, centerC_X - sTw / 2 - 75);
                Canvas.SetTop(lblTw, centerC_Y - 25);
                lblTw.Text = $"tw = {tw} mm";
            }
            catch { }
        }

        private void btnQuayLai_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService != null)
                this.NavigationService.Navigate(new HomePage());
        }
    }
}