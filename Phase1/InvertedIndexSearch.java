import java.util.*;

/**
 * this class will implement a simple InvertedIndexSearch class for usage. this
 * class will get it's data from fileReader class so its usefull to read it's
 * documents too.
 * @see DataCollector
 */
public class InvertedIndexSearch {
    /**
     * this hashMap contains the keys and values for searching keys are the words
     * that occured in the docs and values are the addresses of the docs that the
     * word occured.
     */
    private final HashMap<String, ArrayList<String>> invertedIndexMap;

    /**
     * a getter for hashMap
     * 
     * @return the hashMap
     */
    public HashMap<String, ArrayList<String>> getInvertedIndexMap() {
        return invertedIndexMap;
    }

    /**
     * the public constructor of the class
     */
    public InvertedIndexSearch() {
        invertedIndexMap = new HashMap<>();
    }

    /**
     * this method will initialize the document words and will process them in order
     * for use.
     * 
     * @param fileReader contains the readed docs.
     */
    public void init(DataCollector fileReader) {
        final Map<String, ArrayList<String>> documents = fileReader.getDocumentsWords();// {doc, word}
        documents.forEach((key, value) -> { // iterating over all of the datas that we have.
            for (final String wordToAdd : value)
                add(wordToAdd, key); // updating the invertedIndexSearch Map.
        });
        removeDuplicates(); // for removing duplicate results for a single word.
    }

    /**
     * this method will add the words in array of string with the documentary name
     * of key to the hashMap
     * 
     * @param word       is the word that will be updated
     * @param docAddress is the document name.
     */
    private void add(String word, final String docAddress) {
        invertedIndexMap.putIfAbsent(word, new ArrayList<String>()); // we don't like an Exception to occur in here. :)
        invertedIndexMap.get(word).add(docAddress);// updating the word docAddresses.
    }

    /**
     * this method will make the addresses for each word unique. means that there
     * won't be duplicates in the doc adresses in hashMap.
     */
    private void removeDuplicates() {
        invertedIndexMap.forEach((key, value) -> { // iterating over the words and removing their duplicate results with
                                                   // Set.
            Set<String> set = new HashSet<String>(value); // with set we can remove duplicates in the value
            value = new ArrayList<>();
            value.addAll(set);
        });
    }
}