using System;
using System.Collections.Generic;
using Catrobat_Player.NativeComponent;
using System.Xml.Serialization;

namespace Catrobat.Models.v099
{
    partial class formula : IFormulaTree
    {
        #region NativeComponent
        [XmlIgnore]
        public string VariableValue
        {
            get
            {
                return value;
            }
            set { }
        }

        [XmlIgnore]
        public string VariableType
        {
            get
            {
                return type;
            }
            set { }
        }

        [XmlIgnore]
        public IFormulaTree LeftChild
        {
            get
            {
                return leftChild;
            }
            set { }
        }

        [XmlIgnore]
        public IFormulaTree RightChild
        {
            get
            {
                return rightChild;
            }
            set { }
        }
        #endregion
    }
}
