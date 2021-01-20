import java.util.*;

public class stockBoard {

    private static int[][] allValues = new int[7][3];
    private static String[][] allAnswers = new String[7][5];

    public static void main(String[] args) {
        Scanner inputScanner = new Scanner(System.in);
        System.out.println("Enter Starting Value for 1:");
        int input1 = inputScanner.nextInt();
        System.out.println("Enter Starting Value for 2:");
        int input2 = inputScanner.nextInt();
        System.out.println("Enter Starting Value for 3:");
        int input3 = inputScanner.nextInt();
        int[] input = new int[] { input1, input2, input3 };
        inputScanner.close();
        solveFor(input);
    }

    public static String[] solveForHelper(int[] input, String[] result, int currSize) {

        if (currSize == 5) {
            switch (numCount(input, 8)) {
                case 3:
                    System.out.println("Change 1");
                    allValues[3] = input;
                    for (int i = 0; i < 5; i++) {
                        allAnswers[3][i] = result[i];
                    }
                    break;
                case 2:
                    if (arrayNull(allValues[2]) && sumArray(input) == 23) {
                        System.out.println("Change 2");
                        allValues[2] = input;
                        for (int i = 0; i < 5; i++) {
                            allAnswers[2][i] = result[i];
                        }
                    } else if (arrayNull(allValues[4]) && sumArray(input) == 25) {
                        System.out.println("Change 3");
                        allValues[4] = input;
                        for (int i = 0; i < 5; i++) {
                            allAnswers[4][i] = result[i];
                        }
                    }
                    break;
                case 1:
                    if (arrayNull(allValues[1]) && sumArray(input) == 22 && numCount(input, 7) == 2) {
                        System.out.println("Change 4");
                        allValues[1] = input;
                        for (int i = 0; i < 5; i++) {
                            allAnswers[1][i] = result[i];
                        }
                    } else if (arrayNull(allValues[3]) && sumArray(input) == 24 && numCount(input, 7) == 1
                            && numCount(input, 9) == 1) {
                        System.out.println("Change 5");
                        allValues[3] = input;
                        for (int i = 0; i < 5; i++) {
                            allAnswers[3][i] = result[i];
                        }
                    }

                    else if (arrayNull(allValues[5]) && sumArray(input) == 26 && numCount(input, 9) == 2) {
                        System.out.println("Change 6");
                        allValues[5] = input;
                        for (int i = 0; i < 5; i++) {
                            allAnswers[5][i] = result[i];
                        }
                    }
                    break;
                default:
                    if (arrayNull(allValues[0]) && sumArray(input) == 21 && numCount(input, 7) == 3) {
                        System.out.println("Change 7");
                        allValues[0] = input;
                        for (int i = 0; i < 5; i++) {
                            allAnswers[0][i] = result[i];
                        }
                    } else if (arrayNull(allValues[2]) && sumArray(input) == 23 && numCount(input, 7) == 2
                            && numCount(input, 9) == 1) {
                        System.out.println("Change 8");
                        allValues[2] = input;
                        for (int i = 0; i < 5; i++) {
                            allAnswers[2][i] = result[i];
                        }
                    } else if (arrayNull(allValues[4]) && sumArray(input) == 25 && numCount(input, 7) == 1
                            && numCount(input, 9) == 2) {
                        System.out.println("Change 9");
                        allValues[4] = input;
                        for (int i = 0; i < 5; i++) {
                            allAnswers[4][i] = result[i];
                        }
                    } else if (arrayNull(allValues[6]) && sumArray(input) == 27 && numCount(input, 9) == 3) {
                        System.out.println("Change 10");
                        allValues[6] = input;
                        for (int i = 0; i < 5; i++) {
                            allAnswers[6][i] = result[i];
                        }
                    }
                    break;
            }

            return result;
        }

        int[] Resource1 = new int[] { 3, 0, -1 };
        int[] Resource2 = new int[] { -3, -2, 3 };
        int[] Resource3 = new int[] { 2, 0, -2 };
        int[] Resource4 = new int[] { -2, 2, 0 };
        int[] Resource5 = new int[] { 0, -3, 2 };
        int[] Resource6 = new int[] { 0, 3, -2 };

        int[] IStart = addArrays(Resource1, input);
        int[] BStart = addArrays(Resource2, input);
        int[] DStart = addArrays(Resource3, input);
        int[] OStart = addArrays(Resource4, input);
        int[] EStart = addArrays(Resource5, input);
        int[] TStart = addArrays(Resource6, input);

        result[currSize] = "Resource1";
        String[] Iresult = solveForHelper(IStart, result, currSize + 1);

        result[currSize] = "Resource2";
        String[] Bresult = solveForHelper(BStart, result, currSize + 1);

        result[currSize] = "Resource3";
        String[] Dresult = solveForHelper(DStart, result, currSize + 1);

        result[currSize] = "Resource4";
        String[] Oresult = solveForHelper(OStart, result, currSize + 1);

        result[currSize] = "Resource5";
        String[] Eresult = solveForHelper(EStart, result, currSize + 1);

        result[currSize] = "Resource6";
        String[] Tresult = solveForHelper(TStart, result, currSize + 1);

        return null;
    }

    public static void solveFor(int[] input) {

        int[] Resource1 = new int[] { 3, 0, -1 };
        int[] Resource2 = new int[] { -3, -2, 3 };
        int[] Resource3 = new int[] { 2, 0, -2 };
        int[] Resource4 = new int[] { -2, 2, 0 };
        int[] Resource5 = new int[] { 0, -3, 2 };
        int[] Resource6 = new int[] { 0, 3, -2 }

        int[] IStart = addArrays(Resource1, input);
        int[] BStart = addArrays(Resource2, input);
        int[] DStart = addArrays(Resource3, input);
        int[] OStart = addArrays(Resource4, input);
        int[] EStart = addArrays(Resource5, input);
        int[] TStart = addArrays(Resource6, input);

        String[] IString = new String[] { "Resource1", "", "", "", "" };
        String[] BString = new String[] { "Resource1", "", "", "", "" };
        String[] DString = new String[] { "Resource1", "", "", "", "" };
        String[] OString = new String[] { "Resource1", "", "", "", "" };
        String[] EString = new String[] { "Resource1", "", "", "", "" };
        String[] TString = new String[] { "Resource1", "", "", "", "" };

        String[] Iresult = solveForHelper(IStart, IString, 1);
        String[] Bresult = solveForHelper(BStart, BString, 1);
        String[] Dresult = solveForHelper(DStart, DString, 1);
        String[] Oresult = solveForHelper(OStart, OString, 1);
        String[] Eresult = solveForHelper(EStart, EString, 1);
        String[] Tresult = solveForHelper(TStart, TString, 1);

        printResult(allValues, allAnswers);
    }

    public static int sumArray(int[] input) {
        return input[0] + input[1] + input[2];
    }

    public static int[] addArrays(int[] input1, int[] input2) {
        int input11 = input1[0] + input2[0];
        if (input11 < 0) {
            input11 = 0;
        }
        int input22 = input1[1] + input2[1];
        if (input22 < 0) {
            input22 = 0;
        }
        int input33 = input1[2] + input2[2];
        if (input33 < 0) {
            input33 = 0;
        }
        int[] newResult = new int[] { input11, input22, input33 };
        return newResult;
    }

    public static void printResult(int[][] values, String[][] answer) {
        for (int i = 0; i < 7; i++) {
            System.out.println(Arrays.toString(answer[i]) + "" + Arrays.toString(values[i]) + "" + sumArray(values[i]));
        }
    }

    public static int numCount(int[] input, int value) {
        int num = 0;
        if (input[0] == value) {
            num++;
        }
        if (input[1] == value) {
            num++;
        }
        if (input[2] == value) {
            num++;
        }
        return num;
    }

    public static boolean arrayNull(int[] input) {
        if (input[0] == 0) {
            return true;
        }
        return false;
    }

    public static boolean arrayNull(String[] input) {
        if (input[0] == null) {
            return true;
        }
        return false;
    }
}
