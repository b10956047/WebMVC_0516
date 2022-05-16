using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC_0516.Models
{
    public interface IBaseData
    {
        bool isDelete { get; set; }

        DateTime creDateTime { get; set; }

        DateTime updateDateTime { get; set; }
    }
}
