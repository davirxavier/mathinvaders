using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathHelper
{
    public static int CalculateResult(Operation op) {
        var result = 0;
        switch(op.operation) {
            case "+":
                result = op.firstOperand + op.secondOperand;
                break;
            case "-":
                result = op.firstOperand - op.secondOperand;
                break;
            case "/":
                result = op.firstOperand / op.secondOperand;
                break;
            case "*":
                result = op.firstOperand * op.secondOperand;
                break;
        }
        return result;
    }

    public static Operation CalculateOperations(string[] operations) {
        var operation = operations[(int)Random.Range(0, operations.Length)];

        var firstOperand = (int)Random.Range(0, 9);
        var secondOperand = operation.Equals("/") ? (int)Random.Range(1, 9) : (int)Random.Range(0, 9);
        if (operation.Equals("-") && secondOperand > firstOperand) {
            int tmp = firstOperand;
            firstOperand = secondOperand;
            secondOperand = tmp;
        } else if (operation.Equals("/")) {
            firstOperand = firstOperand * secondOperand;
        }

        var ret = new Operation();
        ret.firstOperand = firstOperand;
        ret.secondOperand = secondOperand;
        ret.operation = operation;
        ret.result = CalculateResult(ret);
        return ret;
    }
}

public class Operation {
    public int firstOperand;
    public int secondOperand;
    public string operation;
    public int result;
}
