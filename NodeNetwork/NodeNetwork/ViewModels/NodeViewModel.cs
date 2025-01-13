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
        #region Parent
        /// <summary>
        /// The network that contains this node
        /// </summary>
        public NetworkViewModel Parent
        {
            get => _parent;
            internal set => this.RaiseAndSetIfChanged(ref _parent, value);
        }
        private NetworkViewModel _parent;
        #endregion
        public string Name
        {
            get => _name; 
            set =>this.RaiseAndSetIfChanged(ref _name, value);   
        }
        private string _name;
    }
}
