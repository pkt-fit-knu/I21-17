using static System.Console;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DivideAndConquer
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Attribute> attributes = new List<Attribute>()
            {
                new Attribute(Constants.Outlook, new List<Option>() { new Option(Constants.Sunny), new Option(Constants.Overcast), new Option(Constants.Rainy) }),
                new Attribute(Constants.Temperature, new List<Option>() { new Option(Constants.Hot), new Option(Constants.Mild), new Option(Constants.Cool) }),
                new Attribute(Constants.Humidity, new List<Option>() { new Option(Constants.High), new Option(Constants.Normal) }),
                new Attribute(Constants.Windy, new List<Option>() { new Option(Constants.False), new Option(Constants.True) })
            };
            
            SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS; Initial Catalog=weather; Integrated Security=True");
            connection.Open();

            SqlCommand command = connection.CreateCommand();
            
            command.CommandText = "SELECT * FROM data";

            DataTable dataTable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dataTable);

            connection.Close();
            da.Dispose();

            DecisionTree decisionTree = new DecisionTree();

            decisionTree.BuildDecisionTree(dataTable, attributes, null);

            decisionTree.PrintDecisionTree(decisionTree.Nodes[0], "");

            ReadKey();
        }
    }
}