using System.Collections;
using System.Globalization;

static int sumNumbers( int start, int stop) {

    if (start == stop)
    {
        return start;
    }
    else if (start > stop)
    {
        return 0;
    }
    else
    {
        return start + sumNumbers(start + 1, stop);
    }
}

sumNumbers(1, 10);

//Simplified version 
static int sumNumbersSimple(int n)
{
    if (n == 1)
    {
        return 1;
    }
    else
    {
        return n + sumNumbersSimple(n - 1);
    }
}

sumNumbersSimple(10);