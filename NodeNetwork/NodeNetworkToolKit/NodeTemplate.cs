using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodeNetwork.ViewModels;

namespace NodeNetworkToolKit
{
    public class NodeTemplate
    {
        //NodeViewModel生成処理
        public Func<NodeViewModel> Factory {  get;}

        //Factoryで作られたインスタンス
        public NodeViewModel Instance { get;}

        public NodeTemplate(Func<NodeViewModel> factory)
        {
            Factory = factory;
            Instance = factory();
        }
    }
}
