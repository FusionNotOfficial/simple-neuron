using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Neuron neuron = new Neuron();

            /*ConvertDistance(neuron);

            Console.WriteLine($"{ neuron.ProcessInputData(100)} miles in {100} km");
            Console.WriteLine($"{neuron.ProcessInputData(150)} miles in {150} km");
            Console.WriteLine($"{neuron.ProcessInputData(357)} miles in {357} km");
            Console.WriteLine($"{neuron.RestoreInputData(20)} km in {20} miles");*/

            /*ConvertCurrency(neuron);
            Console.WriteLine($"{neuron.ProcessInputData(100)} yen in {100} dollars");
            Console.WriteLine($"{neuron.ProcessInputData(150)} yen in {150} dollars");
            Console.WriteLine($"{neuron.ProcessInputData(3570)} yen in {3570} dollars");
            Console.WriteLine($"{neuron.RestoreInputData(20)} dollars in {20} yen");*/

            ConvertSeconds(neuron);
            Console.WriteLine($"{neuron.ProcessInputData(100)} seconds in {100} hours");
            Console.WriteLine($"{neuron.ProcessInputData(7)} seconds in {7} hours");
            Console.WriteLine($"{neuron.ProcessInputData(3570)} seconds in {3570} hours");
            Console.WriteLine($"{neuron.RestoreInputData(20)} hours in {20} seconds");

            Console.Read();
        }
        private static void ConvertDistance(Neuron neuron)
        {
            decimal inputValue = 100;
            decimal expectedValue = 62.1371m;
            TrainNeuron(neuron, inputValue, expectedValue);
        }
        private static void ConvertCurrency(Neuron neuron)
        {
            decimal inputValue = 1;
            decimal expectedValue = 149.04m;
            TrainNeuron(neuron, inputValue, expectedValue);
        }

        private static void ConvertSeconds(Neuron neuron)
        {
            decimal inputValue = 1;
            decimal expectedValue = 3600;
            TrainNeuron(neuron, inputValue, expectedValue);
        }

        private static void TrainNeuron(Neuron neuron, decimal inputValue, decimal expectedValue)
        {
            int i = 0;
            do
            {
                ++i;
                neuron.Train(inputValue, expectedValue);
                Console.WriteLine($"Iteration: {i}.\tError:\t{neuron.LastError}");

            } while (neuron.LastError > neuron.Smoothing || neuron.LastError < -neuron.Smoothing);

            Console.WriteLine("Training is complete!");
        }
    }
}
