using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerInDetails.Models
{
    public interface ISimpleModel
    {
        string Value { get; set; }
    }

    public class SimpleModel : ISimpleModel
    {
        public string Value { get; set; }
    }

}
