
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DataGridBindingExampleCore.Models;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Grid;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace DataGridBindingExampleCore
{
    public partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        bool isLoading;

        [ObservableProperty]
        ObservableCollection<StudentsModel> students;
        [ObservableProperty]
        ObservableCollection<CountriesModel> countries;
        [ObservableProperty]
        ObservableCollection<ProvincesModel> provinces;
        [ObservableProperty]
        ObservableCollection<DistrictsModel> districts;
        [ObservableProperty]
        StudentsModel selectedStudent;

        int currentIndex = 0;

        [RelayCommand]
        private void NavigateStudents(string ButtonName)
        {
            switch (ButtonName)
            {
                case "NavigateNextButton":
                    currentIndex = Math.Min(currentIndex + 1, Students.Count - 1);
                    break;
                case "NavigateBeforeButton":
                    currentIndex = Math.Max(currentIndex - 1, 0);
                    break;
                default:
                    break;
            }

            this.SelectedStudent = Students[currentIndex];
        }

        //public ICommand UpdateItemsSourceCommand { get; private set; }


        public MainWindowViewModel()
        {
            ////UpdateItemsSourceCommand = new RelayCommand<EditorEventArgs>(OnTableViewShownEditor);

            LoadDataAsync();
        }

        private async void LoadDataAsync()
        {
            IsLoading = true;

            this.Students = new ObservableCollection<StudentsModel>(await DAL.LoadStudentsAsync());
            this.Countries = new ObservableCollection<CountriesModel>(await DAL.LoadCountriesAsync());
            this.Provinces = new ObservableCollection<ProvincesModel>(await DAL.LoadProvincesAsync());
            this.Districts = new ObservableCollection<DistrictsModel>(await DAL.LoadDistrictsAsync());

            this.SelectedStudent = Students.FirstOrDefault();
            OnPropertyChanged(nameof(SelectedStudent));

            IsLoading = false;
        }



        //private void OnTableViewShownEditor(EditorEventArgs e)
        //{
        //    if (e.Column.FieldName == "ProvinceID")
        //    {
        //        LookUpEditBase editor = e.Editor as LookUpEditBase;
        //        if (editor == null)
        //            return;
        //        TableView view = (TableView)e.Source;
        //        string countryName = (string)view.Grid.GetCellValue(e.RowHandle, "CountryName");
        //        editor.ItemsSource = Provinces.Where(province => province.CountryName == countryName).ToList();
        //    }
        //    else if (e.Column.FieldName == "DistrictID")
        //    {
        //        LookUpEditBase editor = e.Editor as LookUpEditBase;
        //        if (editor == null)
        //            return;
        //        TableView view = (TableView)e.Source;
        //        int provinceID = (int)view.Grid.GetCellValue(e.RowHandle, "ProvinceID");
        //        editor.ItemsSource = Districts.Where(district => district.ProvinceID == provinceID).ToList();
        //    }
        //}


    }

}
