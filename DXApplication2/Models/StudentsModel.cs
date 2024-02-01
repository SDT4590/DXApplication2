using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace DataGridBindingExampleCore.Models
{
    public partial class StudentsModel : ObservableObject
    {
        [ObservableProperty]
        int studentID;
        [ObservableProperty]
        string studentName;
        [ObservableProperty]
        ObservableCollection<PlacesOfInterest> placesOfInterest;
    }
}
