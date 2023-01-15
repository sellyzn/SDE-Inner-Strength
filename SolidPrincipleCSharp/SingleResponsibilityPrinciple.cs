using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrincipleCSharp
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    // SRP: one class should take one responsibility and there should be one reason to change that class
    internal class SingleResponsibilityPrinciple
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool AddNewEmployee(Employee em)
        {
            return true;
        }
        // one class should take one responsibility
        //public void GenerateEmployeeReport(Employee em)
        //{
        //    // return report data
        //}
    }
    public class ReportGeneration
    {
        public void GenerateEmployeeReport(Employee em)
        {
            // return report data
        }
    }



    //////////////////////////////////////////////////////////

    //public class AreaCalculator
    //{
    //    public float result;
    //    private int h;
    //    private int b;
    //    public float GetResult()
    //    {
    //        return this.result;
    //    }
    //    public float CalculateArea(Triangle t)
    //    {
    //        return this.result = h * b / 2;
    //    }
    //    // 此处违反单一责任原则
    //    public void PrintResult()
    //    {
    //        Console.WriteLine(this.result);
    //    }
    //}

    //public class Printer
    //{
    //    public void PrintResult()
    //    {
            
    //        Console.WriteLine(this.result);
    //    }
    //}




}
