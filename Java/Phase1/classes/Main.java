/**
 * The main class of the project which contains the starting point of the
 * program.
 * @see Manager 
 */
package classes;

import java.util.Scanner;
import java.util.Set;

public class Main {

    private static final Scanner scanner = new Scanner(System.in);

    /**
     * the main method of the application this method initializes the document data
     * that we stored in Docs folder and run the application in an infinite loop for
     * stoping the app you should enter -1 in the console when ehtering the search.
     * 
     * @param args is the command arguments that we tend to give the program.
     */
    public static void main(final String[] args) {
        Manager.initialize(); // initializing the documents and making them ready for invertedIndexSearch
        while (true) { // inifite loop for taking infinite tasks from user
            System.out.println("Enter -1 when you want to finish the process.");

            Manager manager = new Manager(new MyScanner(){
                public String takeInput() {
                    System.out.println("Enter the phrase to search for");
                    final String input = scanner.nextLine();
                    return input;
                }
            });
            
            Set<String> output = manager.run(); // managing the input from user.
            for (String doc : output) {
                System.out.println(doc);
            }
        }
    }
}