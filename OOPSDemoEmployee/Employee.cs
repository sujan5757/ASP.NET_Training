using System;

public class Employee{
#region field
    public int EmployeeId{set;get;}
    public string EmployeeName{set;get;}
    public DateTime DateOfJoin{set;get;}
    public int CTC{set;get;}
    public int DepartmentId{set;get;}
    #endregion
#region constructors
//default constructor
public Employee(){

}
//Parameterized constructor
public Employee(int EmployeeId ,string EmployeeName ,DateTime DateOfJoin ,int CTC,int DepartmentId){
    this.EmployeeId=EmployeeId;
    this.EmployeeName=EmployeeName;
    this.DateOfJoin=DateOfJoin;
    this.CTC=CTC;
    this.DepartmentId=DepartmentId;

}
#endregion


#region display
public void Display(){
    Console.WriteLine(
        "EmployeeId:{0}EmployeeName:{1}DateOfJoin:{2}CTC:{3}DepartmentId:{4}",EmployeeId,EmployeeName,DateOfJoin ,CTC,DepartmentId);
}
#endregion
}

