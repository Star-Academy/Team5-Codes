import java.io.File;
import java.util.*;

public class Tokenizer {
    /**
     * this hashMap contains the keys and values for searching 
     * keys are the words that occured in the docs and values are the addresses
     * of the docs that the word occured.
     */
    private final HashMap<String, ArrayList<String>> invertedIndexMap;

    /**
     * a getter for hashMap
     * @return the hashMap 
     */
    public HashMap<String, ArrayList<String>> getInvertedIndexMap() {
        return invertedIndexMap;
    }

    /**
     * the public constructor of the class
     */
    public Tokenizer() {
        invertedIndexMap = new HashMap<>();
    }

    /**
     * this method will initialize the document words and will process them in order for use.
     * @param fileReader contains the readed docs.
     */
    public void init(FileReader fileReader) {
        final Map<String, ArrayList<String>> documents = fileReader.getDocumentsWords();// {doc, word}
        documents.forEach((k, v) -> {
            for (final String str : v) {
                final String[] strings = str.split(" ");
                add(strings, k);
            }
        });
        makeThemReady();
    }

    /**
     * this method will add the words in array of string with the documentary address of k to the hashMap
     * @param strings is Array of Words in the document
     * @param k is the document address.
     */
    private void add(final String[] strings, final String k) {
        for (final String str : strings) {
            invertedIndexMap.putIfAbsent(str, new ArrayList<String>());
            invertedIndexMap.get(str).add(k);
        }
    }

    /**
     * this method will make the addresses for each word unique.
     * means that there won't be duplicates in the doc adresses in hashMap.
     */
    private void makeThemReady() {
        invertedIndexMap.forEach((k, v) -> {
            Set<String> set = new HashSet<String>(v);
            v = new ArrayList<>();
            v.addAll(set);
        });
    }
}