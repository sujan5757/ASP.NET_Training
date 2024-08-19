using System;

public class Car
{
    #region field
    public string CarName { get; set; }
    public string CarVariant { get; set; }
    public DateTime CarModel { get; set; }
    public int CarPrice { get; set; }
    public string CarMaking { get; set; }
    public string CarColor { get; set; }
    public float CarRating { get; set; }
    #endregion

    #region Constructor
    public Car() { }

    public Car(string carName, string carVariant, DateTime carModel, int carPrice, string carMaking, string carColor, float carRating)
    {
        this.CarName = carName;
        this.CarVariant = carVariant;
        this.CarModel = carModel;
        this.CarPrice = carPrice;
        this.CarMaking = carMaking;
        this.CarColor = carColor;
        this.CarRating = carRating;
    }
    #endregion

    #region Display
    public void Display()
    {
        Console.WriteLine($"CarName: {CarName}, CarVariant: {CarVariant}, CarModel: {CarModel.ToShortDateString()}, CarPrice: {CarPrice}, CarMaking: {CarMaking}, CarColor: {CarColor}, CarRating: {CarRating}");
    }
    #endregion
}
