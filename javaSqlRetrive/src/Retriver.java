
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

public class Retriver {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		
		  // Create a variable for the connection string.
        String connectionUrl = "jdbc:sqlserver://DESKTOP-SJGIRIB:<port>;databaseName=AdventureWorks;user=<user>;password=<password>";
        //Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\Users\97254\Documents\microserviceProject\Example-of-Microservices\WebApplication1\WebApplication1\App_Data\aspnet-WebApplication1-20181211112737.mdf;Initial Catalog=aspnet-WebApplication1-20181211112737;Integrated Security=True
        try (Connection con = DriverManager.getConnection(connectionUrl); Statement stmt = con.createStatement();) {
            String SQL = "SELECT TOP 10 * FROM Person.Contact";
            ResultSet rs = stmt.executeQuery(SQL);

            // Iterate through the data in the result set and display it.
            while (rs.next()) {
                System.out.println(rs.getString("FirstName") + " " + rs.getString("LastName"));
            }
        }
        // Handle any errors that may have occurred.
        catch (SQLException e) {
            e.printStackTrace();
        }
        System.out.println("dear god");
	}

}
