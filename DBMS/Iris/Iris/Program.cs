using static System.Console;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Linq;

namespace Iris
{
    class Program
    {
        static void Main(string[] args)
        {
            //собственные правила 
            //byte i = 1;

            //foreach (Iris iris in Iris.Irises)
            //{
            //    iris.Validate();
            //    WriteLine(i++ + " " + iris);
            //}

            //1R
            Iris i = new Iris();
            i.OneR();

            ReadKey();
        }
    }

    class Group
    {
        public string Class;

        public List<double> List;

        public int OwnElements;

        public int OtherElements;
    }

    class Iris
    {
        public double SepalLength { get; set; }
        public double SepalWidth { get; set; }
        public double PetalLength { get; set; }
        public double PetalWidth { get; set; }
        public string Class { get; set; }

        public static List<Iris> Irises = new List<Iris>
        {
            new Iris(5.1, 3.5, 1.4, 0.2),
            new Iris(4.9, 3, 1.4, 0.2),
            new Iris(4.7, 3.2, 1.3, 0.2),
            new Iris(4.6, 3.1, 1.5, 0.2),
            new Iris(5, 3.6, 1.4, 0.2),
            new Iris(5.4, 3.9, 1.7, 0.4),
            new Iris(4.6, 3.4, 1.4, 0.3),
            new Iris(5, 3.4, 1.5, 0.2),
            new Iris(4.4, 2.9, 1.4, 0.2),
            new Iris(4.9, 3.1, 1.5, 0.2),
            new Iris(5.4,3.7,1.5,0.2),
            new Iris(4.8,3.4,1.6,0.2),
            new Iris(4.8,3.0,1.4,0.1),
            new Iris(4.3,3.0,1.1,0.1),
            new Iris(5.8,4.0,1.2,0.2),
            new Iris(5.7,4.4,1.5,0.4),
            new Iris(5.4,3.9,1.3,0.4),
            new Iris(5.1,3.5,1.4,0.3),
            new Iris(5.7,3.8,1.7,0.3),
            new Iris(5.1,3.8,1.5,0.3),
            new Iris(5.4,3.4,1.7,0.2),
            new Iris(5.1,3.7,1.5,0.4),
            new Iris(4.6,3.6,1.0,0.2),
            new Iris(5.1,3.3,1.7,0.5),
            new Iris(4.8,3.4,1.9,0.2),
            new Iris(5.0,3.0,1.6,0.2),
            new Iris(5.0,3.4,1.6,0.4),
            new Iris(5.2,3.5,1.5,0.2),
            new Iris(5.2,3.4,1.4,0.2),
            new Iris(4.7,3.2,1.6,0.2),
            new Iris(4.8,3.1,1.6,0.2),
            new Iris(5.4,3.4,1.5,0.4),
            new Iris(5.2,4.1,1.5,0.1),
            new Iris(5.5,4.2,1.4,0.2),
            new Iris(4.9,3.1,1.5,0.1),
            new Iris(5.0,3.2,1.2,0.2),
            new Iris(5.5,3.5,1.3,0.2),
            new Iris(4.9,3.1,1.5,0.1),
            new Iris(4.4,3.0,1.3,0.2),
            new Iris(5.1,3.4,1.5,0.2),
            new Iris(5.0,3.5,1.3,0.3),
            new Iris(4.5,2.3,1.3,0.3),
            new Iris(4.4,3.2,1.3,0.2),
            new Iris(5.0,3.5,1.6,0.6),
            new Iris(5.1,3.8,1.9,0.4),
            new Iris(4.8,3.0,1.4,0.3),
            new Iris(5.1,3.8,1.6,0.2),
            new Iris(4.6,3.2,1.4,0.2),
            new Iris(5.3,3.7,1.5,0.2),
            new Iris(5.0,3.3,1.4,0.2),
            new Iris(7, 3.2, 4.7, 1.4),
            new Iris(6.4, 3.2, 4.5, 1.5),
            new Iris(6.9, 3.1, 4.9, 1.5),
            new Iris(5.5, 2.3, 4, 1.3),
            new Iris(6.5, 2.8, 4.6, 1.5),
            new Iris(5.7, 2.8, 4.5, 1.3),
            new Iris(6.3, 3.3, 4.7, 1.6),
            new Iris(4.9, 2.4, 3.3, 1),
            new Iris(6.6, 2.9, 4.6, 1.3),
            new Iris(5.2, 2.7, 3.9, 1.4),
            new Iris(5.0,2.0,3.5,1.0),
            new Iris(5.9,3.0,4.2,1.5),
            new Iris(6.0,2.2,4.0,1.0),
            new Iris(6.1,2.9,4.7,1.4),
            new Iris(5.6,2.9,3.6,1.3),
            new Iris(6.7,3.1,4.4,1.4),
            new Iris(5.6,3.0,4.5,1.5),
            new Iris(5.8,2.7,4.1,1.0),
            new Iris(6.2,2.2,4.5,1.5),
            new Iris(5.6,2.5,3.9,1.1),
            new Iris(5.9,3.2,4.8,1.8),
            new Iris(6.1,2.8,4.0,1.3),
            new Iris(6.3,2.5,4.9,1.5),
            new Iris(6.1,2.8,4.7,1.2),
            new Iris(6.4,2.9,4.3,1.3),
            new Iris(6.6,3.0,4.4,1.4),
            new Iris(6.8,2.8,4.8,1.4),
            new Iris(6.7,3.0,5.0,1.7),
            new Iris(6.0,2.9,4.5,1.5),
            new Iris(5.7,2.6,3.5,1.0),
            new Iris(5.5,2.4,3.8,1.1),
            new Iris(5.5,2.4,3.7,1.0),
            new Iris(5.8,2.7,3.9,1.2),
            new Iris(6.0,2.7,5.1,1.6),
            new Iris(5.4,3.0,4.5,1.5),
            new Iris(6.0,3.4,4.5,1.6),
            new Iris(6.7,3.1,4.7,1.5),
            new Iris(6.3,2.3,4.4,1.3),
            new Iris(5.6,3.0,4.1,1.3),
            new Iris(5.5,2.5,4.0,1.3),
            new Iris(5.5,2.6,4.4,1.2),
            new Iris(6.1,3.0,4.6,1.4),
            new Iris(5.8,2.6,4.0,1.2),
            new Iris(5.0,2.3,3.3,1.0),
            new Iris(5.6,2.7,4.2,1.3),
            new Iris(5.7,3.0,4.2,1.2),
            new Iris(5.7,2.9,4.2,1.3),
            new Iris(6.2,2.9,4.3,1.3),
            new Iris(5.1,2.5,3.0,1.1),
            new Iris(5.7,2.8,4.1,1.3),
            new Iris(6.3, 3.3, 6, 2.5),
            new Iris(5.8, 2.7, 5.1, 1.9),
            new Iris(7.1, 3, 5.9, 2.1),
            new Iris(6.3, 2.9, 5.6, 1.8),
            new Iris(6.5, 3, 5.8, 2.2),
            new Iris(7.6, 3, 6.6, 2.1),
            new Iris(4.9, 2.5, 4.5, 1.7),
            new Iris(7.3, 2.9, 6.3, 1.8),
            new Iris(6.7, 2.5, 5.8, 1.8),
            new Iris(7.2, 3.6, 6.1, 2.5),
            new Iris(6.5,3.2,5.1,2.0),
            new Iris(6.4,2.7,5.3,1.9),
            new Iris(6.8,3.0,5.5,2.1),
            new Iris(5.7,2.5,5.0,2.0),
            new Iris(5.8,2.8,5.1,2.4),
            new Iris(6.4,3.2,5.3,2.3),
            new Iris(6.5,3.0,5.5,1.8),
            new Iris(7.7,3.8,6.7,2.2),
            new Iris(7.7,2.6,6.9,2.3),
            new Iris(6.0,2.2,5.0,1.5),
            new Iris(6.9,3.2,5.7,2.3),
            new Iris(5.6,2.8,4.9,2.0),
            new Iris(7.7,2.8,6.7,2.0),
            new Iris(6.3,2.7,4.9,1.8),
            new Iris(6.7,3.3,5.7,2.1),
            new Iris(7.2,3.2,6.0,1.8),
            new Iris(6.2,2.8,4.8,1.8),
            new Iris(6.1,3.0,4.9,1.8),
            new Iris(6.4,2.8,5.6,2.1),
            new Iris(7.2,3.0,5.8,1.6),
            new Iris(7.4,2.8,6.1,1.9),
            new Iris(7.9,3.8,6.4,2.0),
            new Iris(6.4,2.8,5.6,2.2),
            new Iris(6.3,2.8,5.1,1.5),
            new Iris(6.1,2.6,5.6,1.4),
            new Iris(7.7,3.0,6.1,2.3),
            new Iris(6.3,3.4,5.6,2.4),
            new Iris(6.4,3.1,5.5,1.8),
            new Iris(6.0,3.0,4.8,1.8),
            new Iris(6.9,3.1,5.4,2.1),
            new Iris(6.7,3.1,5.6,2.4),
            new Iris(6.9,3.1,5.1,2.3),
            new Iris(5.8,2.7,5.1,1.9),
            new Iris(6.8,3.2,5.9,2.3),
            new Iris(6.7,3.3,5.7,2.5),
            new Iris(6.7,3.0,5.2,2.3),
            new Iris(6.3,2.5,5.0,1.9),
            new Iris(6.5,3.0,5.2,2.0),
            new Iris(6.2,3.4,5.4,2.3),
            new Iris(5.9,3.0,5.1,1.8),
        };

        public void Validate()
        {
            if(PetalWidth < 0.7)
            {
                Class = "Iris-setosa";
            }
            else if(PetalLength < 5.1 && PetalWidth < 1.8)
            {
                Class = "Iris-versicolor";
            }
            else
            {
                Class = "Iris-virginica";
            }
        }

        public void OneR()
        {
            int minErrors = 150;
            List<Group> preciseGroups = null;
            string columnCaption = "";
            string caption = "";

            for(byte c = 0; c < 4; ++c)
            {
                List<Group> groups = OneR(c, out caption);

                int otherElements = 0;

                foreach(Group g in groups)
                {
                    otherElements += g.OtherElements;
                }

                if(otherElements < minErrors)
                {
                    minErrors = otherElements;
                    preciseGroups = groups;
                    columnCaption = caption;
                }
            }

            List<string> ifs = new List<string>();

            for (byte groupsCounter = 0; groupsCounter < preciseGroups.Count; ++groupsCounter)
            {
                if (groupsCounter == 0)
                {
                    ifs.Add($"if {columnCaption} < {(preciseGroups[groupsCounter].List.Last() + preciseGroups[groupsCounter + 1].List.First()) / 2} then class = {preciseGroups[groupsCounter].Class}");
                }
                else if (groupsCounter == preciseGroups.Count - 1)
                {
                    ifs.Add($"if {(preciseGroups[groupsCounter].List.First() + preciseGroups[groupsCounter - 1].List.Last()) / 2} <= {columnCaption} then class = {preciseGroups[groupsCounter].Class}");
                }
                else
                {
                    ifs.Add($"if {(preciseGroups[groupsCounter].List.First() + preciseGroups[groupsCounter - 1].List.Last()) / 2} <= {columnCaption} < {(preciseGroups[groupsCounter].List.Last() + preciseGroups[groupsCounter + 1].List.First()) / 2} then class = {preciseGroups[groupsCounter].Class}");
                }
            }

            foreach(string s in ifs)
            {
                WriteLine(s);
            }
        }

        List<Group> OneR(int column, out string columnCaption)
        {
            DataTable table = GetTable(column);

            List<Group> groups = new List<Group> { new Group { Class = (string)table.Rows[0].ItemArray[4], List = new List<double>() } };

            for(byte rowsCounter = 1, groupsCounter = 0; rowsCounter <= table.Rows.Count; ++rowsCounter)
            {
                groups[groupsCounter].List.Add(Convert.ToDouble(table.Rows[rowsCounter - 1].ItemArray[column]));

                if (rowsCounter != table.Rows.Count && (string)table.Rows[rowsCounter - 1].ItemArray[4] != (string)table.Rows[rowsCounter].ItemArray[4] )
                {
                    groups[groupsCounter].OwnElements = groups[groupsCounter].List.Count;

                    groups.Add(new Group { Class = (string)table.Rows[rowsCounter].ItemArray[4], List = new List<double>() });

                    ++groupsCounter;
                }
            }

            groups.Last().OwnElements = groups.Last().List.Count;

            for(byte groupsCounter = 0; groupsCounter < groups.Count - 1;)
            {
                if(groups[groupsCounter].Class == groups[groupsCounter + 1].Class)
                {
                    groups[groupsCounter].List.AddRange(groups[groupsCounter + 1].List);

                    groups[groupsCounter].OwnElements += groups[groupsCounter + 1].List.Count;

                    groups.RemoveAt(groupsCounter + 1);
                }
                else
                {
                    if (groups[groupsCounter].OtherElements + groups[groupsCounter + 1].List.Count <= groups[groupsCounter].OwnElements / 2)
                    {
                        groups[groupsCounter].List.AddRange(groups[groupsCounter + 1].List);

                        groups[groupsCounter].OtherElements += groups[groupsCounter + 1].List.Count;

                        groups.RemoveAt(groupsCounter + 1);
                    }
                    else
                    {
                        ++groupsCounter;
                    }
                }
            }

            columnCaption = table.Columns[column].Caption;
            return groups;
        }

        DataTable GetTable(int column)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=iris; Integrated Security=True");
            connection.Open();

            SqlCommand command = connection.CreateCommand();

            string text = "SELECT * FROM irises ORDER BY ";
            switch (column)
            {
                case 0:
                    {
                        text += "sepal_length;";
                        break;
                    }
                case 1:
                    {
                        text += "sepal_width;";
                        break;
                    }
                case 2:
                    {
                        text += "petal_length;";
                        break;
                    }
                case 3:
                    {
                        text += "petal_width;";
                        break;
                    }
                default:
                    {
                        throw new Exception("Invalid column");
                    }
            }
            command.CommandText = text;

            DataTable dataTable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dataTable);

            connection.Close();
            da.Dispose();

            return dataTable;
        }

        public override string ToString()
        {
            return $"SL: {SepalLength}, SW: {SepalWidth}, PL: {PetalLength}, PW: {PetalWidth}, Class: {Class}";
        }

        public Iris(double sl, double sw, double pl, double pw)
        {
            SepalLength = sl;
            SepalWidth = sw;
            PetalLength = pl;
            PetalWidth = pw;
        }

        public Iris()
        {

        }
    }
}