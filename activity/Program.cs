class Program
{
    static List<MenuItem> menu = new List<MenuItem>();
    static List<MenuItem> order = new List<MenuItem>();

    static void Main()
    {
        bool isRunning = true;

        while (isRunning)
        {
            DisplayMainMenu();
            int option = GetMenuOption();

            switch (option)
            {
                case 1:
                    AddMenuItem();
                    break;
                case 2:
                    ViewMenu();
                    break;
                case 3:
                    PlaceOrder();
                    break;
                case 4:
                    ViewOrder();
                    break;
                case 5:
                    CalculateTotal();
                    break;
                case 6:
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void DisplayMainMenu()
    {
        Console.WriteLine("\nWelcome to the Coffee Shop!");
        Console.WriteLine("1. Add Menu Item");
        Console.WriteLine("2. View Menu");
        Console.WriteLine("3. Place Order");
        Console.WriteLine("4. View Order");
        Console.WriteLine("5. Calculate Total");
        Console.WriteLine("6. Exit");
    }

    static int GetMenuOption()
    {
        Console.Write("Select an option: ");
        if (int.TryParse(Console.ReadLine(), out int option))
        {
            return option;
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
            return 0;
        }
    }

    static void AddMenuItem()
    {
        string name = GetItemName();
        double price = GetItemPrice();
        menu.Add(new MenuItem(name, price));
        Console.WriteLine("Item added successfully!");
    }

    static string GetItemName()
    {
        Console.Write("Enter item name: ");
        return Console.ReadLine();
    }

    static double GetItemPrice()
    {
        Console.Write("Enter item price: ");
        if (double.TryParse(Console.ReadLine(), out double price))
        {
            return price;
        }
        else
        {
            Console.WriteLine("Invalid price. Please enter a valid number.");
            return GetItemPrice();
        }
    }

    static void ViewMenu()
    {
        if (menu.Count == 0)
        {
            Console.WriteLine("The menu is currently empty.");
            return;
        }

        Console.WriteLine("Menu:");
        for (int i = 0; i < menu.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {menu[i].Name} - ${menu[i].Price:F2}");
        }
    }

    static void PlaceOrder()
    {
        if (menu.Count == 0)
        {
            Console.WriteLine("The menu is empty. Please add items to the menu first.");
            return;
        }

        ViewMenu();
        int itemNumber = GetOrderItemNumber();

        if (itemNumber > 0 && itemNumber <= menu.Count)
        {
            order.Add(menu[itemNumber - 1]);
            Console.WriteLine("Item added to order!");
        }
        else
        {
            Console.WriteLine("Invalid item number. Please try again.");
        }
    }

    static int GetOrderItemNumber()
    {
        Console.Write("Enter the item number to order: ");
        if (int.TryParse(Console.ReadLine(), out int itemNumber))
        {
            return itemNumber;
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
            return GetOrderItemNumber();
        }
    }

    static void ViewOrder()
    {
        if (order.Count == 0)
        {
            Console.WriteLine("No items in the order.");
            return;
        }

        Console.WriteLine("Your Order:");
        foreach (var item in order)
        {
            Console.WriteLine($"{item.Name} - ${item.Price:F2}");
        }
    }

    static void CalculateTotal()
    {
        double total = 0;
        foreach (var item in order)
        {
            total += item.Price;
        }
        Console.WriteLine($"Total Amount Payable: ${total:F2}");
    }
}

class MenuItem
{
    public string Name { get; set; }
    public double Price { get; set; }

    public MenuItem(string name, double price)
    {
        Name = name;
        Price = price;
    }
}
