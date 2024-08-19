int a=10;
Product pen=new Product(1, "pen", 25);//
pen.Display();
Product pencil=new Product(2, "pencil", 5);
pencil.Display();

Product eraser=new Product();//
eraser.Id=3;//set
eraser.Name="erase";
eraser.Price=3;
//eraser.TestId=100;

Console.WriteLine(eraser.Price);

Product sharpner=new Product(){//object initialiser
    Id=4,
    Price=6
};

Product noteBook=new Product();//
noteBook.Id=5;
noteBook.Price=55;
Console.WriteLine($"Id:{{{noteBook.Id}}}");
Console.WriteLine($"Name:{noteBook.Name}");
Console.WriteLine("Name:"+noteBook.Name);
Console.WriteLine("Name:{0}",noteBook.Name);



