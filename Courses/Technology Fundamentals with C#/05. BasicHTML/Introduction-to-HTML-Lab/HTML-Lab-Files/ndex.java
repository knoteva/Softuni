import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.*;
import java.util.stream.Collectors;


public class test {

    public static void main(String[] args) throws IOException {

        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        List<Integer> list = Arrays.stream(reader.readLine().split(" "))
                .map(Integer::parseInt)
                .collect(Collectors.toList());
        double leftResult = 0;
        double rightResult = 0;
        List<Integer> leftSide = list.subList(0, list.size() / 2);
        List<Integer> rightSide = list.subList((list.size() / 2) + 1, list.size());
        String side = "";


        for (int element : leftSide) {
            leftResult = element > 0 ? element + leftResult : leftResult * 0.8;
        }
        for (int element : rightSide) {
            rightResult = element > 0 ? element + rightResult : rightResult * 0.8;
        }


            if (leftResult < rightResult) {
                side = "left";
                System.out.printf("The winner is %s with total time: %.1f", side, leftResult);
            } else if (leftResult > rightResult) {
                side = "right";
                System.out.printf("The winner is %s with total time: %.1f", side, rightResult);

        }
    }
}