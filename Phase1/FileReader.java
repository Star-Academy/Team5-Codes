import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;

public class FileReader {
    /**
     * this map contains the words that have been found in the fileReader. key is
     * the name of the document and value is an array list of the words in that
     * document.
     */
    private static Map<String, ArrayList<String>> documentsWords;

    /**
     * a simple constructor for the class that initializes the map.
     */
    public FileReader() {
        documentsWords = new HashMap<>();
    }

    /**
     * this method will get the words in the documents in a specific folder
     * 
     * @param folder is the floder to be searched.
     **/
    public void listFilesForFolder(final File folder) {
        for (final File file : folder.listFiles())
            if (file.isDirectory())
                listFilesForFolder(file);
            else
                getWordsInDocument(file);
    }

    /**
     * this method adds all words in a document to the documentsWords in
     * dicumentsWords key is the doc name and the value is all words in it
     * 
     * @param file is the document that it's words should be extracted.
     */
    private void getWordsInDocument(File file) {
        ArrayList<String> words = new ArrayList<>();
        try {
            Scanner myReader = new Scanner(file);
            while (myReader.hasNextLine()) {
                String data = myReader.nextLine();
                data = data.toLowerCase();
                String[] splitWords = data.split("\\s");
                words.addAll(Arrays.asList(splitWords));
            }
            myReader.close();
        } catch (FileNotFoundException e) {
            System.out.println("An error occurred.");
            e.printStackTrace();
        }
        documentsWords.put(file.getName(), words);
    }

    /**
     * a simple getter for the words that have been found.
     * 
     * @return document words.
     */
    public Map<String, ArrayList<String>> getDocumentsWords() {
        return documentsWords;
    }
}