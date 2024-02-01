using CommunityToolkit.Mvvm.ComponentModel;

namespace DataGridBindingExampleCore.Models
{
    public partial class CountriesModel : ObservableObject
    {
        [ObservableProperty]
        string countryName;
    }
}
