using System;

namespace coreEscuela
{
    class Escuela
    {
        string nombre;
        string direccion;
        int añoFundacion;

        void Timbrar(){
            Console.Beep(10000, 3000);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
