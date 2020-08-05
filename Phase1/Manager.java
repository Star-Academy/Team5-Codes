import java.io.File;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.Scanner;
import java.util.Set;

public class Manager {
    private Set<String> answer;
    private static Tokenizer data;
    private static final File file = new File(".\\Team5-Codes\\Phase1\\Docs");
    private static final Scanner scanner = new Scanner(System.in);
    private static Set<String> mustContainWords = new HashSet<String>();


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
            System.out.println("Number of results: " + answer.size());
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

        Set<String> notContainWords = new HashSet<String>();

        modifySets(splitInput, data, answer, notContainWords);

        if (!mustContainWords.isEmpty())
            answer.addAll(mustContainWords);

        notContainWords.forEach((k) -> {
            answer.remove(k);
        });
        return answer;
    }

    private static String takeInput() {
        System.out.println("Enter the phrase to search for");
        String input = scanner.nextLine();
        return input;
    }

    private static void modifySets(String[] splitInput, Tokenizer data, Set<String> answer, Set<String> notContainWords) {
        for (String wordToSearch : splitInput) {
            String wordToSearchWithoutSign = wordToSearch.substring(1);
            switch (wordToSearch.charAt(0)) {
                case '+': // for or operation and for postive set
                    updateResultForAppropriateSet(data, answer, wordToSearchWithoutSign);
                    break;
                case '-': // for erasing the search results, update the negativeSet
                    updateResultForAppropriateSet(data, notContainWords, wordToSearchWithoutSign);
                    break;
                default: // if no special character occurs.
                    updateResultOfNoSignedWords(data, wordToSearch);
            }
        }
    }

    /**
     * this method will update the words that don't have any sign behind them and
     * update the noSignSet that contains the & of search result of previous no
     * singed words.
     * 
     * @param data             is the data that the client gave program
     * @param mustContainWords is the set that contains the & of previous search
     *                         results and the elements of this set should operate &
     *                         operation between them and the new search results.
     * @param wordToSearch     is the word that should be searched based on the
     *                         input.
     */
    private static void updateResultOfNoSignedWords(Tokenizer data, String wordToSearch) {
        if (mustContainWords.contains("block this set, cuz there is no search result common between all of the words."))
            return;
        if (mustContainWords.isEmpty() && data.getInvertedIndexMap().containsKey(wordToSearch.toLowerCase())) {
            mustContainWords.addAll(data.getInvertedIndexMap().get(wordToSearch.toLowerCase()));
            return;
        }
        ArrayList<String> result = data.getInvertedIndexMap().get(wordToSearch.toLowerCase());
        if (result == null) {
            mustContainWords.clear();
            mustContainWords.add("block this set, cuz there is no search result common between all of the words.");
            return;
        }
        mustContainWords = takeTheCommonDocs(mustContainWords, result);
    }

    private static Set<String> takeTheCommonDocs(Set<String> mustContainWords, ArrayList<String> result) {
        Set<String> afterAndResult = new HashSet<>();
        for (String string : result)
            if (mustContainWords.contains(string))
                afterAndResult.add(string);
        return afterAndResult;
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