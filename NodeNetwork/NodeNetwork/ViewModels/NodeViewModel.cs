using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeNetwork.ViewModels
{
    public class NodeViewModel : ReactiveObject
    {
        public string Name
        {
            get => _name; 
            set =>this.RaiseAndSetIfChanged(ref _name, value);   
        }
        private string _name;
    }
}
