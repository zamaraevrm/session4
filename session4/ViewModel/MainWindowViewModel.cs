using session4.Model;
using session4.ViewModel.Base;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using session4.Command;

namespace session4.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private ObservableCollection<MaterialInfo> _panel = new ObservableCollection<MaterialInfo>();
        public ObservableCollection<MaterialInfo> Panel
        {
            get { return _panel; }
            set => Set(_panel, value);
        }

        private ObservableCollection<Material> _materials = new ObservableCollection<Material>();
        public ObservableCollection<Material> Materials
        {
            get { return _materials; }
            set => Set(_materials, value);
        }

        private ObservableCollection<Supplier> _supplier = new ObservableCollection<Supplier>();
        public ObservableCollection<Supplier> Supplier
        {
            get { return _supplier; }
            set => Set(_supplier, value);
        }

        private ObservableCollection<MaterialsSupplier> _materialsSupplier = new ObservableCollection<MaterialsSupplier>();
        public ObservableCollection<MaterialsSupplier> MaterialsSuppliers
        {
            get { return _materialsSupplier; }
            set => Set(_materialsSupplier, value);
        }
              

        private ObservableCollection<string> _filterList = new ObservableCollection<string>();
        public ObservableCollection<string> FilterList
        {
            get { return _filterList; }
            set => Set(_filterList, value);
        }


        private RelayCommand _searchCommand;
        public RelayCommand SearchCommand { get
            {
                return _searchCommand ??
                    (_searchCommand = new RelayCommand(obj =>
                    {

                    }));

            } }

        private RelayCommand _sortCommand;
        public RelayCommand SortCommand {
            get {
                return _sortCommand ??
                  (_sortCommand = new RelayCommand(obj =>
                  {
                        string filterString = obj as string;
                        if (!string.IsNullOrEmpty(filterString)) return;                             
                        if(filterString == "по возрастанию")
                        {
                          _panel = new(_panel.OrderBy(x => x.FortiethField));
                        }
                        else if(filterString == "по убыванию")
                        {
                          _panel = new(_panel.OrderByDescending(x => x.FortiethField));                         
                        }
                      
                  }));
            }
        }

        public List<string> SortList { get; set; } = new List<string>() { "по возрастанию", "по убыванию"};

        public MainWindowViewModel()
        {
            
            using (session4DBContext context = new session4DBContext())
            {


                Materials = new(context.Materials.OrderBy(p => p.Quantity));

                

                foreach (var x in context.Materials.OrderBy(p => p.Quantity))
                {
                    MaterialInfo y = new MaterialInfo();
                    var liststrings = context.MaterialsSuppliers.Where(p => p.Material == x.NameMaterial)
                                                                    .Select(x => x.Supplier)
                                                                    .ToArray();
                    y.FirstField = $"{x.TypeMaterial} | {x.NameMaterial}";
                    y.SecondField = $"Минимальное количество:{x.MinQuantity}";
                    y.ThirdField = $"поставщики: {string.Join(',', liststrings)}";
                    y.FortiethField = x.Quantity;
                    y.URLImage = x.UrlImage;
                    _panel.Add(y);
                    if(FilterList.IndexOf(x.TypeMaterial) == -1)
                    FilterList.Add(x.TypeMaterial);
                }

                

                

                MaterialsSuppliers = new(context.MaterialsSuppliers);

                _panel = new(_panel.OrderByDescending(x => x.FortiethField));

            }


        }

    }
}
