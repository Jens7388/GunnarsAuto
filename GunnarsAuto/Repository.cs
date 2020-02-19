using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace GunnarsAuto
{
    public class Repository
    {
        public static List<SalesPerson> salesPersons = new List<SalesPerson>();
        public static List<Car> cars = new List<Car>();
        public static List<Sale> sales = new List<Sale>();

        private const string connectionString = @"
            Data Source=(localdb)\mssqllocaldb;
            Initial Catalog=GunnarsAutoDB;
            Integrated Security = True;         
            ";
        public static List<SalesPerson> GetAllSalesPersons()
        {
            salesPersons = new List<SalesPerson>();
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
            connection.Close();
            command.Dispose();
            return salesPersons;
        }
        public static List<Car> GetAllCars()
        {
            cars = new List<Car>();
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
            connection.Close();
            command.Dispose();
            return cars;
        }
        
        public static List<Sale> GetAllSales()
        {
            sales = new List<Sale>();
            string sql = "SELECT * FROM Sale";
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
            connection.Close();
            command.Dispose();
            return sales;
        }
        public static void AddSalesPerson(SalesPerson salesPerson)
        {
            string sql = $"INSERT INTO SalesPersons VALUES('{salesPerson.Firstname}','{salesPerson.Lastname}', '{salesPerson.Initials}')";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            command.Dispose();
        }
        public static void AddCar(Car car)
        {
            string sql = $"INSERT INTO Car VALUES('{car.Make}', '{car.Model}', " +
                $"'{car.ChassisNumber}', '{car.RegistrationNumber}', '{car.CarType}')";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            command.Dispose();
        }
        public static void AddSale(Sale sale)
        {
            string sql = $"INSERT INTO Sale VALUES('{sale.TransactionAmount}', '{sale.SaleType}', '{sale.SalesPersonId}', '{sale.CarId}')";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            command.Dispose();
        }
        public static void UpdateSalesPerson(SalesPerson salesPerson)
        {
            string sql = $"UPDATE Salespersons SET Firstname = '{salesPerson.Firstname}', Lastname = '{salesPerson.Lastname}'," +
            $" Initials = '{salesPerson.Initials}' WHERE SalesPersonId = '{salesPerson.salesPersonId}'";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            command.Dispose();
        }
        public static void UpdateCar(Car car)
        {
            string sql = $"UPDATE Car SET Make = '{car.Make}', Model = '{car.Model}'," +
            $" ChassisNumber = '{car.ChassisNumber}', RegistrationNumber = '{car.RegistrationNumber}', CarType = '{car.CarType}' " +
            $"WHERE CarId = '{car.CarId}'";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            command.Dispose();
        }
        public static void UpdateSale(Sale sale)
        {
            string sql = $"UPDATE Sale SET TransactionAmount = '{sale.TransactionAmount}', SaleType = '{sale.SaleType}'," +
            $" SalesPersonId = '{sale.SalesPersonId}', CarId = '{sale.CarId}' WHERE SaleId = '{sale.SaleId}'";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            command.Dispose();
        }
    }
}