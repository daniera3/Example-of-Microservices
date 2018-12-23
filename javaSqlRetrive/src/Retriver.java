
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import com.microsoft.sqlserver.*;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileWriter;
import java.io.IOException;
import java.util.Scanner;
import org.json.JSONArray;
import org.json.JSONObject;



public class Retriver {

	@SuppressWarnings("null")
	public static void main(String[] args) throws IOException {
		File config=new File("config");
		FileWriter log=null;
		try {
			log=new FileWriter("log.txt");
		} catch (IOException e2) {
			log.write("cannot write to the log file");
		}
		Scanner sc=null;
		try {
			sc = new Scanner(config);
		} catch (FileNotFoundException e1) {
			log.write("cannot open config  file");
		}
		  // set the connection string in the connection object
        String connectionUrl =sc.nextLine();
        try (Connection con = DriverManager.getConnection(connectionUrl); Statement stmt = con.createStatement();) {
            String SQL = "SELECT * FROM [dbo].[Movie]";
            ResultSet rs = stmt.executeQuery(SQL);
            //run on the data from the sql server and extract
            JSONArray jsonArray = new JSONArray();
            while (rs.next()) {
                int total_rows = rs.getMetaData().getColumnCount();
                for (int i = 0; i < total_rows; i++) {
                    JSONObject obj = new JSONObject();
                    obj.put(rs.getMetaData().getColumnLabel(i + 1)
                            .toLowerCase(), rs.getObject(i + 1));
                    jsonArray.put(obj);
                }
            }
            FileWriter result=null;
            try {
				result=new FileWriter("result.json");
			} catch (IOException e) {
				//try to create the output file
				log.write("cannot create outputfile");
			}
            try {
            	result.write(jsonArray.toString());
				result.close();
			} catch (IOException e) {
				
				log.write("eror : cannot convert json to string");
			}
            
        }
        // Handle any errors that may have occurred.
        catch (SQLException e) {
        	System.out.println("got hare?");
        	e.printStackTrace();
        }
        log.close();
	}

}
