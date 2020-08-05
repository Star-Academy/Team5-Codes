import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;

/**
 * this class implements a simple dataReader for reading the document datas that
 * were putted in the folder Docs in the project directory. here we gatter the
 * necessary information for building the InvertedIndex search data structure
 * but we don't organize them. organizing datas are all been managed in
 * InvertedIndexSearch class because this class is only responsible for
 * collecting datas from given documents.
 */
public class DataCollector {
    /**
     * this map contains the words that have been found in the fileReader. key is
     * the name of the document and value is an array list of the words in that
     * document.
     */
    private static Map<String, ArrayList<String>> documentsWords;
    private static ArrayList<File> files;

    /**
     * a simple constructor for the class that initializes the map.
     */
    public DataCollector() {
        documentsWords = new HashMap<>();
        files = new ArrayList<>();
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
                files.add(file);
    }

    /**
     * this method calls getWordsInDocument for each document that we saw in Docs folder.
     */
    public void initWords() {
        files.forEach((doc -> {
            getWordsInDocument(doc);
        }));
    }

    /**
     * this method adds all words in a document to the documentsWords in
     * dicumentsWords key is the doc name and the value is all words in it
     * 
     * @param file is the document that it's words should be extracted.
     */
    private static void getWordsInDocument(File file) {
        ArrayList<String> words = extractWordsFromDoc(file);
        documentsWords.put(file.getName(), words);
    }

    /**
     * this method will extract the words from a document and put return the words.
     * 
     * @param file is the document that we want its words to be extracted.
     * @return an ArrayList containing the document words.
     */
    private static ArrayList<String> extractWordsFromDoc(File file) {
        ArrayList<String> words = new ArrayList<>();
        try (Scanner myReader = new Scanner(file)) {
            while (myReader.hasNext())
                words.add(myReader.next().toLowerCase());
        } catch (FileNotFoundException e) {
            System.err.println("An error occurred.");
            e.printStackTrace();
        }
        return words;
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