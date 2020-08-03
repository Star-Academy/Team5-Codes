import java.util.*;

public class Tokenizer {
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
    public Tokenizer() {
        invertedIndexMap = new HashMap<>();
    }

    /**
     * this method will initialize the document words and will process them in order
     * for use.
     * 
     * @param fileReader contains the readed docs.
     */
    public void init(FileReader fileReader) {
        final Map<String, ArrayList<String>> documents = fileReader.getDocumentsWords();// {doc, word}
        documents.forEach((key, value) -> {
            for (final String str : value)
                add(str, key);
        });
        removeDuplicates();
    }

    /**
     * this method will add the words in array of string with the documentary name
     * of key to the hashMap
     * 
     * @param word       is the word that will be updated
     * @param docAddress is the document name.
     */
    private void add(String word, final String docAddress) {
        invertedIndexMap.putIfAbsent(word, new ArrayList<String>());
        invertedIndexMap.get(word).add(docAddress);
    }

    /**
     * this method will make the addresses for each word unique. means that there
     * won't be duplicates in the doc adresses in hashMap.
     */
    private void removeDuplicates() {
        invertedIndexMap.forEach((k, v) -> {
            Set<String> set = new HashSet<String>(v);
            v = new ArrayList<>();
            v.addAll(set);
        });
    }
}