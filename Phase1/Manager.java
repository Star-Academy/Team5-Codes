import java.io.File;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.Scanner;
import java.util.Set;

public class Manager {
    private Set<String> answer;
    private static Tokenizer data;
    private static final File file = new File("..\\Phase1\\Docs");
    private static final Scanner scanner = new Scanner(System.in);

    public Manager() {
        answer = new HashSet<>();
    }

    static void initialize() {
        final FileReader fileReader = new FileReader();
        fileReader.listFilesForFolder(file);
        fileReader.initWords();

        data = new Tokenizer();
        data.init(fileReader);
    }

    public void run() {

        answer = generateSearch(data);

        if (answer.isEmpty()
                || answer.contains("block this set, cuz there is no search result common between all of the words.")) {
            System.out.println("search un available");
        } else {
            answer.forEach((k -> {
                System.out.println(k);
            }));
        }

    }

    private Set<String> generateSearch(Tokenizer data) {
        String input = takeInput();
        if (input.equals("-1"))
            System.exit(0);
        String[] splitInput = input.split("\\s");

        Set<String> negativeWordsSet = new HashSet<String>();
        Set<String> noSignWordsSet = new HashSet<String>();

        modifySets(splitInput, data, answer, negativeWordsSet, noSignWordsSet);

        if (!noSignWordsSet.isEmpty())
            answer.addAll(noSignWordsSet);

        negativeWordsSet.forEach((k) -> {
            answer.remove(k);
        });
        return answer;
    }

    private static String takeInput() {
        System.out.println("Enter the phrase to search for");
        String input = scanner.nextLine();
        return input;
    }

    private static void modifySets(String[] splitInput, Tokenizer data, Set<String> answer, Set<String> negativeSet,
            Set<String> noSignSet) {
        for (String wordToSearch : splitInput) {
            String wordToSearchWithoutSign = wordToSearch.substring(1);
            switch (wordToSearch.charAt(0)) {
                case '+': // for or operation and for postive set
                    updateResultForAppropriateSet(data, answer, wordToSearchWithoutSign);
                    break;
                case '-': // for erasing the search results, update the negativeSet
                    updateResultForAppropriateSet(data, negativeSet, wordToSearchWithoutSign);
                    break;
                default: // if no special character occurs.
                    updateResultOfNoSignedWords(data, noSignSet, wordToSearch);
                    break;
            }
        }
    }

    /**
     * this method will update the words that don't have any sign behind them and
     * update the noSignSet that contains the & of search result of previous no
     * singed words.
     * 
     * @param data         is the data that the client gave program
     * @param noSignSet    is the set that contains the & of previous search results
     *                     and the elements of this set should operate & operation
     *                     between them and the new search results.
     * @param wordToSearch is the word that should be searched based on the input.
     */
    private static void updateResultOfNoSignedWords(Tokenizer data, Set<String> noSignSet, String wordToSearch) {
        if (noSignSet.contains("block this set, cuz there is no search result common between all of the words."))
            return;
        if (noSignSet.isEmpty() && data.getInvertedIndexMap().containsKey(wordToSearch.toLowerCase())) {
            System.out.println(data.getInvertedIndexMap().get(wordToSearch.toLowerCase()).size());
            noSignSet.addAll(data.getInvertedIndexMap().get(wordToSearch.toLowerCase()));
            return;
        }
        ArrayList<String> result = data.getInvertedIndexMap().get(wordToSearch.toLowerCase());
        if (result == null) {
            noSignSet.clear();
            noSignSet.add("block this set, cuz there is no search result common between all of the words.");
            return;
        }
        Set<String> afterAndResult = new HashSet<>();
        for (String string : result)
            if (noSignSet.contains(string))
                afterAndResult.add(string);
        noSignSet = afterAndResult;
    }

    /**
     * this method will update the results for the second element in the method
     * fields.
     * 
     * @param data                    is the data that the client gave program
     * @param answer                  is the set that want's itselft to be updated
     *                                by the results found for the wordToSeach.
     * @param wordToSearchWithoutSign is the word that we want to search for in our
     *                                data.
     */
    private static void updateResultForAppropriateSet(Tokenizer data, Set<String> answer,
            String wordToSearchWithoutSign) {
        if (data.getInvertedIndexMap().containsKey(wordToSearchWithoutSign.toLowerCase()))
            answer.addAll(data.getInvertedIndexMap().get(wordToSearchWithoutSign.toLowerCase()));
    }
}