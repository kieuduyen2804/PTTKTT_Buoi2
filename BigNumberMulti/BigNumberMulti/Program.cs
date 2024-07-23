using System;
using System.Numerics;

public class BigNumberMultiplication
{
    public static void Main(string[] args)
    {
        BigInteger X = BigInteger.Parse("123456789");
        BigInteger Y = BigInteger.Parse("987654321");
        int n = Math.Max(X.ToString().Length, Y.ToString().Length);

        BigInteger result = BigNumberMulti(X, Y, n);
        Console.WriteLine("Result: " + result);
    }

    public static BigInteger BigNumberMulti(BigInteger X, BigInteger Y, int n)
    {
        BigInteger m1, m2, m3, A, B, C, D;
        int s;

        s = (X.Sign * Y.Sign);
        X = BigInteger.Abs(X);
        Y = BigInteger.Abs(Y);

        if (n == 1)
        {
            return X * Y * s;
        }
        else
        {
            int m = n / 2;
            A = Left(X, m);
            B = Right(X, m);
            C = Left(Y, m);
            D = Right(Y, m);

            m1 = BigNumberMulti(A, C, m);
            m2 = BigNumberMulti(A - B, D - C, m);
            m3 = BigNumberMulti(B, D, m);

            return s * (m1 * BigInteger.Pow(10, n) + (m1 + m2 + m3) * BigInteger.Pow(10, m) + m3);
        }
    }

    public static BigInteger Left(BigInteger num, int m)
    {
        string numStr = num.ToString();
        if (numStr.Length <= m)
        {
            return num;
        }
        return BigInteger.Parse(numStr.Substring(0, numStr.Length - m));
    }

    public static BigInteger Right(BigInteger num, int m)
    {
        string numStr = num.ToString();
        if (numStr.Length <= m)
        {
            return num;
        }
        return BigInteger.Parse(numStr.Substring(numStr.Length - m));
    }
}
