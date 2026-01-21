
class Program
{
    private class ListTask
    {
        private readonly List<int> _listOfInt = new List<int>();

        public void TaskLoop()
        {
            Console.WriteLine("TaskLoop in ListTask");
            foreach (var item in _listOfInt)
            {
                Console.WriteLine(item);
            }
            string enter = "";
            while (enter != "-exit")
            {
                Console.WriteLine("Enter a number. For exit enter -exit. To add to the middle of the list enter -mid");
                enter = Console.ReadLine();
                if (enter == "-exit")
                {
                    Console.WriteLine("exit form task 1");
                    break;
                }
                else if (enter == "-mid")
                {
                    Console.WriteLine("Enter a number");
                    if (int.TryParse(Console.ReadLine(), out int res))
                    {
                        _listOfInt.Insert(_listOfInt.Count / 2, res);
                        Console.WriteLine("{0} added to the middle of the list");
                    }
                    else
                    {
                        Console.WriteLine("Not a number! Try again!");
                    }
                }
                if (int.TryParse(enter, out int result))
                {
                    _listOfInt.Add(result);
                }
                else
                {
                    Console.WriteLine("Not a number! Try again!");
                }
                Console.WriteLine("Current List:");
                foreach (var item in _listOfInt)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public ListTask()
        {
            
        }

        public ListTask(int[] arrInt)
        {
            _listOfInt = new List<int>(arrInt);
        }
    }

    private class DictionaryTask
    {
        private readonly Dictionary<string, float> _dictionary;

        public void TaskLoop()
        {
            Console.WriteLine("TaskLoop in DictionaryTask");
            string enter = "";
            while (enter != "-exit")
            {
                Console.WriteLine("Enter Name. For find Name enter -find. For exit enter -exit. To print all items enter -show");
                enter = Console.ReadLine();
                if (enter == "-exit")
                {
                    Console.WriteLine("exit form task 2");
                    break;
                }
                else if (enter == "-find")
                {
                    Console.WriteLine("Enter name for searching");
                    string name = Console.ReadLine();
                    if (_dictionary.TryGetValue(name, out float result))
                    {
                        Console.WriteLine("{0} has {1} average rate", name, result);
                    }
                    else
                    {
                        Console.WriteLine("Name not found");
                    }
                }
                else if (enter == "-show")
                {
                    foreach (var item in _dictionary)
                    {
                        Console.WriteLine("{0} : {1}", item.Key, item.Value);
                    }
                }
                else
                {
                    //Console.WriteLine("Enter name to add in database");
                    //string name = Console.ReadLine();
                    if (_dictionary.ContainsKey(enter))
                    {
                        Console.WriteLine("Name {0} already exists in database. Enter number for overwriting rate. Use ',' as decimal separator (e.g. 1,5). Enter -exit to exit", enter);
                        string enterExists = Console.ReadLine();
                        if (enterExists == "-exit")
                        {
                            continue;
                        }
                        else
                        {
                            EnterRate(enter, enterExists, _dictionary);
                            continue;
                        }
                    }
                    Console.WriteLine("Enter avg. rate for {0} to add in database. Use ',' as decimal separator (e.g. 1,5)", enter);
                    EnterRate(enter, Console.ReadLine(), _dictionary);
                }

            }
        }


        public DictionaryTask()
        {
            _dictionary = new Dictionary<string, float>();
        }

        public DictionaryTask(Dictionary<string, float> dictionary)
        {
            _dictionary = dictionary;
        }
    }


    private class LinkedListTask
    {
        private class Node
        {

        }

        public void TaskLoop()
        {
            Console.WriteLine("TaskLoop in LinkedListTask");
        }


    }

    public static void EnterRate(string name, string rate, Dictionary<string, float> dictionary)
    {
        
        if (float.TryParse(rate, out float result))
        {
            if (result > 1 && result <= 5)
            {
                dictionary[name] = result;
                Console.WriteLine("{0} with {1} avg. rate added in database", name, result);
            }
            else
            {
                Console.WriteLine("Incorrect rate (must be in 2..5)");
            }
        }
        else
        {
            Console.WriteLine("Incorrect input for avg. rate");
        }
    }


    static void Main(string[] args)
    {
        
        string enter = "";
        while (enter != "-exit")
        {
            Console.WriteLine("choose task. enter 1, 2 or 3. For exit enter -exit");
            enter = Console.ReadLine();
            int taskNumber = int.Parse(enter);
            if (taskNumber == 1)
            {
                //int[] arrInt = [1, 2, 3];
                //var listTask = new ListTask(arrInt);
                var listTask = new ListTask();
                listTask.TaskLoop();
            }
            else if (taskNumber == 2)
            {
                //var initDict = new Dictionary<string, float>() { { "Paul", 3.1f }, { "Daria", 4.2f } };
                //var dictionaryTask = new DictionaryTask(initDict);
                var dictionaryTask = new DictionaryTask();
                dictionaryTask.TaskLoop();
            }
            else if (taskNumber == 3)
            {
                var linkedListTask = new LinkedListTask();
                linkedListTask.TaskLoop();
            }
            else
            {
                Console.WriteLine("Incorrect enter. Try again!");
            }
        }
        

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }


}