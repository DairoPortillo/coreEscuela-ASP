using System;
using System.Collections.Generic;
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

            
            var listaCursos = new List<Curso>(){
                new Curso {Nombre = "101"},
                new Curso {Nombre = "201"},
                new Curso {Nombre = "301"}
            };


            Curso[] arregloCursos = {
                new Curso {Nombre = "101"},
                new Curso {Nombre = "201"},
                new Curso {Nombre = "301"}
            };

            escuela.Cursos = arregloCursos;
            escuela.CursosList = listaCursos;

            Curso temporal = new Curso{Nombre = "401", Jornada = TiposJornada.Tarde};

            escuela.CursosList.Add(temporal);
            escuela.CursosList.Remove(temporal);

            //remueve un objeto de lista haciendo match
            escuela.CursosList.RemoveAll(obj => obj.Nombre == "201");

            escuela.imprimirCursos();
            escuela.imprimirCursosList();
        }
    }
}
