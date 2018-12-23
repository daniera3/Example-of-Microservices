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
            String SQL = "SELECT TOP 4 * FROM [dbo].[Movie] ORDER BY [rating] DESC";
            ResultSet rs = stmt.executeQuery(SQL);
            //run on the data from the sql server and extract
            while (rs.next()) {
            	movieClass result=new movieClass(rs.getInt(1), rs.getString(2), rs.getInt(3), rs.getString(4), rs.getInt(5), rs.getString(6), rs.getString(7));
            	String query = "SELECT * FROM [dbo].[movieimg] WHERE [idimg] = "+rs.getInt(1);
            	ResultSet rs1 = stmt.executeQuery(query);
            	while (rs1.next()) {
            	result.setImg(new Imge(rs1.getInt(1), rs1.getString(2), rs1.getString(3),rs1.getString(4), rs1.getString(5), rs1.getString(6)));
            	}
            	 query = "SELECT * FROM [dbo].[star] WHERE [idmovie] ="+rs.getInt(1);
            	 rs1 = stmt.executeQuery(query);
            	while (rs1.next()) {
            		result.Str.add(new Star(rs1.getString(1), rs1.getInt(2)));
            	}
           	 	query = "SELECT * FROM [dbo].[Director] WHERE [idmovie] ="+rs.getInt(1);
           	 	rs1 = stmt.executeQuery(query);
           	 	while (rs1.next()) {
           	 		result.Dir.add(new Director(rs1.getString(1), rs1.getInt(2)));
           	 	}
           	 	query = "SELECT * FROM [dbo].[genre] WHERE [idmovie] ="+rs.getInt(1);
           	 	rs1 = stmt.executeQuery(query);
           	 	while (rs1.next()) {
           	 		result.Ganer.add(new Ganers(rs1.getString(1), rs1.getInt(2)));
           	 	}
            	allMovies.add(result);
            	
            }  	
            
            JSONArray json = new JSONArray(allMovies);
            FileWriter total=null;
            try {
            	total=new FileWriter("resultTop.json");
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
        catch(Exception e) {
        	e.printStackTrace();
        }
        log.close();
	}
}
