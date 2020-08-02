import java.io.File;
import java.util.HashSet;
import java.util.Scanner;
import java.util.Set;

public class Main {

    public static void main(final String[] args) {
        final FileReader fileReader = new FileReader();
        final Scanner scanner = new Scanner(System.in);
        fileReader.listFilesForFolder(new File("..\\Phase1\\Docs"));
 
        Tokenizer tokenizer = new Tokenizer();
        tokenizer.init(fileReader);
 
        System.out.println("Enter the phrase to search for");
        String input = scanner.nextLine();
        Set<String> set = new HashSet<String>();
        String[] splitInput = input.split("\\s");
        for (String str : splitInput) {
            if (tokenizer.getHashMap().containsKey(str.toLowerCase()))
                set.addAll(tokenizer.getHashMap().get(str.toLowerCase()));
        }
        if (set.isEmpty()) {
            System.out.println("search un available");
            System.exit(0);
        } else {
            set.forEach((k -> {
                System.out.println(k);
            }));
        }
    }
}