namespace ToyShop;

public class ToyShop
{
    private readonly List<ToyStack> _toyStacks = new();

    public void Add(string name, int dropRate = 0, int quantity = 1)
    {
        var toyStack = _toyStacks.Find(x => x.Name == name);
        if (toyStack != null)
        {
            toyStack += quantity;
            if (dropRate != 0) toyStack.DropRate = dropRate;
        }
        else
        {
            var maxId = 0; 
            if (_toyStacks.Count > 0)
            {
                maxId = _toyStacks.Max(x => x.Id);
            }
            _toyStacks.Add(new ToyStack(maxId + 1, name, dropRate, quantity));
        }
    }

    public void DropRate(string name, int newDropRate)
    {
        var toyStack = _toyStacks.Find(x => x.Name == name);
        if (toyStack != null)
        {
            toyStack.DropRate = newDropRate;
        }
        else
        {
            throw new ArgumentException($"Игрушка с именем {name} не найдена");
        }
        
    }

    private bool CheckTotalDropRate()
    {
        if (_toyStacks.Count == 0) return false;
        var totalDropRate = _toyStacks.Sum(x => x.DropRate);
        return totalDropRate <= 100;
    }
    
    
    public override string ToString() => string.Join("\n", _toyStacks);
}