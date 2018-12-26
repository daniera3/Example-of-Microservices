package ex;

import java.io.FileWriter;
import java.io.IOException;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Date;

public class retriverExeption extends Exception  {
	static DateFormat dateFormat = new SimpleDateFormat("yyyy/MM/dd HH:mm:ss");

	static private FileWriter log=null;
	
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	
	public retriverExeption(String massage,int exitCode) throws IOException {
		try {
			log=new FileWriter("log.txt");
		} catch (IOException e) {
			System.exit(1);
		}
		Date date = new Date();
		
		log.write("runtime exception "+massage+" "+dateFormat.format(date));
		log.close();
		System.exit(exitCode);
	}
	

}
