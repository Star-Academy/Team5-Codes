import java.io.File;
import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;
import java.util.Set;


public class Tokenizer {
    /**
     * key is the word and value is the places that the word occures.
     */
    private final HashMap<String, ArrayList<String>> hashMap;

    public Tokenizer() {
        hashMap = new HashMap<>();
    }

    public void init() {
        final FileReader fileReader = new FileReader();
        fileReader.listFilesForFolder(new File("Docs"));
        final Map<String, ArrayList<String>> documents = fileReader.getDocumentsWords();// {doc, word}
        documents.forEach((k, v) -> {
            for (final String str : v) {
                final String[] strings = str.split(" ");
                add(strings, k);
            }
        });

    }

    private void add(final String[] strings, final String k) {
        for (final String str : strings) {
            hashMap.putIfAbsent(str, new ArrayList<String>());
            hashMap.get(str).add(k);
        }
    }

    private void finalize() {
        hashMap.forEach((k, v) -> {
           Set<String> set = new HashSet<String>(v);
           v = new ArrayList<>();
           String[] tmp = (String[])set.toArray();
            for (String ss : tmp)
                v.add(ss);
        });
    }
}