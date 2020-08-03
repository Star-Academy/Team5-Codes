import java.io.File;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.Scanner;
import java.util.Set;
import java.lang.*;

public class Main {
    public static void main(final String[] args) {
        Manager manager = new Manager();
        manager.start();
    }

    private static class Manager extends Thread {

        private static Set<String> answer = new HashSet<>();

        @Override
        public void run() {
            final FileReader fileReader = new FileReader();
            fileReader.listFilesForFolder(new File(".\\Phase1\\Docs"));

            Tokenizer data = new Tokenizer();
            data.init(fileReader);

            answer = generateSearch(data);

            if (answer.isEmpty()) {
                System.out.println("search un available");
                System.exit(0);
            } else {
                answer.forEach((k -> {
                    System.out.println(k);
                }));
            }

        }

        private static Set<String> generateSearch(Tokenizer data) {
            final Scanner scanner = new Scanner(System.in);
            String input = takeInput(scanner);

            String[] splitInput = input.split("\\s");

            Set<String> negativeSet = new HashSet<String>();
            Set<String> noSingSet = new HashSet<String>();
            boolean flag = modifySets(splitInput, data, answer, negativeSet, noSingSet);
            if (!flag)
                answer.addAll(noSingSet);
            negativeSet.forEach((k) -> {
                answer.remove(k);
            });
            return answer;
        }

        private static String takeInput(final Scanner scanner) {
            System.out.println("Enter the phrase to search for");
            String input = scanner.nextLine();
            return input;
        }

        private static boolean modifySets(String[] splitInput, Tokenizer data, Set<String> answer,
                Set<String> negativeSet, Set<String> noSingSet) {
            boolean flag = false;
            for (String wordToSearch : splitInput) {
                String wordToSearchWithoutSign = wordToSearch.substring(1);
                switch (wordToSearch.charAt(0)) {
                    case '+': // for or operation
                        if (data.getInvertedIndexMap().containsKey(wordToSearchWithoutSign.toLowerCase()))
                            answer.addAll(data.getInvertedIndexMap().get(wordToSearchWithoutSign.toLowerCase()));
                        break;
                    case '-': // for erasing the search results
                        if (data.getInvertedIndexMap().containsKey(wordToSearchWithoutSign.toLowerCase()))
                            negativeSet.addAll(data.getInvertedIndexMap().get(wordToSearchWithoutSign.toLowerCase()));
                        break;
                    default: // if no special character occurs.
                        if (noSingSet.isEmpty() && data.getInvertedIndexMap().containsKey(wordToSearch.toLowerCase())) {
                            noSingSet.addAll(data.getInvertedIndexMap().get(wordToSearch.toLowerCase()));
                            break;
                        }
                        Set<String> afterAndResult = new HashSet<>();
                        ArrayList<String> result = data.getInvertedIndexMap().get(wordToSearch.toLowerCase());
                        if (result == null) { // we don't want to get in into the first if of this section twice.
                            flag = true; // if the flag went true then it means there is no result for this search
                                         // except ones from the other two cases.
                            break;
                        }
                        for (String string : result)
                            if (noSingSet.contains(string))
                                afterAndResult.add(string);
                        noSingSet = afterAndResult;
                        break;
                }
            }
            return flag;
        }
    }
}