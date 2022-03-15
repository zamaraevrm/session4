using session4.Model;
using session4.ViewModel.Base;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;

namespace session4.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private ObservableCollection<Material> _materials = new ObservableCollection<Material>();
        public ObservableCollection<Material> Materials 
        { 
            get { return _materials; }
            set => Set(_materials, value);
        }

        private string str = string.Format("{0} | {1}", )


        public MainWindowViewModel()
        {
            using (session4DBContext context = new session4DBContext())
            {
                var list = context.Materials.ToList();
                
                list.ForEach(material => Materials.Add(material));  
            }
        }

    }
}
