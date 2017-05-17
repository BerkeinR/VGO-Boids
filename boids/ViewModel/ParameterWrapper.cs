using Bindings;
using Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ParameterWrapper
    {
        public Cell<Double> paramContent { get; set; }
        public Double minimum { get; }
        public Double maximum { get; }

        public String id { get; }

        public ParameterWrapper(Cell<Double> paramContent, Double maximum, Double minimum, String Id)
        {
            this.paramContent = paramContent;
            this.maximum = maximum;
            this.minimum = minimum;
            this.id = id;
        }



    }
}
