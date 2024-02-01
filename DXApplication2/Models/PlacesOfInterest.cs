using CommunityToolkit.Mvvm.ComponentModel;

namespace DataGridBindingExampleCore.Models
{
    public partial class PlacesOfInterest : ObservableObject
    {
        [ObservableProperty]
        int iD;
        [ObservableProperty]
        int studentID;
        [ObservableProperty]
        string countryName;
        partial void OnCountryNameChanged(string oldValue, string newValue)
        {
            this.ProvinceID = 0;
        }
        [ObservableProperty]
        int provinceID;
        partial void OnProvinceIDChanged(int oldValue, int newValue)
        {
            this.DistrictID = 0;
        }
        [ObservableProperty]
        int districtID;

    }
}
