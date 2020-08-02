import java.io.File;
import java.util.HashSet;
import java.util.Scanner;
import java.util.Set;

public class Main {

    public static void main(final String[] args) {
        final FileReader fileReader = new FileReader();
        final Scanner scanner = new Scanner(System.in);
        File folder;
        // System.out.println("Enter the folders paths (Enter -1 for end)");
        String path;
        // while(!(path = scanner.nextLine()).equals("-1")) {
        //     folder = new File(path);
        //     fileReader.listFilesForFolder(folder);
        // }// terminal ejazeye write dari 

        fileReader.listFilesForFolder(new File("Docs"));

        Tokenizer tokenizer = new Tokenizer();
        tokenizer.init(fileReader);

        System.out.println("Enter the word to search for (enter -1 for ending the process)");
        Set<String> set = new HashSet<String>();
        while(!(path = scanner.next()).equals("-1")) {
            set.addAll(tokenizer.getHashMap().get(path));
        }
        //salam 
        // ok e hamechi ?
        set.forEach((k -> {
            System.out.println(k);
        }));
    }
}