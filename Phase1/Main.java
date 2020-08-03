import java.io.File;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.Scanner;
import java.util.Set;

public class Main {
    private static Scanner scanner;

    public static void main(final String[] args) {
        scanner = new Scanner(System.in);
        while (true) {
            System.out.println("Enter -1 when you want to finish the process.");
            Manager manager = new Manager();
            manager.run();
        }
    }

    private static class Manager {

        private static Set<String> answer = new HashSet<>();

        public void run() {
            final FileReader fileReader = new FileReader();
            fileReader.listFilesForFolder(new File(".\\Phase1\\Docs"));

            Tokenizer data = new Tokenizer();
            data.init(fileReader);

            answer = generateSearch(data);

            if (answer.isEmpty()) {
                System.out.println("search un available");
            } else {
                answer.forEach((k -> {
                    System.out.println(k);
                }));
            }

        }

        private static Set<String> generateSearch(Tokenizer data) {
            String input = takeInput();
            if (input.equals("-1")) 
                System.exit(0);
            String[] splitInput = input.split("\\s");

            Set<String> negativeSet = new HashSet<String>();
            Set<String> noSignSet = new HashSet<String>();
            boolean flag = modifySets(splitInput, data, answer, negativeSet, noSignSet);
            if (!flag)
                answer.addAll(noSignSet);
            negativeSet.forEach((k) -> {
                answer.remove(k);
            });
            return answer;
        }

        private static String takeInput() {
            System.out.println("Enter the phrase to search for");
            String input = scanner.nextLine();
            return input;
        }

        private static boolean modifySets(String[] splitInput, Tokenizer data, Set<String> answer,
                Set<String> negativeSet, Set<String> noSignSet) {
            boolean flag = false;
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
                        flag = updateResultOfNoSignedWords(data, noSignSet, wordToSearch, flag);
                        break;
                }
            }
            return flag;
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
         * @param flag         if true then it means that we don't have a common search
         *                     result among all of the no signed words.
         * @return flag after the operations.
         */
        private static boolean updateResultOfNoSignedWords(Tokenizer data, Set<String> noSignSet, String wordToSearch,
                boolean flag) {
            if (noSignSet.isEmpty() && data.getInvertedIndexMap().containsKey(wordToSearch.toLowerCase())) {
                noSignSet.addAll(data.getInvertedIndexMap().get(wordToSearch.toLowerCase()));
                return flag;
            }
            ArrayList<String> result = data.getInvertedIndexMap().get(wordToSearch.toLowerCase());
            if (result == null) { // we don't want to get in into the first if of this section twice.
                flag = true; // if the flag went true then it means there is no result for this search except
                             // ones from the other two cases.
                return flag;
            }
            Set<String> afterAndResult = new HashSet<>();
            for (String string : result)
                if (noSignSet.contains(string))
                    afterAndResult.add(string);
            noSignSet = afterAndResult;
            return flag;
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
}