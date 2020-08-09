package Test;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.mockito.Mockito.*;

import java.util.Arrays;
import java.util.HashSet;
import java.util.Set;

import org.junit.Before;
import org.junit.Test;

import classes.Manager;
import classes.MyScanner;

public class ManagerTest {

    @Before
    public void initializeManager() {
        Manager.initialize();
    }

    @Test
    public void testManager() {
        Manager myManager = new Manager();
        MyScanner myScanner = mock(MyScanner.class);
        when(myScanner.takeInput()).thenReturn("i have a cold");
        myManager.setMyScanner(myScanner);
        String[] expectedArray = {"58812", "59637", "59632", "59256", "59300", "59629", "58827", "59284"};
        Set<String> expected = new HashSet<>(Arrays.asList(expectedArray));
        Set<String> actual = myManager.run();
        assertEquals(expected, actual);  
    }
}