import java.io.File;

public class Main {
    public static void main(String[] args) {
        FileReader fileReader = new FileReader();
        final File folder = new File("C:\\Users\\home\\Desktop\\test");
        fileReader.listFilesForFolder(folder);
    }
}