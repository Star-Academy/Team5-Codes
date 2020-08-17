package Test;

import static org.junit.jupiter.api.Assertions.assertEquals;

import java.io.File;
import java.util.ArrayList;
import org.junit.Before;
import org.junit.Test;
import classes.*;

public class DataCollectorTest {

    private DataCollector dataCollector;
    private String filePath = "sampleText1.txt";

    @Before
    public void setDataCollectorForTest() {
        dataCollector = new DataCollector();
        File folder = new File("Team5-Codes\\Phase1\\Test\\sampleFolder");
        dataCollector.listFilesForFolder(folder);
        dataCollector.initWords();
    }

    @Test
    public void checkNumberOfWordsInDoc() {
        int actual = dataCollector.getDocumentsWords().get(filePath).size();
        assertEquals(12, actual);
    }

    @Test
    public void checkDocumemntsNumber() {
        assertEquals(2, dataCollector.getDocumentsWords().size());
    }

    @Test
    public void checkWordInDoc() {
        ArrayList<String> wordsInDoc = dataCollector.getDocumentsWords().get(filePath);
        boolean flg = wordsInDoc.contains("hello") && wordsInDoc.contains("world");
        assertEquals(true, flg);
    }
}