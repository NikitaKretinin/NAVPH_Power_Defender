public class Plant2 : IPlant
{
    public int Amount { get; set; }
    public int RipeTime { get; set; } = 5;

    public int ImageIndex => 56;

    public Plant2(int initialAmount = 0)
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
