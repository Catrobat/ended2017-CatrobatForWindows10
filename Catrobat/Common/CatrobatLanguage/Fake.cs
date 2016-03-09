using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    internal class SerializableAttribute : Attribute
    {
    }
}
namespace System.ComponentModel
{
    internal class DesignerCategoryAttribute : Attribute
    {
        public DesignerCategoryAttribute(string _) { }
    }
}
