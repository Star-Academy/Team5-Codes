public class Main {
    public static void main(final String[] args) {
        Manager.initialize();
        while (true) {
            System.out.println("Enter -1 when you want to finish the process.");
            Manager manager = new Manager();
            manager.run();
        }
    }
}  