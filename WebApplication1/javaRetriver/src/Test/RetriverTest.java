package Test;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.After;
import org.junit.jupiter.api.Test;
import mainProgrem.Retriver;

class RetriverTest  {
	Retriver TestClass=new Retriver("test");
	@Test
	void gotIntoTestMode() {
		System.out.println("Inside gotIntoTestMode()");   
		 //test if Retriver got into test mode
		assertNotEquals(Retriver.statue, "normal");
	}
	@After public void returnToNormal() {
		System.out.println("return to normal");
        Retriver.statue="normal";
  }
	
}
