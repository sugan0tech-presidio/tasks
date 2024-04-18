namespace Demo;

class TestBasic
{
    private int[] arr = new int[100];

    public int this[int index]
    {
        get => arr[index];
        set => arr[index] = value;
    }
}

class TestAdd
{
    private int[] arr = new int[100];
    private int nextIndex = 0;
    
    public int this[int index] => arr[index];

    public void Add(int val)
    {
        if (nextIndex == 100)
            throw new IndexOutOfRangeException("it's above 100");
        arr[nextIndex++] = val;
    }
}

public enum Fields
{
    Name,
    Group,
    Phone
    
}

class JsLike
{
    private string name;
    private string group;
    private string phone;

    public JsLike(string name, string group, string phone)
    {
        this.name = name;
        this.group = group;
        this.phone = phone;
    }

    public string this[Fields field]
    {
        get
        {
            switch (field)
            {
                case Fields.Name :
                    return name;
                case Fields.Group :
                    return group;
                case Fields.Phone :
                    return phone;
                default:
                    return null;
            }
        }
    }
}
class PyLike
{
    private string name;
    private string group;
    private string phone;

    public PyLike(string name, string group, string phone)
    {
        this.name = name;
        this.group = group;
        this.phone = phone;
    }

    public string this[string field]
    {
        get
        {
            switch (field)
            {
                case "Name" :
                    return name;
                case "Group" :
                    return group;
                case "Phone" :
                    return phone;
                default:
                    return null;
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        TestBasic testBasic = new TestBasic();
        testBasic[1] = 5;
        Console.WriteLine(testBasic[1]);

        TestAdd testAdd = new TestAdd();
        testAdd.Add(5);
        testAdd.Add(6);
        testAdd.Add(7);
        for (int i = 0; i < 100; i++)
            Console.Write($"{testAdd[i]} ");

        
        JsLike jsLike = new JsLike("sugan", "B", "8877838393");
        Console.WriteLine();
        Console.WriteLine(jsLike[Fields.Group]);
        Console.WriteLine(jsLike[Fields.Name]);
        Console.WriteLine(jsLike[Fields.Phone]);
        
        PyLike pyLike = new PyLike("sugan", "B", "8877838393");
        Console.WriteLine();
        Console.WriteLine(pyLike["group"]);
        Console.WriteLine(pyLike["name"]);
        Console.WriteLine(pyLike["phone"]);
            var val = 0;
            Console.WriteLine(1/val);

            try
            {

                Console.WriteLine(1 / val);
            }
            catch (DivideByZeroException e )
            {

                Console.WriteLine(e);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
    }
}