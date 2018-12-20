
import java.sql.Connection;
import java.io.File;
import java.io.FileNotFoundException;
import java.util.Scanner;

import org.json.JSONObject;

import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

public class Retriver {

	public static void main(String[] args) {
		File config=new File("config");
		Scanner sc=null;
		try {
			sc = new Scanner(config);
		} catch (FileNotFoundException e1) {
			System.out.println("cannot open config  file");
		}

		  // set the connection string in the connection object
        String connectionUrl =sc.nextLine();
        try (Connection con = DriverManager.getConnection(connectionUrl); Statement stmt = con.createStatement();) {
            String SQL = "SELECT * FROM [dbo].[Movie]";
            ResultSet rs = stmt.executeQuery(SQL);
            //run on the data from the sql server and extarct
            while (rs.next()) {
            	JSONObject result = new JSONObject();
            	
                System.out.println(rs.getString("FirstName") + " " + rs.getString("LastName"));
            }
        }
        // Handle any errors that may have occurred.
        catch (SQLException e) {
            System.out.println("Eror: cannot connect to the server");
        }
	}

}
