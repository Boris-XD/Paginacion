using System.Collections.Generic;

namespace Assessment
{
    public class StringProvider : IElementsProvider<string>
    {
        //private readonly string separator = ",";


        public IEnumerable<string> ProcessData(string source, string separador)
        {
            return source.Split(separador);
        }
    }
}