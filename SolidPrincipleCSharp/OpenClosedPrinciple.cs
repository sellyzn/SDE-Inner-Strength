using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrincipleCSharp
{
    // OCP: a class should be open to extention but closed to modification.
    internal class OpenClosedPrinciple
    {
        public string ReportType { get; set; }
        public void GenerateReport()
        {
            if(ReportType == "StockInformation")
            {
                // stock information report generation
            }
            if(ReportType == "ProductInformation")
            {
                // Product information report generation
            }
            
        }
    }

    //                 ||
    //                \||/
    //                 \/

    public class ReportGenerator
    {
        public virtual void GenerateReport()
        {
            // take the Employee class and based on the properties it will functions.
        }
    }
    public class StockInformationReport : ReportGenerator
    {
        public override void GenerateReport()
        {
            // Generate Stock Infomation Report
        }
    }
    public class ProductInformationReport : ReportGenerator
    {
        public override void GenerateReport()
        {
            // Generate Product Infomation Report
        }
    }


    ///////////////////////////////////
    // 抽象化，定义成interface/父类，当再次进行扩展时，需要新建一个类即可。
    

    public interface IShape
    {
        public float GetArea();
    }
    public class Triangle : IShape
    {
        public int b;
        public int h;
        public float GetArea()
        {
            return b * h / 2;
        }
    }
    public class AreaCalculator
    {
        private float result;
        private float GetResult()
        {
            return this.result;
        }
        public float CalculateArea(IShape s)
        {
            return this.result = s.GetArea();
        }
    }





}
