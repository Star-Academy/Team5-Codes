import java.io.File;
import java.util.ArrayList;
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
        Set<String> ans = new HashSet<>();
        Set<String> set1 = new HashSet<String>();
        Set<String> set2 = new HashSet<String>();
        boolean flag = false;
        String[] splitInput = input.split("\\s");
        for (String str : splitInput) {
            String str2 = str.substring(1);
            switch (str.charAt(0)) {
                case '+':
                if (tokenizer.getHashMap().containsKey(str2.toLowerCase()))
                    ans.addAll(tokenizer.getHashMap().get(str2.toLowerCase()));
                    break;
                case '-':
                if (tokenizer.getHashMap().containsKey(str2.toLowerCase()))
                    set1.addAll(tokenizer.getHashMap().get(str2.toLowerCase()));
                    break;
                default:
                    if (set2.isEmpty() && tokenizer.getHashMap().containsKey(str2.toLowerCase())) {
                        set2.addAll(tokenizer.getHashMap().get(str2.toLowerCase()));
                        break;
                    }
                    Set<String> temp = new HashSet<>();
                    ArrayList<String> tmp = tokenizer.getHashMap().get(str2.toLowerCase());
                    if (tmp == null) {
                        flag = true;
                        break;
                    }
                    for (String string : tmp)
                        if (set2.contains(string))
                            temp.add(string);
                    set2 = temp; 
                    break;
            }
        }
        if (!flag)
            ans.addAll(set2);
        set2.forEach((k) -> {
            ans.remove(k);
        });
        if (ans.isEmpty()) {
            System.out.println("search un available");
            System.exit(0);
        } else {
            ans.forEach((k -> {
                System.out.println(k);
            }));
        }
    }
}