/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run()
    {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: The AddNewCustumer method is adding the data to the queue correctly
        // Expected Result: [size=1 max_size=10 => Josue (1515) : Broke Phone]
        Console.WriteLine("Test 1");
        var cs = new CustomerService(10);
        cs.AddNewCustomer();
        Console.WriteLine(cs);



        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Trying to add another customer. 
        // Expected Result: Maximum Number of Customers in Queue.
        Console.WriteLine("Test 2");
        var test2 = new CustomerService(5);
        test2.AddCustomerForTesting("Karla", "2005", "Broke Phone");
        test2.AddCustomerForTesting("Luis", "2020", "Forgot password");
        test2.AddCustomerForTesting("Ana", "2099", "Screen cracked");
        test2.AddCustomerForTesting("Juan", "2094", "Broke Keyboard");
        test2.AddCustomerForTesting("Ana", "2016", "Mouse click");
        test2.AddNewCustomer();
        // Defect(s) Found: The AddNewCustomer method doesn't add multiple customers. A function that does it was added.
        // The max size condition inside the AddNewCustomer method was wrong, and it was change from: _queue.Count > _maxSize to: _queue.Count >= _maxSize 
        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below

        // Test 3
        // Scenario: Trying to remove a customer from the queue. 
        // Expected Result: Ana (2099)  : Screen cracked
        Console.WriteLine("Test 3");

        test2.ServeCustomer();

        // Defect(s) Found: The parameter of the RemoveAt method was "0", and it was changed to "1"
        //to be able to erase the first index

        Console.WriteLine("=================");

        // Test 4
        // Scenario: Trying to remove a customer from an empty queue. 
        // Expected Result: The queue is empty. There is nothing to erase
        Console.WriteLine("Test 4");

        var test4 = new CustomerService(5);
        test4.ServeCustomer();

        // Defect(s) Found:
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>

    /// The function below is just to test if the size condition of the queue is working
    public void AddCustomerForTesting(string name, string accountId, string problem) {
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Queue is full.");
            return;
        }

        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }
    
    private void AddNewCustomer()
    {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize)
        {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        if (_queue.Count <= 0)
        {
            Console.WriteLine("The queue is empty. There is nothing to erase");
        } else {
            _queue.RemoveAt(1);
            var customer = _queue[1];
            Console.WriteLine(customer);
        }
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}