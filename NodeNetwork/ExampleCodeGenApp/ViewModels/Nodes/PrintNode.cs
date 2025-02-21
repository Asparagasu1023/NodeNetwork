﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ExampleCodeGenApp.ViewModels.Nodes
{
    public class PrintNode: CodeGenNodeViewModel
    {
        public ValueNodeInputViewModel<ITypedExpression<string>> Text { get; }

        public ValueNodeOutputViewModel<IStatement> Flow { get; }

        public PrintNode() : base(NodeType.Function)
        {
            this.Name = "Print";

            Text = new CodeGenInputViewModel<ITypedExpression<string>>(PortType.String)
            {
                Name = "Text"
            };
            this.Inputs.Add(Text);

            Flow = new CodeGenOutputViewModel<IStatement>(PortType.Execution)
            {
                Name = "",
                Value = this.Text.ValueChanged.Select(stringExpr => new FunctionCall
                {
                    FunctionName = "print",
                    Parameters =
                    {
                        stringExpr ?? new StringLiteral{Value = ""}
                    }
                })
            };
            this.Outputs.Add(Flow);
        }
    }
}
