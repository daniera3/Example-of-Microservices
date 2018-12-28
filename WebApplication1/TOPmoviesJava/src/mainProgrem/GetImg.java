package mainProgrem;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

import models.Imge;
import models.movieClass;

public class GetImg extends TopMovies {
	public boolean succes=false;
	public GetImg (movieClass result) throws SQLException {
		try ( Connection con = DriverManager.getConnection(connectionUrl); Statement stmt = con.createStatement();) {
			String query = "SELECT * FROM [dbo].[movieimg] WHERE [idimg] = "+result.getIdimg();
			ResultSet rs1 = stmt.executeQuery(query);
			if (rs1.next()) {
					result.setImg(new Imge(rs1.getInt(1), rs1.getString(2), rs1.getString(3),rs1.getString(4), rs1.getString(5), rs1.getString(6)));
			}
		   }
		 succes=true;
	}

}
