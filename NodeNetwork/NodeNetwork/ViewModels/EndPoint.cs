using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeNetwork.ViewModels
{
    public abstract class EndPoint: ReactiveObject
    {

        #region Parent
        /// <summary>
        /// The node that owns this endpoint
        /// </summary>
        public NodeViewModel Parent
        {
            get => _parent;
            internal set => this.RaiseAndSetIfChanged(ref _parent, value);
        }
        private NodeViewModel _parent;
        #endregion
        #region Port
        public PortViewModel Port
        {
            get => _port;
            set => this.RaiseAndSetIfChanged(ref _port, value);
        }
        private PortViewModel _port;
        #endregion
        protected EndPoint() 
        {
            Port = new PortViewModel();

        
        }
    }
}
