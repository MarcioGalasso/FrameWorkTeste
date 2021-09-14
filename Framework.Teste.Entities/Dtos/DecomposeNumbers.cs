using System.Collections;
using System.Collections.Generic;

namespace Framework.Teste.Entities.Dtos
{
    public class DecomposeNumbers
    {
        public int Input { get; set; }
        public IEnumerable<int>  Dividers{ get; set; }
        public IEnumerable<int>  PrimeDividers{ get; set; }
    }
}