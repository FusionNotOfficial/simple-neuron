using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronTest
{
    internal class Neuron
    {
        private decimal weight = 0.5m;
        public decimal LastError { get; private set; }
        public decimal Smoothing { get; set; } = 0.01m;
        public decimal ProcessInputData(decimal input)
        {
            return weight * input;
        }
        public decimal RestoreInputData(decimal output)
        {
            return output / weight;
        }
        public void Train(decimal input, decimal expectedResult)
        {
            var actualResult = weight * input;
            LastError = expectedResult - actualResult;
            var correction = (LastError / actualResult) * Smoothing;
            weight += correction;
        }
    }
}
