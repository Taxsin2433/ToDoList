using System;
namespace ToDolist 
{
  public  class ToDoList
    {


        
        static void Main()
        {
            Choosen();
            while (true)
            {
                Console.Write("Choose command ");
                string Choosen = Console.ReadLine();
                
                switch (Choosen)
                {
                    case "1":
                        AddItem();
                        break;

                    case "2":
                        RemoveItem();
                        break;

                    case "3":
                        MarkItem();
                        break;

                    case "4":
                        ShowItems();
                        break;

                    case "5":
                        ExitToMain();
                        return;

                    default:
                        ExitToMain();
                        return;
                }
            }
        }
         static void Choosen()
         {

            
            Console.WriteLine("Write 1 - if you want to add new item.");
            Console.WriteLine("Write 2 - if you want to remove item.");
            Console.WriteLine("Write 3 - if you want to mark item.");
            Console.WriteLine("Write 4 - if you want to show your ToDo list.");
            Console.WriteLine("Write 5 - if you want to leave.");
            
         }

    static void AddItem()
    {
        Console.Write("Please, write new ToDo item: ");
            string newItem = Console.ReadLine();
            if (!toDoItems.ContainsKey(newItem))
            {
                toDoItems.Add(newItem, false);
                Console.WriteLine($"Added to list - {newItem}");
            }
            else
            {
                Console.WriteLine("This item was added before");
            }

    }



        static void RemoveItem()
        {
            Console.Write("Please, write item to remove,  enter * to clear all items list ");
            string itemToRemove = Console.ReadLine();
            if (toDoItems.ContainsKey(itemToRemove))
            {
                toDoItems.Remove(itemToRemove);
            }
            else if (itemToRemove == "*")
            {
                toDoItems.Clear();
            }
            else
            {
                Console.WriteLine("Don't have item in list");
            }
        }

        /*{for (int i = 0; i < toDoItems.Count; i++) 
                {
                  string numbertask = Convert.ToInt32(Console.WriteLine(i + " : " + toDoItems[i]));
                }*/



        static void MarkItem()
    {
            Console.Write("Mark the item, write your item: ");
            string itemMark = Console.ReadLine();
           
            if (toDoItems.ContainsKey(itemMark))
            {
                Console.WriteLine("Write 1 to done task \n Write 2 to false");
                Console.Write("");
                var status = Convert.ToInt32(Console.ReadLine());
                if (status == 1)
                {
                    toDoItems.Remove(itemMark);
                    DateTime currentDateTime = DateTime.Now;
                    doneItems.Add(itemMark, currentDateTime);
                    Console.WriteLine("OK");
                }
                else if (status == 0) 
                {
                    Console.WriteLine("OK");
                }
                else
                {
                    Console.WriteLine("False");
                }
            }
            else if (doneItems.ContainsKey(itemMark))
            {
                Console.WriteLine("Please, write status for this task - 1 if done, 0 if not done");
                Console.Write("");
                var status = Convert.ToInt32(Console.ReadLine());
                if (status == 1)
                {
                    Console.WriteLine("OK");
                }
                else if (status == 0)
                {
                    doneItems.Remove(itemMark);
                    DateTime currentDateTime = DateTime.Now;
                    toDoItems.Add(itemMark, false);
                    Console.WriteLine("OK");
                }
                else
                {
                    Console.WriteLine("False");
                }
            }
            else 
            {
                Console.WriteLine("False");
            }
    }

    static void ShowItems()
    {
            Console.WriteLine("Write 1 to view complited items\n" +
                "Write 0 uncomplited items\n" +
                "Write Enter to View full list");
          
            string status = Console.ReadLine();

            if (status == "1")
            {

                foreach (KeyValuePair<string, DateTime> toDoTask in doneItems)
                {
                    Console.WriteLine("Item ToDo: {0}, Completed: {1}",
                   toDoTask.Key, toDoTask.Value);
                    
                }

            }
            else if (status == "0")
            {
                foreach (KeyValuePair<string, bool> toDoTask in toDoItems)
                {
                   
                        Console.WriteLine("Item ToDo: {0}, Completed: {1}",
                        toDoTask.Key, toDoTask.Value);
                   
                       
                   
                }
            }
            else
            {

                Console.WriteLine($"Your list : ");
                
                foreach (KeyValuePair<string, bool> toDoTask in toDoItems)
                {
                    Console.WriteLine("Item list: {0}, Completed: {1}",
                    toDoTask.Key, toDoTask.Value);
                }
                foreach (KeyValuePair<string, DateTime> toDoTask in doneItems)
                {
                    Console.WriteLine("Item list: {0}, Completed: {1}",
                    toDoTask.Key, toDoTask.Value);

                }
            }
        }

    static void ExitToMain()
    {
            Console.Clear();
            Console.WriteLine("Press Enter to exit");

    }

        static Dictionary<string, bool> toDoItems = new Dictionary<string, bool>();
        static Dictionary<string, DateTime> doneItems = new Dictionary<string, DateTime>();
    }
}

