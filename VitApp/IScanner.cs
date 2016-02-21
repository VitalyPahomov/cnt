using System;

namespace VitApp
{
    public interface IScanner
    {
        void Run(Action<Variable[]> calculate);
    }
}
