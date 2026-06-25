using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALTUDTXD_KIEMTRADAMTHEP_0024167_67TH2.Models;

using DALTUDTXD_KIEMTRADAMTHEP_0024167_67TH2.Models;

namespace DALTUDTXD_KIEMTRADAMTHEP_0024167_67TH2.ViewModels
{
    public class BeamViewModel : ViewModelBase
    {
        // Khởi tạo Singleton dùng chung vùng nhớ toàn cục
        public static BeamViewModel Instance { get; } = new BeamViewModel();

        public DesignSession Dimensions { get; }
        public SteelMaterial Material { get; }
        public BeamInput Forces { get; }
        public BeamResult Results { get; }

        private BeamViewModel()
        {
            Dimensions = new DesignSession();
            Material = new SteelMaterial();
            Forces = new BeamInput();
            Results = new BeamResult(Dimensions, Material, Forces);
        }

        #region PROPERTIES WRAPPER CHO DESIGN SESSION (KÍCH THƯỚC)
        public double Hw
        {
            get => Dimensions.Hw;
            set { Dimensions.Hw = value; OnPropertyChanged(); NotifyAllData(); }
        }
        public double Tw
        {
            get => Dimensions.Tw;
            set { Dimensions.Tw = value; OnPropertyChanged(); NotifyAllData(); }
        }
        public double Bf
        {
            get => Dimensions.Bf;
            set { Dimensions.Bf = value; OnPropertyChanged(); NotifyAllData(); }
        }
        public double Tf
        {
            get => Dimensions.Tf;
            set { Dimensions.Tf = value; OnPropertyChanged(); NotifyAllData(); }
        }
        public double L
        {
            get => Dimensions.L;
            set { Dimensions.L = value; OnPropertyChanged(); NotifyAllData(); }
        }
        public int LinkTypeIndex
        {
            get => Dimensions.LinkTypeIndex;
            set { Dimensions.LinkTypeIndex = value; OnPropertyChanged(); NotifyAllData(); }
        }
        public int LoadPositionIndex
        {
            get => Dimensions.LoadPositionIndex;
            set { Dimensions.LoadPositionIndex = value; OnPropertyChanged(); NotifyAllData(); }
        }
        public int LoadCaseIndex
        {
            get => Dimensions.LoadCaseIndex;
            set { Dimensions.LoadCaseIndex = value; OnPropertyChanged(); NotifyAllData(); }
        }
        #endregion

        #region PROPERTIES WRAPPER CHO STEEL MATERIAL (VẬT LIỆU)
        public string SteelName
        {
            get => Material.SteelName;
            set { Material.SteelName = value; OnPropertyChanged(); NotifyAllData(); }
        }
        public double Fy
        {
            get => Material.Fy;
            set { Material.Fy = value; OnPropertyChanged(); NotifyAllData(); }
        }
        public double F
        {
            get => Material.F;
            set { Material.F = value; OnPropertyChanged(); NotifyAllData(); }
        }
        public double Fv
        {
            get => Material.Fv;
            set { Material.Fv = value; OnPropertyChanged(); NotifyAllData(); }
        }
        public double GammaC
        {
            get => Material.GammaC;
            set { Material.GammaC = value; OnPropertyChanged(); NotifyAllData(); }
        }
        #endregion

        #region PROPERTIES WRAPPER CHO BEAM INPUT (NỘI LỰC)
        public double M
        {
            get => Forces.M;
            set { Forces.M = value; OnPropertyChanged(); NotifyAllData(); }
        }
        public double V
        {
            get => Forces.V;
            set { Forces.V = value; OnPropertyChanged(); NotifyAllData(); }
        }
        public double ConcentratedForceF
        {
            get => Forces.ConcentratedForceF;
            set { Forces.ConcentratedForceF = value; OnPropertyChanged(); NotifyAllData(); }
        }
        public double DistributionLengthB
        {
            get => Forces.DistributionLengthB;
            set { Forces.DistributionLengthB = value; OnPropertyChanged(); NotifyAllData(); }
        }
        public double AxialForceN
        {
            get => Forces.AxialForceN;
            set { Forces.AxialForceN = value; OnPropertyChanged(); NotifyAllData(); }
        }
        public double ShapeFactorEta
        {
            get => Forces.ShapeFactorEta;
            set { Forces.ShapeFactorEta = value; OnPropertyChanged(); NotifyAllData(); }
        }
        public double PhiEInput
        {
            get => Forces.PhiEInput;
            set { Forces.PhiEInput = value; OnPropertyChanged(); NotifyAllData(); }
        }
        public int LoadTypeWebIndex
        {
            get => Forces.LoadTypeWebIndex;
            set { Forces.LoadTypeWebIndex = value; OnPropertyChanged(); NotifyAllData(); }
        }
        public int RibLayoutIndex
        {
            get => Forces.RibLayoutIndex;
            set { Forces.RibLayoutIndex = value; OnPropertyChanged(); NotifyAllData(); }
        }
        #endregion

        // Phát tín hiệu làm mới TOÀN BỘ Binding trên giao diện của tất cả các trang
        private void NotifyAllData()
        {
            OnPropertyChanged(string.Empty); // rỗng: Refresh toàn diện dữ liệu đang hiển thị
        }
    }
}