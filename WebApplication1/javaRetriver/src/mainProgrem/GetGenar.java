package mainProgrem;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

import models.Ganers;
import models.movieClass;

public class GetGenar extends Retriver {
	public boolean succes=false;
	public GetGenar(movieClass result) throws SQLException {
		 try ( Connection con = DriverManager.getConnection(connectionUrl); Statement stmt = con.createStatement();) {
		        String query = "SELECT * FROM [dbo].[genre] WHERE [idmovie] ="+result.getIdmovie();
			 	ResultSet rs1 = stmt.executeQuery(query);
			 	while (rs1.next()) {
			 		result.addGaner(new Ganers(rs1.getString(1), rs1.getInt(2)));
			 	}
		        }
		 succes=true;
			}
	
}
