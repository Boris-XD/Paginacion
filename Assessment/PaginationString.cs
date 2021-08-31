using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assessment
{
    public class PaginationString : IPagination<string>
    {
        private readonly IEnumerable<string> data;
        private readonly int pageSize;
        private int currentPage;
        private int cantidadPaginas;

        public PaginationString(string source, int pageSize, IElementsProvider<string> provider, string separator)
        {
            data = provider.ProcessData(source, separator);
            currentPage = 1;
            this.pageSize = pageSize;
            this.cantidadPaginas = Pages();
        }
        public void FirstPage()
        {
            currentPage = 1;
            System.Console.WriteLine(getPageValue(CurrentPage()));
        }

        public void GoToPage(int page)
        {

            if (page <= cantidadPaginas && page > 0)
            {
                currentPage = page;
                System.Console.WriteLine(getPageValue(CurrentPage()));
            }
        }

        public void LastPage()
        {
            currentPage=Pages();
            System.Console.WriteLine(getPageValue(CurrentPage()));
        }

        public void NextPage()
        {
            currentPage++;
            if (currentPage > Pages())
            {
                currentPage--;
            }
            else
            {
                System.Console.WriteLine(getPageValue(CurrentPage()));
            }
        }

        public void PrevPage()
        {
            
            currentPage--;
            if (currentPage!=0)
            {
                System.Console.WriteLine(getPageValue(CurrentPage()));
            }
            else
            {
                currentPage++;
                System.Console.WriteLine("No existe una pagina previa.");
            }
        }

        public IEnumerable<string> GetVisibleItems()
        {
            return data.Skip(currentPage*pageSize).Take(5);
        }

        public int CurrentPage()
        {
            return currentPage;
        }
        //Retorna el numero de paginas
        public int Pages()
        {
            int cantidad= data.Count() / pageSize;
            double cantidadDecimal = data.Count() % pageSize;
            if (cantidadDecimal > 0)
            {
                cantidad++;
            }
            return cantidad;
        }
        //Mostrar datos
        

        public string getPageValue(int pageSearch)
        {
            int indiceInicial = (pageSearch*pageSize)-pageSize;
            int indiceFinal = indiceInicial + pageSize-1;

            StringBuilder texto = new StringBuilder();

            string[] arrarStr = data.ToArray();
            if(indiceFinal > (arrarStr.Length-1))
            {
                indiceFinal = arrarStr.Length - 1;
            }

            for (int i = indiceInicial; i <= indiceFinal; i++)
            {
                texto.AppendLine(arrarStr[i]);
            }

            return texto.ToString();
        }

    }
}