internal class Program
{
    private static void Main(string[] args)
    {

        int eleCharge;
        float TotalAmount = 0f;
        Console.WriteLine("ENter the number of units Consume");
        eleCharge = Convert.ToInt32(Console.ReadLine());

        if (eleCharge <= 100)
        {
            TotalAmount = eleCharge * 0;
        }
        else if (eleCharge > 100 && eleCharge <= 200)
        {
            eleCharge -= 100;
            TotalAmount = (eleCharge * 1.5f) + 20;
        }
        else if (eleCharge > 200 && eleCharge <= 500)
        {
            eleCharge -= 200;
            TotalAmount = (100 * 2);
            TotalAmount = (float)(TotalAmount + (eleCharge * 3) + 30);
        }
        else if (eleCharge > 500)
        {
            eleCharge -= 500;
            TotalAmount = (float)((eleCharge * 3.5) + (300 * 4.6));
            TotalAmount = (float)(TotalAmount + (eleCharge * 6.6) + 50);

        }
        Console.WriteLine("Total Amount" + TotalAmount);

    }
}