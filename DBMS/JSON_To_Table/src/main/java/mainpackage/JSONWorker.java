package mainpackage;

import java.io.FileReader;
import java.util.List;
import java.util.Map;
import org.json.simple.parser.JSONParser;
import static spark.Spark.get;

public class JSONWorker
{
    public static void main(String[] args)
    {
        //http://localhost:4567/products
        get("/products", (req, res) ->
        {
            String html = "<table border=\"1\" style=\"width: 100%; text-align: center;\"><thead><tr><th>Mesuaring Unit</th><th>Price</th><th>ID</th>></tr></thead><tbody>";
            
            JSONParser parser = new JSONParser();
            Object JSONFile = parser.parse(new FileReader("D:\\test.json"));
            
            List jsonArray = (List) JSONFile; 

            for(Object jsonObject : jsonArray) 
            { 
                Map JSONMap = (Map) jsonObject; 

                Object mesuaringUnit = JSONMap.get("mesuaring_unit"); 
                Object price = JSONMap.get("price"); 
                Object id = JSONMap.get("id");

                html += "<tr><td>" + (String) mesuaringUnit + "</td>" + 
                "<td>" + (Double) price + "</td>" + 
                "<td>" + (String) id + "</td></tr>"; 
            } 

            html += "</tbody></table>";
            
            System.out.println("Success");

            return html;
        });
    }
}
