using Handball.Core;
using Handball.Core.Contracts;
using Handball.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Handball
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();            
        }
    }
}
