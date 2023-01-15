using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrincipleCSharp
{
    // LSP: child class should not break parent class's type definition and behavior.
    // every subclass or derived class should be substitutable for their base or parent class
    internal class LiskovSubstitutionPrinciple
    {
    }
    //public abstract class Reports
    //{
    //    public virtual string GetStockInformationDetails(int reportId)
    //    {
    //        return "Stock Infomation Details";
    //    }
    //    public virtual string GetProductInformationDetails(int reportId)
    //    {
    //        return "Product Infomation Details";
    //    }
    //}
    //public class StockInformation : Reports
    //{
    //    public override string GetStockInformationDetails(int reportId)
    //    {
    //        return "Stock Infomation Details";
    //    }
    //    // May be for contractual employee we do not need to store the details into database.
    //    public override string GetProductInformationDetails(int reportId)
    //    {
    //        return "Product Infomation Details";
    //    }
    //}
    //public class ProductInformation : Reports
    //{
    //    public override string GetStockInformationDetails(int reportId)
    //    {
    //        return "Stock Infomation Details";
    //    }        
    //    public override string GetProductInformationDetails(int reportId)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}



    public abstract class Reports
    {
        public virtual string GetStockInformationDetails(int reportId)
        {
            return "Stock Infomation Details";
        }
        public virtual string GetProductInformationDetails(int reportId)
        {
            return "Product Infomation Details";
        }
    }
    public class StockInformation : Reports
    {
        public override string GetStockInformationDetails(int reportId)
        {
            return "Stock Infomation Details";
        }
        // May be for contractual employee we do not need to store the details into database.
        public override string GetProductInformationDetails(int reportId)
        {
            return "Product Infomation Details";
        }
    }
    public class ProductInformation : IStockInformation
    {
        public string GetStockInformationDetails(int reportId)
        {
            throw new NotImplementedException();
        }

        //public override string GetStockInformationDetails(int reportId)
        //{
        //    return "Stock Infomation Details";
        //}
        //public override string GetProductInformationDetails(int reportId)
        //{
        //    throw new NotImplementedException();
        //}
    }

    public interface IStockInformation
    {
        string GetStockInformationDetails(int reportId);
    }
    public interface IProductInformation
    {
        string ProductInformationDetails(int reportId);
    }





}
