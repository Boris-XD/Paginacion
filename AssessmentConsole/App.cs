using System;
using System.Linq;
using Assessment;

namespace AssessmentConsole
{
    public class App
    {
        public bool ProcessOption(string option) 
        {
            if (option == "1")
            {
                StartPagination();
                return false;
            }
            return true;
        }

        private void StartPagination()
        {
            string option = GetOption(
                @"Pagination commands\n
                1. Source data
                0. Back
                ");
             if (option == "1")
            {
                ProcessPagination();
            }
        }

        private void ProcessPagination()
        {
            string option = GetOption(
                @"Type: \n
                1. Comma separated data(,)
                2. Pipe separated data(|)
                3. Space separated data( )
                0. Go Back
                ");
            if (option == "1" || option == "2" || option == "3") 
            {
                string data = GetOption("Source data");
                NavigateData(data, option);
            } 
        }

        private void NavigateData(string data, string option)
        {
            string separator = "";
            switch (int.Parse(option))
            {
                case 1:
                    {
                        separator = ","; 
                    }
                    break;
                case 2:
                    {
                        separator = "|";
                    }
                    break;
                case 3:
                    {
                        separator = " ";
                    }
                    break;

            }
            string pageSize = GetOption("Type the Page size");
            IElementsProvider<string> provider = new StringProvider();
            IPagination<string> pagination = new PaginationString(data, int.Parse(pageSize), provider,separator);
            DoNavigation(pagination);
        }

        private void DoNavigation(IPagination<string> pagination)
        {
            bool exit = false;
            while(!exit)
            {
                Console.WriteLine("Current Page:" + pagination);
                 string option = GetOption(
                @"Type: \n
                1. First page
                2. Next page
                3. Previous page
                4. Last page
                5. Go to page
                0. Go Back
                ");
                switch (int.Parse(option))
                {
                    case 1:
                        {
                            pagination.FirstPage();
                        }
                        break;
                    case 2:
                        {
                            pagination.NextPage();
                        }
                        break;
                    case 3:
                        {
                            pagination.PrevPage();
                        }
                        break;
                    case 4:
                        {
                            pagination.LastPage();
                        }
                        break;
                    case 5:
                        {
                            int dato = int.Parse(Console.ReadLine());
                            pagination.GoToPage(dato);
                        }
                        break;
                    case 0:
                        exit = true;
                        break;
                }
            }
    
        }

        

        private string GetOption(string message)
        {
            Console.WriteLine(message);
            Console.Write("> ");
            return Console.ReadLine();
        }
    }
}