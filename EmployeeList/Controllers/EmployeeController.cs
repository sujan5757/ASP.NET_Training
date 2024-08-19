using Microsoft.AspNetCore.Mvc;
 
public class EmployeeController: Controller{
    private static List<Employee> employees=new List<Employee>(){
new Employee{EmpId=1,EmpName="Sujan",EmpEmail="Sujan@gmail.com",EmpPhNumber=63625676,EMpCity="Chikkamagluru",EmpAddress="Somewhere in Hills",EmpDob=new DateTime(2003,09,12)},
new Employee{EmpId=2,EmpName="Jayanth",EmpEmail="Jayanth@gmail.com",EmpPhNumber=63625676,EMpCity="Hyderbad",EmpAddress="Telangana",EmpDob=new DateTime(2003,09,12)},
new Employee{EmpId=3,EmpName="Daniel",EmpEmail="Daniel@gmail.com",EmpPhNumber=63625676,EMpCity="Mangalore",EmpAddress="GanjiMata",EmpDob=new DateTime(2003,09,14)}
    };
   
    public ActionResult List(){
        return View(employees);
    }

    
    [HttpGet]
    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Employee employee)
    {
        employees.Add(employee);
        return View("List", employees);
    }

    
 [HttpGet]
    public ActionResult Edit(int id)
    {
        var employee=employees.Where(p=>p.EmpId==id).FirstOrDefault();
        return View(employee);
    }
    [HttpPost]
    public ActionResult Edit(Employee employee)
    {
        var Empl=employees.Where(p=>p.EmpId==employee.EmpId).FirstOrDefault();
        Empl.EmpName=employee.EmpName;
        Empl.EmpEmail=employee.EmpEmail;
        Empl.EmpPhNumber=employee.EmpPhNumber;
        Empl.EMpCity=employee.EMpCity;
        Empl.EmpAddress=employee.EmpAddress;
        Empl.EmpDob=employee.EmpDob;
        return View("List", employees);
    }

     
 [HttpGet]
    public ActionResult Delete(int id)
    {
        var employee = employees.Where(p => p.EmpId == id).FirstOrDefault();
            employees.Remove(employee);
        return View("List", employees);
    }

}