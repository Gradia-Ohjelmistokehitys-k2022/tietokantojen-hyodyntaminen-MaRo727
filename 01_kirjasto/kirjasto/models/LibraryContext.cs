using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Reflection.PortableExecutable;

namespace kirjasto.models
{
    internal class LibraryContext
    {
        private string _connectionString;
        public LibraryContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public string IsDbConnectionEstablished()
        {
            using var connection = new SqlConnection(_connectionString);

            try
            {
                connection.Open();
                return "Connection established!";
            }
            catch (SqlException ex)
            {
                throw;
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Book> GetBooks()
        {
            List<Book> Books = new();

            using var dbConnection = new SqlConnection(_connectionString); // uusi tapa käyttää using-ominaisuutta. Tämä huolehtii yhteyden sulkemisesta.

            dbConnection.Open(); //avataan yhteys tietokantaan

            using var command = new SqlCommand("SELECT * FROM Book where PublicationYear > 2019;", dbConnection); // kysely ja tietokannan osoite
            using var reader = command.ExecuteReader(); // olio, jolla luetaan tietoja kannasta
            while (reader.Read()) // silmukka, joka lukee kantaa niin kauan kuin siellä on rivejä, joital lukea
            {
                Book book = new() // jokaiselle riville luodaan uusi olio, johon tiedot tallennetaan
                {
                    Id = Convert.ToInt32(reader["BookId"]),
                    Title = reader["Title"].ToString(),
                    PublicationYear = Convert.ToInt32(reader["PublicationYear"])
                };
                Books.Add(book);
            }
            return Books;
        }

        public int AverageAge()
        {
            using var dbConnection = new SqlConnection(_connectionString); // Using ensures the connection is disposed of properly.
            dbConnection.Open(); // Open the database connection.

            using var command = new SqlCommand("SELECT 2024 - AVG(BirthYear) AS AverageAge FROM Member;", dbConnection); // Query to get the average birth year.
            var result = command.ExecuteScalar(); // Execute the query and get the result.

            // If the result is null, return 0, otherwise convert the result to an integer.
            return result == DBNull.Value ? 0 : Convert.ToInt32(result);
        }

        public int MostBooks()
        {
            using var dbConnection = new SqlConnection(_connectionString); // Using ensures the connection is disposed of properly.
            dbConnection.Open(); // Open the database connection.

            using var command = new SqlCommand("SELECT MAX(AvailableCopies) AS MaxCopies FROM Book;", dbConnection); // Query to get the average birth year.
            var result = command.ExecuteScalar(); // Execute the query and get the result.

            // If the result is null, return 0, otherwise convert the result to an integer.
            return result == DBNull.Value ? 0 : Convert.ToInt32(result);
        }

        public List<string> LoanedFirstNames()
        {
            var firstNames = new List<string>();

            using var dbConnection = new SqlConnection(_connectionString);
            dbConnection.Open();

            using var command = new SqlCommand(
                "SELECT m.firstname " +
                "FROM member m " +
                "LEFT JOIN loan l ON m.memberid = l.memberid " +
                "WHERE l.memberid IS NULL;", dbConnection); // Only members with loans

            using var reader = command.ExecuteReader();
            while (reader.Read()) // Read each row
            {
                firstNames.Add(reader["firstname"].ToString()); // Add first name to the list
            }

            return firstNames;
        }
       


    }
}

