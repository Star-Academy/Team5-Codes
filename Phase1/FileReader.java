import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;


public class FileReader {
    private Map<String, ArrayList<String>> documentsWords = new HashMap<>();
    
    public void listFilesForFolder(final File folder) {
        for (final File file : folder.listFiles()) {
            if (file.isDirectory()) {
                listFilesForFolder(file);
            } else {
                getWordsInDocument(file);
            }
        }
    }

    private void getWordsInDocument(File file) {
        ArrayList<String> words = new ArrayList<>();
        try {
            Scanner myReader = new Scanner(file);
            while (myReader.hasNextLine()) {
              String data = myReader.nextLine();
              words.add(data.toLowerCase());
            }
            myReader.close();
          } catch (FileNotFoundException e) {
            System.out.println("An error occurred.");
            e.printStackTrace();
          }
          documentsWords.put(file.getPath(), words);
    }

    public Map<String, ArrayList<String>> getDocumentsWords() {
        return documentsWords;
    }
}