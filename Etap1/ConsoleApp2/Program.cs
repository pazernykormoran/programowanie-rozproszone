


int n = 100;
int N = 1000000;
double a = -1;
double b = 1;
double h = (b - a) / N;

double Fx0 = 0;
double Fxn = 0;
decimal Result = 0;

double Chebyshev(double x)
{
    double T1, T2, T3;
    double F = 0;

    T1 = 1;
    T2 = x;
    T3 = 0;

    for (int i = 0; i < n; i++)
    {
        T3 = 2 * x * T2 - T1;
        T1 = T2;
        T2 = T3;
    }
    F = Math.Sqrt(Math.Sqrt(Math.Abs(T3)));
    

    Console.WriteLine("Hello, World!");
    Console.WriteLine(T3);
    Console.WriteLine(F);

    return F;
}

double [] create_table (double a, double b, int N){
    double[] array = new double[N-2];
    double delta = (b - a) / (N-1);

    array[0] = a + delta;

    for (int i = 0; i < N-3; i++)
    {
        array[i+1] = array [i] + delta;
    }

    return array;

}


double Fx = Chebyshev(3);

double[] Table = new double[N - 2];
Table = create_table(a, b, N);

for (int i = 0; i < N - 2; i++)
{
    Console.WriteLine(Table[i]);
}

Console.WriteLine(Table.Length);


Fx0 = h / 2 * Chebyshev(a);
Fxn = h / 2 * Chebyshev(b);

for (int i=0; i<N-2; i++)
{
    Result = Result + System.Convert.ToDecimal(h * Chebyshev(Table[i]));
}

Result = Result + System.Convert.ToDecimal(Fx0 + Fxn);

Console.WriteLine(Result);
