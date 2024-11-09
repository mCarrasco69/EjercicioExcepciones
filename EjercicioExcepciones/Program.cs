public class Program
{
    public static void MostrarMenu()
    {
        Console.WriteLine("&&&&&&&& :Menú de Operaciones: &&&&&&&&&&&&");
        Console.WriteLine("1. Sumar");
        Console.WriteLine("2. Restar");
        Console.WriteLine("3. Multiplicar");
        Console.WriteLine("4. Dividir");
        Console.WriteLine("5. Salir");
    }

     public static int ObtenerOpcion()
    {
        while (true)
        {
            try
            {
                Console.Write("Seleccione una opción: ");
                int opcion = int.Parse(Console.ReadLine());
                if (opcion >= 1 && opcion <= 5)
                {
                    return opcion;
                }
                else
                {
                    Console.WriteLine("Por favor, seleccione una opción válida (1-5).");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Entrada no válida. no sea burro y lea ahi dice numeros elija uno de 1 a 5.");
            }
        }
    }

    public static (double, double) ObtenerNumeros()
    {
        while (true)
        {
            try
            {
                Console.Write("Ingrese el primer número: ");
                double a = double.Parse(Console.ReadLine());
                Console.Write("Ingrese el segundo número: ");
                double b = double.Parse(Console.ReadLine());
                return (a, b);
            }
            catch (FormatException)
            {
                Console.WriteLine("Entrada no válida. que terco ponga numero validos .");
            }
        }
    }

   public  static void Main(string[] args)
    {
        Operaciones operaciones = new Operaciones();
        while (true)
        {
            MostrarMenu();
            int opcion = ObtenerOpcion();

            if (opcion == 5)
            {
                Console.WriteLine("Saliendo del programa...");
                break;
            }

            var (a, b) = ObtenerNumeros();

            try
            {
                double resultado = opcion switch
                {
                    1 => operaciones.Sumar(a, b),
                    2 => operaciones.Restar(a, b),
                    3 => operaciones.Multiplicar(a, b),
                    4 => operaciones.Dividir(a, b),
                    _ => throw new InvalidOperationException("Opción no válida.")
                };
                Console.WriteLine($"Resultado: {resultado}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}