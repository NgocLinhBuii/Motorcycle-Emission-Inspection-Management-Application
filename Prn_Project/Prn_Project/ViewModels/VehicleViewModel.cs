using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Prn_Project.Models;
using System.Linq;

namespace Prn_Project.ViewModels
{
    public class VehicleViewModel : INotifyPropertyChanged
    {
        private EmissionInspectionContext _context;

        public VehicleViewModel()
        {
            _context = new EmissionInspectionContext();
            LoadVehicles();
            AddVehicleCommand = new RelayCommand(AddVehicle);
        }

        // Danh sách phương tiện (hiển thị lên View)
        public ObservableCollection<Vehicle> Vehicles { get; set; } = new ObservableCollection<Vehicle>();

        // Thuộc tính để binding từ View (textbox nhập liệu)
        private string _plateNumber;
        public string PlateNumber
        {
            get => _plateNumber;
            set { _plateNumber = value; OnPropertyChanged(); }
        }

        private string _brand;
        public string Brand
        {
            get => _brand;
            set { _brand = value; OnPropertyChanged(); }
        }

        // Command để xử lý sự kiện nút "Thêm xe"
        public ICommand AddVehicleCommand { get; set; }

        private void LoadVehicles()
        {
            var vehicles = _context.Vehicles.ToList();
            Vehicles.Clear();
            foreach (var v in vehicles)
            {
                Vehicles.Add(v);
            }
        }

        private void AddVehicle()
        {
            var newVehicle = new Vehicle
            {
                PlateNumber = PlateNumber,
                Brand = Brand,
                OwnerId = 1 // hardcoded, sau này sẽ dùng session đăng nhập
            };

            _context.Vehicles.Add(newVehicle);
            _context.SaveChanges();

            Vehicles.Add(newVehicle); // Cập nhật UI
        }

        // Notify UI khi có thay đổi
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
