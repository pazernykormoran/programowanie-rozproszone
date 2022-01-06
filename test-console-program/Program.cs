// See https://aka.ms/new-console-template for more information
using System;

public class ExThread {
  
    // Non-static method
    public void mythread1()
    {
        for (int z = 0; z < 3; z++) {
            Console.WriteLine("First Thread");
            System.Threading.Thread.Sleep(1000);
        }
    }
}
  
// Driver Class
public class GFG {
  
    // Main Method
    public static void Main()
    {
        // Creating object of ExThread class
        ExThread obj = new ExThread();
  
        // Creating thread
        // Using thread class
        Thread thr = new Thread(new ThreadStart(obj.mythread1));
        thr.Start();
        thr.Join();
        Console.WriteLine("joined");
    }
}