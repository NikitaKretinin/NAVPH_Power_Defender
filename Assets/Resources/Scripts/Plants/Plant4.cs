public class Plant4 : IPlant
{
    public int Amount { get; set; }
    public int RipeTime { get; set; } = 3;

    public int ImageIndex => 52;

    public Plant4(int initialAmount = 0)
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
