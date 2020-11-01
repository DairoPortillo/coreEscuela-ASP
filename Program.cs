using System;
using System.Collections.Generic;
using System.Linq;
using coreEscuela.Entidades;
using CoreEscuela;
using CoreEscuela.Entidades;
using CoreEscuela.Util;

namespace coreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            var engine = new EscuelaEngine();
            engine.Inicializar();

            var listaObjetos = engine.TraerObjetosEscuela();

            var listaILugar = from obj in listaObjetos 
                                where obj is ILugar
                                select (ILugar) obj;
        }
    }
}
