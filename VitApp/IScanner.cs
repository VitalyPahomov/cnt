using System;

namespace Milk_factory
{
    public interface IScanner
    {
        void Run(Action<Variable[]> calculate);
    }
}
