using System;
using System.Linq;

abstract class BaseArray
{
    protected int[] data;

    public BaseArray(int[] data)
    {
        this.data = data;
    }

    public abstract void Add(int[] other);  
    public abstract void Process();         

    public void Print()
    {
        Console.WriteLine(string.Join(", ", data));
    }
}

class SortArray : BaseArray
{
    public SortArray(int[] data) : base(data) { }

    public override void Add(int[] other)
    {
        data = data.Union(other).ToArray();  
    }

    public override void Process()
    {
        Array.Sort(data);  
    }
}

class XorArray : BaseArray
{
    public XorArray(int[] data) : base(data) { }

    public override void Add(int[] other)
    {
        data = data.Zip(other, (a, b) => a ^ b).ToArray();  
    }

    public override void Process()
    {
        data = data.Select(x => (int)Math.Sqrt(x)).ToArray();  
    }
}

class Program
{
    static void Main()
    {
        int[] arr1 = { 1, 2, 3, 4, 5 };
        int[] arr2 = { 3, 4, 5, 6, 7 };

        Console.WriteLine("=== SortArray ===");
        SortArray sorted = new SortArray(arr1);
        sorted.Add(arr2);
        sorted.Process();
        sorted.Print();

        Console.WriteLine("\n=== XorArray ===");
        XorArray xorArr = new XorArray(arr1);
        xorArr.Add(arr2);
        xorArr.Process();
        xorArr.Print();
    }
}


