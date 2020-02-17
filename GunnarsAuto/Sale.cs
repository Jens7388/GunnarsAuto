using System;
using System.Collections.Generic;
using System.Text;

namespace GunnarsAuto
{
    class Sale
    {
        public int saleId;
        public int transactionAmount;
        public string saleType;
        public int salesPersonId;
        public int carId;
        public Sale(int saleId, int transactionAmount, string saleType, int salesPersonId, int carId)
        {
            SaleId = saleId;
            TransactionAmount = transactionAmount;
            SaleType = saleType;
            SalesPersonId = salesPersonId;
            CarId = carId;
        }
        public int SaleId {get { return saleId; } set { saleId = value; } }
        public int TransactionAmount { get { return transactionAmount; } set { transactionAmount = value; } }
        public string SaleType { get { return saleType; } set { saleType = value; } }
        public int SalesPersonId { get { return salesPersonId; } set { salesPersonId = value; } }
        public int CarId { get { return carId; } set { carId = value; } }
    }
}
