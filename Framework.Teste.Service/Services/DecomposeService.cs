using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework.Teste.Entities.Dtos;
using Framework.Teste.Service.Interfaces;

namespace Framework.Teste.Service.Services
{
    public class DecomposeService : IDecomposeService
    {
        private const int DecomposeStart = 1;
        private const int DivideByTwo = 2;
        public Task<DecomposeNumbers> DecomposeAsync(int input)
        {
            var dividers = GetDividers(input);
            return Task.FromResult(new DecomposeNumbers
            {
                Input = input,
                Dividers = dividers,
                PrimeDividers = GetPrime(dividers)
            });
        }

        private IEnumerable<int> GetPrime(IList<int> dividers)
        {
            var primeNumbers = new List<int>();
            
            for (var i = 1; i < dividers.Count; i++)
            {
                if (IsPrime(dividers[i], DivideByTwo))
                    primeNumbers.Add(dividers[i]);
            }
            return primeNumbers;
        }

        private bool IsPrime(int number, int divider)
        {
            if (divider == number)
                return true;

            return number % divider != 0 && IsPrime(number, (divider+1));
        }

        private IList<int> GetDividers(int input)
        {
            var decomposeNumbers = new List<int>() {DecomposeStart};
            AddDecomposeNumbers(input, decomposeNumbers,DecomposeStart);
            return CalculeDividers(decomposeNumbers);
        }

        private IList<int> CalculeDividers(List<int> decomposeNumbers)
        {
            var dividers = new List<int>{DecomposeStart};

            for (var i = 1; i < decomposeNumbers.Count; i++)
            {
                var mergeDividers = new List<int>();
                dividers.ForEach(t => { mergeDividers.Add(decomposeNumbers[i] * t); });
                dividers = dividers.Concat(mergeDividers).ToList();
            }
          
            return dividers.Distinct().OrderBy(c=> c).ToList();
        }

        private void AddDecomposeNumbers(int number, IList<int> decomposeNumbers, int previousDevider)
        {
            var nextNumberDivider = NextDivider(number, previousDevider);
            if (nextNumberDivider > number) return;
            
            decomposeNumbers.Add(nextNumberDivider);
            number = number / nextNumberDivider;
            if (number != DecomposeStart)
                AddDecomposeNumbers(number, decomposeNumbers, (number %nextNumberDivider == 0 ? previousDevider : nextNumberDivider));
        }

        private int NextDivider(int number, int divider)
        {
            divider++;
            var rest = number % divider;

            while (rest != 0)
            {
                divider++;
                rest = number % divider;
            }

            return divider;
        }
    }
}