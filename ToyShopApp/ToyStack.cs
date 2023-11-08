namespace ToyShop;

public class ToyStack
{

    public ToyStack(int id, string name, int dropRate, int quantity = 1)
    {
        Id = id;
        Name = name;
        Quantity = quantity;
        
        if (dropRate is > 1 and < 100)
        {
            DropRate = dropRate;
        }
        else
        {
            throw new ArgumentOutOfRangeException(paramName: nameof(dropRate), message:"Значение за пределами допустимого диапазона");
        }
    }
    
    public int Id { get; }
    public string Name { get; }
    public int Quantity { get; private set; }
    public int DropRate { get; set; }
    
    public static ToyStack operator + (ToyStack toyStack, int toysNumber)
    {
        toyStack.Quantity += toysNumber;
        return toyStack;
    }

    public static ToyStack operator - (ToyStack toyStack, int toysNumber)
    {
        if (toyStack.Quantity - toysNumber < 0)
        {
            throw new ArgumentOutOfRangeException(paramName: nameof(toysNumber), $"Не хватает игрушек типа {toyStack.Name} для операции.");
            
        }
        toyStack.Quantity -= toysNumber;
        return toyStack;
    }

    public override string ToString() => $"{Id}, {Name}: {Quantity}, шанс: {DropRate}";
}