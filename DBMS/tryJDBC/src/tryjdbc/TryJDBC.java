package tryjdbc;

import java.io.FileWriter;
import java.io.IOException;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.ResultSetMetaData;
import java.sql.SQLException;
import java.sql.Statement;

import org.json.simple.JSONArray;
import org.json.simple.JSONObject;

public class TryJDBC
{
    public static void main(String[] args)
    {
        try
        {
            Class.forName("org.postgresql.Driver");
            System.out.println("Olala");
        }
        catch(ClassNotFoundException e)
        {
            System.out.println("Something went wrong. " + e.toString());
        }
        try
        {
            try(Connection connection = DriverManager.getConnection("jdbc:postgresql://127.0.0.1:5432/grocery_store", "postgres", "extybr"))
            {
                executeQuery(connection);
                //executeQueryParam(connection, "'us/kg'");
                //update(connection, "Amazing dessert");
                System.out.println("Olala2");
            }
        }
        catch(SQLException e)
        {
            System.out.println("Connection failed. " + e.toString());
        }
    }
    
    public static void executeQuery(Connection c)
    {
        try
        {
            try(Statement s = c.createStatement())
            {
                ResultSet rs = s.executeQuery("SELECT * FROM prices");
                JSONArray json = new JSONArray();
                ResultSetMetaData rsmd = rs.getMetaData();

                while(rs.next())
                {
                    int numColumns = rsmd.getColumnCount();
                    JSONObject obj = new JSONObject();

                    for (int i=1; i<numColumns+1; i++)
                    {
                        String column_name = rsmd.getColumnName(i);

                        if(rsmd.getColumnType(i)==java.sql.Types.DOUBLE)
                        {
                            obj.put(column_name, rs.getDouble(column_name)); 
                        }
                        else if(rsmd.getColumnType(i)==java.sql.Types.INTEGER)
                        {
                            obj.put(column_name, rs.getInt(column_name));
                        }
                        else if(rsmd.getColumnType(i)==java.sql.Types.NVARCHAR)
                        {
                            obj.put(column_name, rs.getNString(column_name));
                        }
                        else if(rsmd.getColumnType(i)==java.sql.Types.VARCHAR)
                        {
                            obj.put(column_name, rs.getString(column_name));
                        }
                        else
                        {
                            obj.put(column_name, rs.getObject(column_name));
                        }
                  }

                  json.add(obj);
                }

                try 
                { 
                    FileWriter file = new FileWriter("d:\\test.json"); 
                    file.write(json.toJSONString()); 
                    file.flush(); 
                    file.close(); 
                } 
                catch (IOException e) 
                { 
                    System.out.println(e.toString()); 
                }
            }
        }
        catch(SQLException e)
        {
            System.out.println("Query failed. " + e.toString());
        }
    }
    
    public static void executeQueryParam(Connection c, String s)
    {
        try
        {
            try(PreparedStatement st = c.prepareStatement("SELECT p.id,p.price,d.name FROM prices AS p INNER JOIN dishes AS d ON p.id = d.id WHERE mesuaring_unit=?"))
            {
                st.setString(1, s);
                ResultSet rs = st.executeQuery();
                while(rs.next())
                {
                    System.out.println(rs.getString("id") + "  " + rs.getDouble("price") + "  "  + rs.getString("name"));
                }
            }
        }
        catch(SQLException e)
        {
            System.out.println("Query failed. " + e.toString());
        }
    }
    
    public static void update(Connection c, String desc)
    {
        try
        {
            try(PreparedStatement st = c.prepareStatement("UPDATE dishes SET description = ? WHERE description = 'Tasty dessert'"))
            {
                st.setString(1, desc);
                
                st.executeUpdate();
            }
        }
        catch(SQLException e)
        {
            System.out.println("Query failed. " + e.toString());
        }
    }
}