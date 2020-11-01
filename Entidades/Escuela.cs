using System.Collections.Generic;
using Util;

namespace CoreEscuela.Entidades
{
    public class Escuela
    {
        public string UniqueId { get; private set; } = System.Guid.NewGuid().ToString();
        string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public int AñoDeCreacion { get; set; }

        public string Pais { get; set; }
        public string Ciudad { get; set; }

        public TiposEscuela TipoEscuela { get; set; }

        public Curso[] Cursos { get; set; }

        public List<Curso> CursosList { get; set; }

        //constructor
        public Escuela(string nombreConstructor, int año)
        {
            this.nombre = nombreConstructor;
            this.AñoDeCreacion = año;
        }
        //segundo constructor con parámetros opcionales
        public Escuela(string nombreConstructor, int año, TiposEscuela tipo, string pais = "", string ciudad = "")
        {
            this.nombre = nombreConstructor;
            this.AñoDeCreacion = año;
            this.TipoEscuela = tipo;
            this.Pais = pais;
            this.Ciudad = ciudad;
        }

        //sobreescribir el método tostring del objeto
        public override string ToString() => ($"Nombre: {Nombre}, Tipo: {TipoEscuela}, \nPaís: {Pais}, Ciudad: {Ciudad}");

        public void imprimirCursos()
        {

            try
            {
                Printer.DibujarTitulo($"Cursos de escuela {this.Nombre}");

                foreach (var Curso in this.Cursos)
                {
                    System.Console.WriteLine($"Nombre: {Curso.Nombre}, Id: {Curso.UniqueId}, Jornada: {Curso.Jornada}");
                }
            }
            catch (System.Exception)
            {

                System.Console.WriteLine("Escuela no tiene cursos");
            }
        }

        public void imprimirCursosList()
        {

            try
            {
                Printer.DibujarTitulo($"Cursos de escuela {this.Nombre}");

                foreach (var Curso in this.CursosList)
                {
                    System.Console.WriteLine($"Nombre: {Curso.Nombre}, Id: {Curso.UniqueId}, Jornada: {Curso.Jornada}");
                }
            }
            catch (System.Exception)
            {

                System.Console.WriteLine("Escuela no tiene cursos");
            }
        }
    }
}