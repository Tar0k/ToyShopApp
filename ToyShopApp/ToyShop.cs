namespace ToyShopApp;

public class ToyShop
{
    public readonly Stock Stock = new();
    public readonly Victorina Victorina;

    public ToyShop()
    {
        Victorina = new Victorina(Stock);
    }
    
}