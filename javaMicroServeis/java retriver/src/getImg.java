import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileWriter;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.Statement;
import java.util.Scanner;

public class getImg {
	
	 private void Getimg(movieClass a,int id)
     {
		 
		 
		 File config=new File("config");
			FileWriter log=null;
			
			
			Scanner sc=null;
			try {
				sc = new Scanner(config);
			} catch (FileNotFoundException e1) {
				log.write("cannot open config  file");
			}
			
	        String connectionUrl =sc.nextLine();
	        String query = "SELECT * FROM [dbo].[movieimg] WHERE [idimg] = "+a+';';
	        
	        
	        try (Connection con = DriverManager.getConnection(connectionUrl); Statement stmt = con.createStatement();) {
	        	ResultSet rs = stmt.executeQuery(query);
	        	
	        	
             //a shorter syntax to adding parameters
             command.Parameters.AddWithValue("@idimg", a.Idimg);
             //make sure you open and close(after executing) the connection
             
                 a.Img=new Imge(Reader.GetInt32(0), Reader.GetString(1), Reader.GetString(2), Reader.GetString(3), Reader.GetString(4), Reader.GetString(5));
         }


}
