public class Plant1 : IPlant
{
    public int Amount { get; set; }
    public int RipeTime { get; set; } = 6;

    public int ImageIndex => 67;

    public Plant1(int initialAmount = 1)
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
