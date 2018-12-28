package unitTesting;

import static org.junit.jupiter.api.Assertions.assertEquals;


import org.junit.jupiter.api.Test;
import mainProgrem.Retriver;

public class RetriverTest {
	
	 @Test
	    public void chackMainProgremExternal() throws Exception {
		Retriver tester = new Retriver("test"); 
		String [] ConnectionString= {"jdbc:sqlserver://localhost:1433;databaseName=TestDB;integratedSecurity=true;"};
		Retriver.main(ConnectionString);

	    assertEquals(true, Retriver.succes, "chack if main progrem works");

	    }
	

}
