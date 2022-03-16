using session4.Model;
using session4.ViewModel.Base;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;

namespace session4.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private ObservableCollection<dpd> _panel = new ObservableCollection<dpd>();
        public ObservableCollection<dpd> Panel 
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

        private ObservableCollection<string> _imagesURL = new ObservableCollection<string>();
        public ObservableCollection<string> ImagesURL
        {
            get { return _imagesURL; }
            set => Set(_imagesURL, value);
        }

        private ObservableCollection<string> _filterList = new ObservableCollection<string>();
        public ObservableCollection <string> FilterList
        {
            get { return _filterList; }
            set => Set(_filterList, value);
        }

        public MainWindowViewModel()
        {
            
            using (session4DBContext context = new session4DBContext())
            {
                
                
                foreach(var x in context.Materials)
                {
                    _materials.Add(x);

                    _imagesURL.Add(@"/Model" + x.UrlImage);

                    dpd y = new dpd();
                    var liststrings = context.MaterialsSuppliers.Where(p => p.Material == x.NameMaterial)
                                                                    .Select(x => x.Supplier)
                                                                    .ToArray();
                    y.FirstField = $"{x.TypeMaterial} | {x.NameMaterial}";
                    y.SecondField = $"Минимальное количество:{x.MinQuantity}";
                    y.ThirdField = $"поставщики: {string.Join(',', liststrings)}";
                    y.FortiethField = $"Остаток: {x.Quantity}";
                    _panel.Add(y);
                     
                    if(_filterList.IndexOf(x.TypeMaterial) == -1)
                    _filterList.Add(x.TypeMaterial);
                }

                

                foreach (var x in context.Suppliers)
                {
                    _supplier.Add(x);
                    
                }
                
                foreach (var x in context.MaterialsSuppliers)
                {
                    _materialsSupplier.Add(x);
                    
                }
                
            }


        }

    }
}
