import java.io.File;

import org.junit.Rule;
import org.junit.Test;
import org.junit.internal.runners.statements.ExpectException;
import org.junit.rules.ExpectedException;

public class FileReaderTest {

    private final FileReader fileReader = new FileReader();
    @Rule
    private ExpectedException expectedException = ExpectException.none();

    @Test(expected = IndexOutOfBoundsException.class)
    public void testIndexOutOfBoundsException() {
        list.get(0);
    }

    
    public void getWordsInDocumentTest() {

    }
}