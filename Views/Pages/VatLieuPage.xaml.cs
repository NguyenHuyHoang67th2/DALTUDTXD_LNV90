using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using DALTUDTXD_KIEMTRADAMTHEP_0024167_67TH2.ViewModels;

namespace DALTUDTXD_KIEMTRADAMTHEP_0024167_67TH2.Views.Pages
{
    public partial class VatLieuPage : Page
    {
        public class SteelGrade
        {
            public string Name { get; set; }
            public string Standard { get; set; }
            public double Fy { get; set; }
            public string FText { get; set; }
            public double FValue { get; set; }
            public double Fv => Math.Round(0.58 * FValue, 2);
        }

        private List<SteelGrade> listSteelGrades;

        public VatLieuPage()
        {
            InitializeComponent();
            this.DataContext = BeamViewModel.Instance;
            KhoiTaoDuLieuThepTheoAnh();
        }

        private void KhoiTaoDuLieuThepTheoAnh()
        {
            listSteelGrades = new List<SteelGrade>()
            {
                new SteelGrade { Name = "CCT34", Standard = "TCVN cũ", Fy = 210, FText = "200", FValue = 200 },
                new SteelGrade { Name = "CCT38", Standard = "TCVN cũ", Fy = 230, FText = "210", FValue = 210 },
                new SteelGrade { Name = "CT3 / C235", Standard = "TCVN/GOST", Fy = 235, FText = "210-215", FValue = 210 },
                new SteelGrade { Name = "Q235", Standard = "Trung Quốc", Fy = 235, FText = "215-225", FValue = 215 },
                new SteelGrade { Name = "A36", Standard = "Mỹ (ASTM)", Fy = 250, FText = "230-245", FValue = 230 },
                new SteelGrade { Name = "SS400", Standard = "Nhật (JIS)", Fy = 245, FText = "235", FValue = 235 },
                new SteelGrade { Name = "SM490", Standard = "Nhật (JIS)", Fy = 325, FText = "305-315", FValue = 305 },
                new SteelGrade { Name = "09G2S/C345", Standard = "TCVN/GOST", Fy = 345, FText = "315-325", FValue = 315 },
                new SteelGrade { Name = "Q355 (Q345)", Standard = "Trung Quốc", Fy = 355, FText = "315-325", FValue = 315 },
                new SteelGrade { Name = "A572 Gr.50", Standard = "Mỹ (ASTM)", Fy = 345, FText = "320-325", FValue = 320 }
            };
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // Nạp nguồn danh sách mác thép
            cboSteelGrade.ItemsSource = listSteelGrades;

            // KIỂM TRA: Nếu trong ViewModel đã có lưu tên mác thép trước đó, khôi phục lại
            var currentSteelName = BeamViewModel.Instance.SteelName;
            if (!string.IsNullOrEmpty(currentSteelName))
            {
                var matchedSteel = listSteelGrades.Find(s => s.Name == currentSteelName);
                if (matchedSteel != null)
                {
                    cboSteelGrade.SelectedItem = matchedSteel;
                    return; // Hoàn thành khôi phục, không chọn mặc định nữa
                }
            }

            // Nếu là lần đầu chạy (chưa có lưu), chọn mặc định CT3 / C235 (Index = 2)
            cboSteelGrade.SelectedIndex = 2;
        }

        private void cboSteelGrade_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboSteelGrade.SelectedItem is SteelGrade selected)
            {
                var vm = BeamViewModel.Instance;
                vm.SteelName = selected.Name;
                vm.Fy = selected.Fy;
                vm.F = selected.FValue;
                vm.Fv = selected.Fv;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Xác nhận vật liệu: {BeamViewModel.Instance.SteelName} thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnQuayLai_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService != null)
                this.NavigationService.Navigate(new HomePage());
        }
    }
}