using System;
using System.Collections;
using System.Collections.Generic;

namespace VitApp
{
    public class DumbScanner : IScanner, IEnumerable
    {
        private readonly float _Step;
        private readonly List<VariableRange> _Variables;

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _Variables.GetEnumerator();
        }

        public void Add(VariableRange variable)
        {
            _Variables.Add(variable);
        }

        public void Add(string name, float min, float max)
        {
            _Variables.Add(new VariableRange()
            {
                Name = name,
                Min = min,
                Max = max
            });
        }

        private void Traverse(List<Variable> values , Action<Variable[]> calculate)
        {
            var variable = _Variables[values.Count ];
            for (var value = variable.Min; value <= variable.Max; value += _Step)
            {
                var list = new List<Variable>(values);
                list.Add(new Variable()
                {
                    Name = _Variables[values.Count].Name,
                    Value = value
                });

                if (list.Count < _Variables.Count)
                {
                    Traverse(list, calculate);
                }
                else
                {
                    calculate(list.ToArray());
                }
            }
        }

        void IScanner.Run(Action<Variable[]> calculate)
        {
            Traverse(new List<Variable>(), calculate);
        }

        public DumbScanner(float step)
        {
            _Variables = new List<VariableRange>();
            _Step = step;
        }
    }
}
