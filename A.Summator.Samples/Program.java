import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Program {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        int testCaseCount = Integer.parseInt(reader.readLine());
        for (int i = 0; i < testCaseCount; i++) {
            String[] lineItems = reader.readLine().split(" ");
            int a = Integer.parseInt(lineItems[0]);
            int b = Integer.parseInt(lineItems[1]);
            System.out.println(a + b);
        }
    }
}
