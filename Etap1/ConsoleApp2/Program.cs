

using System;





public class ExThread {
  
    // Non-static method
    public void mythread1(int thread_number, double[] x_table)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        System.Threading.Thread.Sleep(1000*thread_number);
        Console.WriteLine(" ");
        Console.WriteLine(" ");
        Console.WriteLine(" ");
        for(int i=0;i<x_table.Length;i++){

            Console.Write(x_table[i]+",");
        }
        for (int z = 0; z < 3; z++) {
            // Console.WriteLine("First Thread");
            System.Threading.Thread.Sleep(100);
        }
        watch.Stop();
        var elapsedMs = watch.ElapsedMilliseconds;


        Console.WriteLine("thread number: "+thread_number+"  time: "+elapsedMs);
    }
}

// Driver Class
public class GFG {
  
    // Main Method
    public static void Main()
    {
        // Creating object of ExThread class
        int n = 100;
        int N = 100;
        double a = -1;
        double b = 1;
        double h = (b - a) / N;

        double Fx0 = 0;
        double Fxn = 0;
        decimal Result = 0;
        int thread_number = 10;


        var watch = System.Diagnostics.Stopwatch.StartNew();
        // the code that you want to measure comes here


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
            

            // Console.WriteLine("Hello, World!");
            // Console.WriteLine(T3);
            // Console.WriteLine(F);

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

        // double [][] create_table2 (double a, double b, int N){
        //     int len_of_subarray = N/thread_number;
        //     double[][] array_of_tables = new double[thread_number][];


        //     double[] array = new double[N-2];
        //     double delta = (b - a) / (N-1);

        //     array[0] = a + delta;


        //     int counter = 0;
        //     int counter2 = 0;
        //     for (int i = 0; i < N-3; i++)
        //     {
        //         array[i+1] = array [i] + delta;
        //     }

        //     return array_of_tables;

        // }

        double [][] divide_table(double[] table){
            int len_of_subarray = N/thread_number;
            double[][] array_of_tables = new double[thread_number][];
            
            int counter = 0;
            int counter2 = 0;
            double[] subarr = new double[len_of_subarray];
            for(int i =0;i<table.Length;i++){
                
                subarr[counter]= table [i];
                counter ++;
                if(counter >= len_of_subarray){
                    array_of_tables[counter2] = new double[len_of_subarray];
                    Array.Copy(subarr,array_of_tables[counter2],len_of_subarray);
                    subarr = new double[len_of_subarray];
                    counter = 0;
                    counter2++;
                    Console.WriteLine("counter2: "+ counter2);
                }
            }
            return array_of_tables;
        }

        // double [][] divide_table2(double[] table){
        //     int len_of_subarray = N/thread_number;
        //     double[][] array_of_tables = new double[thread_number][];
        //     for(int i = 0; i < table.Length; i+=100)
        //     {

        //         buffer = new double[100];
        //         Array.Copy(table, i, buffer, 0, 100);
        //         // process array
        //     }
        //     return buffer;
        // }


        double Fx = Chebyshev(3);

        double[] Table = new double[N - 2];
        Table = create_table(a, b, N);
        double [][] divided_tables = divide_table(Table);
        // Console.WriteLine("item"+divided_tables[0][2000]);
        // for (int i = 0; i < N - 2; i++)
        // {
        //     Console.WriteLine(Table[i]);
        // }

        Console.WriteLine(Table.Length);


        Fx0 = h / 2 * Chebyshev(a);
        Fxn = h / 2 * Chebyshev(b);

        for (int i=0; i<N-2; i++)
        {
            Result = Result + System.Convert.ToDecimal(h * Chebyshev(Table[i]));
        }

        Result = Result + System.Convert.ToDecimal(Fx0 + Fxn);

        watch.Stop();
        var elapsedMs = watch.ElapsedMilliseconds;

        Console.WriteLine("Result: "+ Result);
        Console.WriteLine("time: "+ elapsedMs);

        // Console.Write(divided_tables);


        ExThread obj = new ExThread();


        Thread[] threads_array = new Thread[thread_number];
        for(int i =0; i<thread_number;i++){
            threads_array[i] = new Thread(()=>obj.mythread1(i, divided_tables[i]));
            threads_array[i].Start();
        }
        
        for(int i =0; i<thread_number;i++){
            threads_array[i].Join();
        }
        // Creating thread
        // Using thread class
        
        Console.WriteLine("joined add threads");
    }

}