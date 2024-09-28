/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: Add someone then serve them
        // Expected Result: Error message
        ///Console.WriteLine("Test 1");
        Console.WriteLine("How big do you want the queue?");
        string queue_size = Console.ReadLine();
        int queue_size_int = int.Parse(queue_size);

    
        var service = new CustomerService(queue_size_int);
        service.AddNewCustomer();
        service.ServeCustomer();

        // Defect(s) Found: Needs to display the customer served before deleting

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Properly queues the customers
        // Expected Result: They should be in order
        Console.WriteLine("Test 2");
        service = new CustomerService(queue_size_int);
        service.AddNewCustomer();
        service.AddNewCustomer();
        service.AddNewCustomer();
        service.ServeCustomer();
        Console.WriteLine(service);

        // Defect(s) Found: Nothing, just formatting is weird

        Console.WriteLine("=================");

        // Test 3
        // Scenario: Does the max queue size get enforced?
        // Expected Result: This should display an error message when the 3rd one is added
        Console.WriteLine("Test 3");
        service = new CustomerService(queue_size_int);
        var max_size = service._maxSize;
        service.AddNewCustomer();
        service.AddNewCustomer();
        service.AddNewCustomer();
        
        Console.WriteLine(service);
        // Defect(s) Found: I found that I need to do >= instead of > in AddNewCustomer

        // Test 4
        // Scenario: Can I serve a customer if there isnt any?
        // Expected Result: This should display some error message
        Console.WriteLine("Test 4");
        service = new CustomerService(queue_size_int);
        service.ServeCustomer();
        // Defect(s) Found: I need to check the length in serve_customer and display an error message
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
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
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
        if (_queue.Count <= 0) {
            Console.WriteLine("No customers in queue.");
        }
        else{
            var customer = _queue[0];
            _queue.RemoveAt(0);
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