using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.UI.View_Models.Components
{
    public class CmbOption
    {
        public int Value { get; set; }
        public string Label { get; set; }

        public override string ToString()
        {
            return Label;
        }
    }
}
