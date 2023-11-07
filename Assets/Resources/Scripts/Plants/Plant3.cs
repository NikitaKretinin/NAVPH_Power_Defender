public class Plant3 : IPlant
{
    public int Amount { get; set; }
    public int RipeTime { get; set; } = 2;

    public int ImageIndex => 55;

    public Plant3(int initialAmount = 0)
    {
        Amount = initialAmount;
    }

    public void AddToInventory()
    {
        Amount += 1;
    }

    public bool Consume()
    {
        if (Amount > 0)
        {
            Amount -= 1;
            return true;
        }
        else
        {
            return false;
        }
    }
}
