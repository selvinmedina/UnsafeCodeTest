string saludo = "Hello, World!";
Console.WriteLine(saludo);

int total = 100;

unsafe
{
    int* punteroTotal = &total;
    Point point = new Point();
    double[] numerosAleatorios = { 0, 1.5, 2.3, 3.4, 4.0, 5.9 };

    Console.WriteLine((int)punteroTotal);

    int** punteroAPunteroTotal = &punteroTotal;
    Console.WriteLine((int)punteroAPunteroTotal);

    fixed (int* x = &point.x)
    {
        *x = 1;
    }

    fixed (double* y = &numerosAleatorios[1])
    {
        *y = 1;
    }

    fixed (double* p = &numerosAleatorios[0]) { /*...*/ }

    fixed (char* p = saludo)
    {
        *p = 'd';
    }

    Console.WriteLine(point.x);

    
    FixedSpanExample();

    int tamanio = 3;
    int* numeros = stackalloc int[tamanio];
    for (var i = 0; i < tamanio; i++)
    {
        numeros[i] = i;
    }

    Span<int> primero = stackalloc int[3] { 1, 2, 3 };
    Span<int> segundo = stackalloc int[] { 1, 2, 3 };
    ReadOnlySpan<int> tercero = stackalloc[] { 1, 2, 3 };

    int numeroDePrueba = 1024;

    byte* p1 = (byte*)&numeroDePrueba;

    Console.Write("The 4 bytes of the integer:");

    // Muestra los 4 bytes de la variable
    for (int i = 0; i < sizeof(int); ++i)
    {
        System.Console.Write(" {0:X2}", *p1);
        // Incrementando el puntero
        p1++;
    }
    System.Console.WriteLine();
    System.Console.WriteLine("El valor de numeroDePrueba: {0}", numeroDePrueba);
}

unsafe static void FixedSpanExample()
{
    int[] triangulosPascal = {
                  1,
                1,  1,
              1,  2,  1,
            1,  3,  3,  1,
          1,  4,  6,  4,  1,
        1,  5,  10, 10, 5,  1
    };

    Span<int> fila5 = new Span<int>(triangulosPascal, 10, 5);

    fixed (int* filaPuntero = fila5)
    {
        // Suma los numeros 1,4,6,4,1
        var sum = 0;
        for (int i = 0; i < fila5.Length; i++)
        {
            sum += *(filaPuntero + i);
        }
        Console.WriteLine(sum);
    }
}

public class Point
{
    public int x;
    public int y;
}