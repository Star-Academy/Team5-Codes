package Test;

import static org.junit.jupiter.api.Assertions.assertEquals;

import java.io.File;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.Set;

import org.junit.Before;
import org.junit.Test;

import classes.DataCollector;
import classes.InvertedIndexSearch;

public class InvertedIndexTest {
    private DataCollector dataCollector;
    private InvertedIndexSearch invertedIndex;

    @Before
    public void setDataCollectorForTest() {
        dataCollector = new DataCollector();
        invertedIndex = new InvertedIndexSearch();
        File folder = new File("Test\\sampleFolder");
        dataCollector.listFilesForFolder(folder);
        dataCollector.initWords();
    }

    @Test
    public void testInitMethodSingDoc() {
        invertedIndex.init(dataCollector);
        ArrayList<String> actualValue = invertedIndex.getInvertedIndexMap().get("java");
        ArrayList<String> expectedValue = new ArrayList<>();
        expectedValue.add("sampleText2.txt");
        assertEquals(expectedValue, actualValue);
    }

    @Test
    public void testInitMethodMultiDoc() {
        invertedIndex.init(dataCollector);
        ArrayList<String> actualValue = invertedIndex.getInvertedIndexMap().get("this");
        ArrayList<String> expectedValue = new ArrayList<>();
        expectedValue.add("sampleText2.txt");
        expectedValue.add("sampleText1.txt");
        assertEquals(expectedValue, actualValue);
    }

    @Test
    public void testInitMethodNotContain() {
        invertedIndex.init(dataCollector);
        ArrayList<String> actualValue = invertedIndex.getInvertedIndexMap().get("code");
        assertEquals(null, actualValue);
    }

}