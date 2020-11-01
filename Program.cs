using System;
using System.Collections.Generic;
using CoreEscuela;
using CoreEscuela.Entidades;

namespace coreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            var engine = new EscuelaEngine();
            engine.Inicializar();
        }
    }
}
