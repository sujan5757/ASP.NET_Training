using System;
public class Product{
    #region fields
    //public int TestId;
    private int id;
    // private string name;
    // private int price;
    #endregion
    #region properties
    public string Name { get; set; }//auto implemented property
    public int Price { get; set; }

    //property
    public int Id { 
        get { return id;}
        set{id=value;}
        }
        #endregion
    #region constructors
    public Product()//default
    {
        
    }
    public Product(int id, string name, int price) {//parameterised
        this.id = id;
        this.Name = name;
        this.Price = price;
    }
    #endregion
    #region methods
    public void Display(){
        Console.WriteLine("Id:{0} Name:{1} Price:{2}",id,Name,Price);
    }
    #endregion
    
}