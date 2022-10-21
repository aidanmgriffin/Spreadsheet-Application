using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadsheetEngine
{
    abstract class OperatorNode : ExpressionTreeNode
    {
        ExpressionTreeNode Left { get; set; }
        ExpressionTreeNode Right { get; set; }
    }
}
