import java.io.File;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        FileReader fileReader = new FileReader();
        Scanner scanner = new Scanner(System.in);
        File folder;
        System.out.println("Enter the folders paths (Enter -1 for end)");
        String path;
        while(!(path = scanner.nextLine()).equals("-1")) {
            folder = new File(path);
            fileReader.listFilesForFolder(folder);
        }
    }
}