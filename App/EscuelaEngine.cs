using System.Collections.Generic;
using CoreEscuela.Entidades;

namespace CoreEscuela
{
    public class EscuelaEngine
    {
        public Escuela Escuela { get; set; }

        public EscuelaEngine()
        {
            
        }

        public void Inicializar()
        {
            var Escuela = new Escuela("Dap Academy", 2020, TiposEscuela.Primaria, ciudad: "Aguachica");
            Escuela.Pais = "Canadá";
            Escuela.Ciudad = "Toronto";
            Escuela.TipoEscuela = TiposEscuela.Secundaria;


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

            Escuela.Cursos = arregloCursos;
            Escuela.CursosList = listaCursos;

            Curso temporal = new Curso { Nombre = "401", Jornada = TiposJornada.Tarde };

            Escuela.CursosList.Add(temporal);
            Escuela.CursosList.Remove(temporal);

            //remueve un objeto de lista haciendo match con expresion lambda
            Escuela.CursosList.RemoveAll(obj => obj.Nombre == "201");

            Escuela.imprimirCursos();
            Escuela.imprimirCursosList();
        }
    }
}
