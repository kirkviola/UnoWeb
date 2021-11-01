using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnoWeb.Models
{
    interface IContainable<T>
    {
        string Container { get; set; }
    }
}
