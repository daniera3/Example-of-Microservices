import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Scanner;
import org.json.JSONArray;

public class Retriver {

	@SuppressWarnings("null")
	public static void main(String[] args) throws IOException {
		ArrayList<movieClass> allMovies=new ArrayList<movieClass>();
		
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
            while (rs.next()) {
            	movieClass result=new movieClass(rs.getInt(1), rs.getString(2), rs.getInt(3), rs.getString(4), rs.getInt(5), rs.getString(6), rs.getString(7));
            	allMovies.add(result);
            	System.out.println(result.getIdimg());
            	
            	
            	
            }
            JSONArray json = new JSONArray(allMovies);
            FileWriter total=null;
            try {
            	total=new FileWriter("result.json");
			} catch (IOException e) {
				//try to create the output file
				log.write("cannot create outputfile");
			}
            try {
            	total.write(json.toString());
            	total.close();
			} catch (IOException e) {
				log.write("eror : cannot convert json to string");
			}
            
        }
        // Handle any errors that may have occurred.
        catch (SQLException e) {
        	e.printStackTrace();
        }
        log.close();
	}
}
