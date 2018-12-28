package mainProgrem;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Scanner;
import org.json.JSONArray;
import ex.retriverExeption;
import models.*;




public class Retriver {

	static private File config=new File("config.txt");
	static private Scanner sc=null;
	protected static String connectionUrl=null;
	static private FileWriter total=null;
	public static String statue="normal";
	public static boolean succes=false;
	
	public Retriver(String s)  {
		statue=s;
	}
	//normal mode
	public Retriver() {
		statue="normal";
	}
	
	public static void main(String[] args) throws  Exception {
	

		//create new array to store the data from the data base
		ArrayList<movieClass> allMovies=new ArrayList<movieClass>();

		//see if got connection string
		if(args.length>0) {
			connectionUrl=args[0];
			if(statue!="test") {
				
			}
				
		}
		else {
			try {
				sc = new Scanner(config);
			} catch (Exception e) {
				throw new retriverExeption("cannot read from config file",2);
			}
			if(sc.hasNext()) 
				connectionUrl =sc.nextLine();
			else 
				throw new retriverExeption("dont have connction string",4);
			
			}
		
		
        try {
        	Connection con = DriverManager.getConnection(connectionUrl);
        	Statement stmt = con.createStatement(); 

            String SQL = "SELECT * FROM dbo.Movie";
            
            //exucute the sql query
            ResultSet rs = stmt.executeQuery(SQL);
            //run on the data from the sql server and extract
            while (rs.next()) {
            movieClass result=new movieClass(rs.getInt(1), rs.getString(2), rs.getInt(3), rs.getString(4), rs.getInt(5), rs.getString(6), rs.getString(7));
            new GetImg(result);
         	new GetStar( result);
           	new GetDir( result);
          	new GetGenar( result);
          	allMovies.add(result);      
            }
            //convert the javaArray to json Array
            JSONArray json = new JSONArray(allMovies);
        	System.out.print(json.toString());
            try {
            	total=new FileWriter("result.json");
			} catch (IOException e) {
				throw new retriverExeption("cannot create outputfile ",5);
			}

            try {

            	total.write(json.toString());
            	total.close();
			} catch (IOException e) {
				throw new retriverExeption("eror : cannot convert json to string ",6);
			}

        }
        // Handle connection exceptions
        catch (SQLException e) {
        	throw new retriverExeption("cannot connect to server ",6);
        }
        if (statue=="normal")
        	System.exit(0);
        else {
        succes=true;
        statue="normal";

        }

      
	}
	
}

