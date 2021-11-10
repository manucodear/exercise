using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.Exercise.WordProcessor
{
    public interface IProcessor
    {
        string[] Process(ProcessData data);
    }
}
