using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DALTUDTXD_KIEMTRADAMTHEP_0024167_67TH2.ViewModels;
namespace DALTUDTXD_KIEMTRADAMTHEP_0024167_67TH2.Views.Pages
{
    public partial class TinhToanPage : Page
    {
        public TinhToanPage()
        {
            InitializeComponent();
            // Đăng ký DataContext chung
            this.DataContext = BeamViewModel.Instance;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            CapNhatHieuUngTrangThaiBadges();
        }

        private void btnKiemTraBen_Click(object sender, RoutedEventArgs e)
        {
            CapNhatHieuUngTrangThaiBadges();
        }

        private void btnKiemTraOnDinh_Click(object sender, RoutedEventArgs e)
        {
            CapNhatHieuUngTrangThaiBadges();
        }

        // Cập nhật đèn trạng thái dựa trên các kết quả tính toán từ Model con Results
        private void CapNhatHieuUngTrangThaiBadges()
        {
            var vm = BeamViewModel.Instance;

            // 1. Kiểm tra bền (Gọi qua vm.Results. ...)
            SetBadgeStatus(vm.Results.Sigma, vm.Results.LimitF, badgeSigma, lblBadgeSigma);
            SetBadgeStatus(vm.Results.Tau, vm.Results.LimitFv, badgeTau, lblBadgeTau);
            SetBadgeStatus(vm.Results.SigmaC, vm.Results.LimitF, badgeSigmaC, lblBadgeSigmaC);

            // 2. Miễn ổn định tổng thể (Gọi qua vm.Results. ...)
            if (vm.Results.IsExempt)
            {
                badgeExempt.Background = new SolidColorBrush(Color.FromRgb(46, 125, 50));
                lblBadgeExempt.Text = "⚡ MIỄN KIỂM TRA";
                panelDetailStability.Visibility = Visibility.Collapsed;
            }
            else
            {
                badgeExempt.Background = new SolidColorBrush(Color.FromRgb(245, 124, 0));
                lblBadgeExempt.Text = "⚠️ PHẢI KIỂM TRA";
                panelDetailStability.Visibility = Visibility.Visible;
                SetBadgeStatus(vm.Results.SigmaOD, vm.Results.LimitF, badgeStabilityCheck, lblBadgeStabilityCheck);
            }

            // 3. Ổn định trong mặt phẳng và ổn định cục bộ bản cánh (Gọi qua vm.Results. ...)
            SetBadgeStatus(vm.Results.SigmaInPlane, vm.Results.LimitF, badgeInPlaneCheck, lblBadgeInPlaneCheck);
            SetBadgeStatus(vm.Results.RatioB0Tf, vm.Results.LimitB0Tf, badgeFlangeLocalCheck, lblBadgeFlangeLocalCheck);

            // 4. Ổn định cục bộ bản bụng dầm (Gọi qua vm.Results. ...)
            if (vm.Results.LambdaW <= vm.Results.LimitLambdaW)
            {
                badgeWebLocalCheck.Background = new SolidColorBrush(Color.FromRgb(46, 125, 50));
                lblBadgeWebLocalCheck.Text = "✔️ ĐẠT (Tự ổn định)";
                txtWebStatusText.Foreground = new SolidColorBrush(Color.FromRgb(46, 125, 50));
                txtWebStatusText.Text = "Bản bụng dầm đủ dày để tự đảm bảo ổn định cục bộ. Người thiết kế không cần bố trí các sườn cứng ngang gia cường dọc theo nhịp dầm.";
                txtWebDetailText.Visibility = Visibility.Collapsed;
            }
            else
            {
                badgeWebLocalCheck.Background = new SolidColorBrush(Color.FromRgb(245, 124, 0));
                lblBadgeWebLocalCheck.Text = "⚠️ YÊU CẦU SƯỜN";
                txtWebStatusText.Foreground = new SolidColorBrush(Color.FromRgb(216, 67, 21));
                txtWebStatusText.Text = "Bản bụng dầm có nguy cơ oằn cục bộ! Tiêu chuẩn bắt buộc phải bố trí các sườn cứng ngang để gia cường.";

                double a_limit = (vm.Results.LambdaW > 3.2) ? 2.0 * vm.Results.hw_m : 2.5 * vm.Results.hw_m;
                double hw_mm = vm.Hw;
                double bs_min = cboRibLayout.SelectedIndex == 0 ? (hw_mm / 30.0) + 40.0 : (hw_mm / 24.0) + 50.0;
                double ts_min = 2.0 * bs_min * Math.Sqrt(vm.F / 206000.0);

                string detailReport = $"• Khoảng cách sườn cứng ngang: a ≤ {a_limit.ToString("0.00")} m (a ≤ {(vm.Results.LambdaW > 3.2 ? "2" : "2.5")}*hw)\n" +
                                      $"• Chiều rộng sườn tối thiểu: bs ≥ {Math.Ceiling(bs_min)} mm\n" +
                                      $"• Chiều dày sườn tối thiểu: ts ≥ {ts_min.ToString("0.1")} mm";

                if (vm.Results.LambdaW > 5.5)
                {
                    badgeWebLocalCheck.Background = new SolidColorBrush(Color.FromRgb(198, 40, 40));
                    lblBadgeWebLocalCheck.Text = "❌ Y/C SƯỜN DỌC";
                    txtWebStatusText.Text = "CẢNH BÁO: Bản bụng quá mỏng! Ngoài sườn ngang, bắt buộc bố trí sườn dọc song song biên chịu nén dầm.";

                    double h1_min = 0.2 * hw_mm;
                    double h1_max = 0.3 * hw_mm;
                    detailReport += $"\n• Gia cường sườn dọc đặt cách mép biên bụng chịu nén một khoảng h1 = {h1_min.ToString("0.0")} ÷ {h1_max.ToString("0.0")} mm.";
                }

                txtWebDetailText.Text = detailReport;
                txtWebDetailText.Visibility = Visibility.Visible;
            }
        }

        private void SetBadgeStatus(double value, double limit, Border badge, TextBlock label)
        {
            if (value <= limit && value >= 0 && limit > 0)
            {
                badge.Background = new SolidColorBrush(Color.FromRgb(46, 125, 50));
                label.Text = "✔️ ĐẠT";
            }
            else
            {
                badge.Background = new SolidColorBrush(Color.FromRgb(198, 40, 40));
                label.Text = "❌ KHÔNG ĐẠT";
            }
        }

        // Định nghĩa các phương thức tránh lỗi sự kiện trên file XAML
        private void cboLinkType_SelectionChanged(object sender, SelectionChangedEventArgs e) { }
        private void cboLoadPosition_SelectionChanged(object sender, SelectionChangedEventArgs e) { }
        private void cboLoadCaseTableE_SelectionChanged(object sender, SelectionChangedEventArgs e) { }
        private void cboLoadTypeWeb_SelectionChanged(object sender, SelectionChangedEventArgs e) { }
        private void cboRibLayout_SelectionChanged(object sender, SelectionChangedEventArgs e) { }

        private void btnQuayLai_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService != null)
                this.NavigationService.Navigate(new HomePage());
        }
    }
}