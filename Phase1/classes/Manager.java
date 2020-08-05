import java.io.File;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.Scanner;
import java.util.Set;

/**
 * this class is responsible for managing the user queries. this class read the
 * query then process the answer with InvertedIndex Search after that it will
 * print the results in the console future changes such as modifying where to
 * read query or where to write results can be made easily from this class.
 *
 */
public class Manager {
    private Set<String> answer;
    private static InvertedIndexSearch data;
    private static final File file = new File("Docs");
    private static final Scanner scanner = new Scanner(System.in);
    private static Set<String> mustContainWords;

    {
        mustContainWords = new HashSet<String>();
    }

    /**
     * this is a public constructor for our class.
     */
    public Manager() {
        answer = new HashSet<>();
    }

    /**
     * in this method we will collect our datas from the documents, which is for
     * giving the datas to the invertedIndexSearch class.
     */
    static void initialize() {
        final DataCollector datacollector = new DataCollector();
        datacollector.listFilesForFolder(file);
        datacollector.initWords();

        data = new InvertedIndexSearch();
        data.init(datacollector);
    }

    /**
     * in this class we will handle a single query from the user. we will read the
     * search, processing the results based on the input and then printing the
     * answers to the console.
     */
    public void run() {
        final String input = takeInput(); // reading the inputs from the user.
        if (input.equals("-1")) // ending the program if user want to.
            System.exit(0);
        final String[] splitInput = input.split("\\s"); // spliting the words from each other.

        answer = generateSearch(data, splitInput); // generating the results.

        // printing the results for the user in the console
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

    /**
     * this method will handle the query based on the inputs that the user gave us.
     * 
     * @param data is the InvertedIndexSearch field for reading the datas and gaining the occurenses of each word.
     * @param splitInput is the search phrase that client enter.
     * 
     * @return a Set<String> containing the query results.
     */
    private Set<String> generateSearch(final InvertedIndexSearch data, final String[] splitInput) {

        final Set<String> notContainWords = new HashSet<String>(); //results of the words that their results are forbidden to show.

        modifySets(splitInput, data, answer, notContainWords); // generating the answers.

        if (!mustContainWords.isEmpty()) // adding the results of the + signed words.
            answer.addAll(mustContainWords);
 
        notContainWords.forEach((k) -> { // removing the result of forbidden words.
            answer.remove(k);
        });
        return answer; 
    }

    /**
     * this method will take the input from the console 
     * it will read a single line.
     */
    private static String takeInput() {
        System.out.println("Enter the phrase to search for");
        final String input = scanner.nextLine();
        return input;
    }

    /**
     * this method will add the result to the appropriate sets by reading the input words one by one.
     * 
     * @param splitInput is the input of the user.
     * @param data is the InvertedIndex datas that we build from our docs.
     * @param answer is the set that should be modified for results.
     * @param notContainWords is the set of minus signed words.(that words that thier results are forbidden to show)
     */
    private static void modifySets(final String[] splitInput, final InvertedIndexSearch data, final Set<String> answer,
            final Set<String> notContainWords) {
        for (final String wordToSearch : splitInput) {
            final String wordToSearchWithoutSign = wordToSearch.substring(1);
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
    private static void updateResultOfNoSignedWords(final InvertedIndexSearch data, final String wordToSearch) {
        if (mustContainWords.contains("block this set, cuz there is no search result common between all of the words."))
            return;
        if (mustContainWords.isEmpty() && data.getInvertedIndexMap().containsKey(wordToSearch.toLowerCase())) { // if it's for the first time we see a word then we must add all of the results.
            mustContainWords.addAll(data.getInvertedIndexMap().get(wordToSearch.toLowerCase()));
            return;
        }
        final ArrayList<String> result = data.getInvertedIndexMap().get(wordToSearch.toLowerCase()); // this section is for doing the and operation.
        if (result == null) {
            mustContainWords.clear();
            mustContainWords.add("block this set, cuz there is no search result common between all of the words."); // we must forbid the method to add any other result after this line.
            return;
        }
        mustContainWords = takeTheCommonDocs(mustContainWords, result);// updating the set.
    }

    /**
     * this method will do the and operation between two collection of results.
     * it's basically returning a Set containing common results among two collections.
     * @param mustContainWords is one of the collections that we want to do the and operation on and it should be Set<String>
     * @param result is another side of the and operation and its type should be ArrayList<String>
     * 
     * @return a Set<String> containing the common results in the two collections.
     */
    private static Set<String> takeTheCommonDocs(final Set<String> mustContainWords, final ArrayList<String> result) {
        final Set<String> afterAndResult = new HashSet<>();
        for (final String string : result)
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
    private static void updateResultForAppropriateSet(final InvertedIndexSearch data, final Set<String> answer,
            final String wordToSearchWithoutSign) {
        if (data.getInvertedIndexMap().containsKey(wordToSearchWithoutSign.toLowerCase()))
            answer.addAll(data.getInvertedIndexMap().get(wordToSearchWithoutSign.toLowerCase()));
    }
}