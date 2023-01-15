using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrincipleCSharp
{
    // ISP: any client should not be forced to use an interface which is irrelevant to it.
    internal class InterfaceSegregationPrinciple
    {
    }
    public interface IReport
    {
        bool AddReportDetails();
    }
    //show only Stock Related Report
    //Stock
    //Product
    //Sku
    public interface IReportDatabase
    {
        bool AddReportDetails();
        bool ShowReportDetails(int reportId);
    }
    //          ||
    //         \||/
    //          \/
    public interface IAddReport
    {
        bool AddReportDetails();
    }
    public interface IGetReport
    {
        bool ShowReportDetails(int reportId);
    }




    // 不应强迫一个类实现它用不到的接口
    //public abstract class Shape
    //{
    //    abstract public float CalculateVolum();
    //    abstract public float CalculateArea();
    //}

    //public class Rectangle : Shape
    //{
    //    // ... 
    //}
    //public class Cube : Shape
    //{
    //    // ...
    //}
}
