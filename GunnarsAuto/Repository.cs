using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace GunnarsAuto
{
    public class Repository
    {
        private const string connectionString = @"
            Data Source=(localdb)\mssqllocaldb;
            Initial Catalog=GunnarsAutoDB;
            Integrated Security = True;         
            ";
        public List<SalesPerson> GetAllSalesPersons()
        {
            List<SalesPerson> salesPersons = new List<SalesPerson>();
            string sql = "SELECT * FROM SalesPersons";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                int salesPersonId = (int)reader["SalesPersonId"];
                string firstname = (string)reader["Firstname"];
                string lastname = (string)reader["Lastname"];
                string initials = (string)reader["Initials"];

                SalesPerson salesPerson = new SalesPerson(salesPersonId, firstname, lastname, initials);
                salesPersons.Add(salesPerson);
            }
            return salesPersons;
        }
        public List<Car> GetAllCars()
        {
            List<Car> cars = new List<Car>();
            string sql = "SELECT * FROM Car";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                int carId = (int)reader["CarId"];
                string make = (string)reader["Make"];
                string model = (string)reader["Model"];
                string chassisNumber = (string)reader["ChassisNumber"];
                string registrationNumber = (string)reader["RegistrationNumber"];
                string carType = (string)reader["CarType"];

                Car car = new Car(carId, make, model, chassisNumber, registrationNumber, carType);
                cars.Add(car);
            }
            return cars;
        }
        
        public List<Sale> GetAllSales()
        {
            List<Sale> sales = new List<Sale>();
            string sql = "SELECT * FROM Sales";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                int saleId = (int)reader["SaleId"];
                int transactionAmount = (int)reader["TransactionAmount"];
                string saleType = (string)reader["SaleType"];
                int salesPersonId = (int)reader["SalesPersonId"];
                int carId = (int)reader["CarId"];

                Sale sale = new Sale(saleId, transactionAmount, saleType, salesPersonId, carId);
                sales.Add(sale);
            }
            return sales;
        }
    }
}
