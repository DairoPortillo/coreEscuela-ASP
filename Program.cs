using System;
using CoreEscuela.Entidades;

namespace coreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            var escuela = new Escuela("Dap Academy", 2020, TiposEscuela.Primaria, ciudad: "Aguachica");
            escuela.Pais = "Canadá";
            escuela.Ciudad = "Toronto";
            escuela.TipoEscuela = TiposEscuela.Secundaria;

            // Curso[] arregloCursos = {
            //     new Curso {Nombre = "101"},
            //     new Curso {Nombre = "201"},
            //     new Curso {Nombre = "301"}
            // };

            // escuela.Cursos = arregloCursos;

            escuela.imprimirCursos();
        }
    }
}
