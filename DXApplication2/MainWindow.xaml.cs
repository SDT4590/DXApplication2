using DataGridBindingExampleCore;
using DataGridBindingExampleCore.Models;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Grid;
using System.Linq;
using System.Windows;

namespace DXApplication2
{
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }



        MainWindowViewModel viewModel = new MainWindowViewModel();

        private void OnTableViewShownEditor(object sender, EditorEventArgs e)
        {
            if (e.Column.FieldName == "ProvinceID" & viewModel.Provinces != null)
            {
                LookUpEditBase editor = e.Editor as LookUpEditBase;
                if (editor == null)
                    return;
                TableView view = (TableView)e.Source;
                string countryName = (string)view.Grid.GetCellValue(e.RowHandle, "CountryName");
                editor.ItemsSource = viewModel.Provinces.Where(province => province.CountryName == countryName).ToList();
            }
            else if (e.Column.FieldName == "DistrictID" & viewModel.Districts != null)
            {
                LookUpEditBase editor = e.Editor as LookUpEditBase;
                if (editor == null)
                    return;
                TableView view = (TableView)e.Source;
                int provinceID = (int)view.Grid.GetCellValue(e.RowHandle, "ProvinceID");
                editor.ItemsSource = viewModel.Districts.Where(district => district.ProvinceID == provinceID).ToList();
            }

        }

    }
}
