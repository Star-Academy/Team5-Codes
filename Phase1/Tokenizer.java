import java.io.File;
import java.util.*;

public class Tokenizer {
    /**
     * key is the word and value is the places that the word occures.
     */
    private final HashMap<String, ArrayList<String>> hashMap;

    /**
     * 
     * @return
     */
    public HashMap<String, ArrayList<String>> getHashMap() {
        return hashMap;
    }

    /**
     * the public constructor of the class
     */
    public Tokenizer() {
        hashMap = new HashMap<>();
    }

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

    private void add(final String[] strings, final String k) {
        for (final String str : strings) {
            hashMap.putIfAbsent(str, new ArrayList<String>());
            hashMap.get(str).add(k);
        }
    }

    private void makeThemReady() {
        hashMap.forEach((k, v) -> {
            Set<String> set = new HashSet<String>(v);
            v = new ArrayList<>();
            v.addAll(set);
        });
    }
}