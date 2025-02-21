﻿using NodeNetwork.ViewModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleCodeGenApp.ViewModels.Nodes
{
    
    public enum NodeType
    {
        EventNode, Function, FlowControl, Literal, Group
    }

    public class CodeGenNodeViewModel : NodeViewModel
    {
        //static CodeGenNodeViewModel()
        //{
        //    Splat.Locator.CurrentMutable.Register(() => new CodeGenNodeView(), typeof(IViewFor<CodeGenNodeViewModel>));
        //}

        public NodeType NodeType { get; }

        public CodeGenNodeViewModel(NodeType type)
        {
            NodeType = type;
        }
    }
}
