
Car car4 = new Car
{
    CarName = "Breeze",
    CarVariant = "XM",
    CarModel = new DateTime(2021, 1, 1),
    CarPrice = 1000000,
    CarMaking = "Maruti",
    CarColor = "Silver",
    CarRating = 4.2f
};

Car car5 = new Car
{
    CarName = "Altima",
    CarVariant = "SL",
    CarModel = new DateTime(2022, 7, 15),
    CarPrice = 1500000,
    CarMaking = "Nissan",
    CarColor = "Blue",
    CarRating = 4.4f
};

Car car6 = new Car
{
    CarName = "Fortuner",
    CarVariant = "Legender",
    CarModel = new DateTime(2020, 11, 20),
    CarPrice = 3500000,
    CarMaking = "Toyota",
    CarColor = "Grey",
    CarRating = 4.8f
};

car4.Display();
car5.Display();
car6.Display();

// Object initializers
Car car7 = new Car
{
    CarName = "Sonet",
    CarVariant = "XZ",
    CarModel = new DateTime(2021, 12, 28),
    CarPrice = 2500000,
    CarMaking = "Suzuki",
    CarColor = "Red",
    CarRating = 4.9f
};

Car car8 = new Car
{
    CarName = "Kicks",
    CarVariant = "SV",
    CarModel = new DateTime(2022, 3, 10),
    CarPrice = 1800000,
    CarMaking = "Nissan",
    CarColor = "Black",
    CarRating = 4.3f
};

Car car9 = new Car
{
    CarName = "XUV700",
    CarVariant = "AX7",
    CarModel = new DateTime(2021, 8, 25),
    CarPrice = 2900000,
    CarMaking = "Mahindra",
    CarColor = "Blue",
    CarRating = 4.7f
};

car7.Display();
car8.Display();
car9.Display();
