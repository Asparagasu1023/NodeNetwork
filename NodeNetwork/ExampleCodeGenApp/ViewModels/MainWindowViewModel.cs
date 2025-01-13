using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodeNetworkToolKit.NodeList;
using ExampleCodeGenApp.ViewModels.Nodes;

namespace ExampleCodeGenApp.ViewModels
{
    public class MainWindowViewModel: ReactiveObject
    {
        public NodeListViewModel NodeList { get; } = new NodeListViewModel();

        public MainWindowViewModel()
        {
            //NodeListにノードのfactoryを追加する
            NodeList.AddNodeType(() => new PrintNode());

        }
    }
}
