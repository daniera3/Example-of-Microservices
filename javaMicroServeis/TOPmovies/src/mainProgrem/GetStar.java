package mainProgrem;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import models.Star;
import models.movieClass;

public class GetStar extends TopMovies {
	public boolean succes=false;
	public GetStar(movieClass result) throws SQLException {
		 try ( Connection con = DriverManager.getConnection(connectionUrl); Statement stmt = con.createStatement();) {
			 String query = "SELECT * FROM [dbo].[star] WHERE [idmovie] ="+result.getIdmovie();
			 ResultSet rs1 = stmt.executeQuery(query);
			while (rs1.next()) {
				result.addStars(new Star(rs1.getString(1), rs1.getInt(2)));
			}
		        }
		 succes=true;
	}
	

}
