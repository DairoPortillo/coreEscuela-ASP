using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;
using CoreEscuela.Util;

namespace CoreEscuela
{
    ///sealed = clase sellada para no permitir heredar
    public sealed class EscuelaEngine
    {
        public Escuela Escuela { get; set; }

        public EscuelaEngine()
        {

        }

        public void ImprimirDiccionario(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dic,
                        bool imprEval = false)
        {
            foreach (var objdic in dic)
            {
                Printer.WriteTitle(objdic.Key.ToString());

                foreach (var val in objdic.Value)
                {
                    switch (objdic.Key)
                    {
                        case LlaveDiccionario.Evaluación:
                            if (imprEval)
                                Console.WriteLine(val);
                            break;
                        case LlaveDiccionario.Escuela:
                            Console.WriteLine("Escuela: " + val);
                            break;
                        case LlaveDiccionario.Alumno:
                            Console.WriteLine("Alumno: " + val.Nombre);
                            break;
                        case LlaveDiccionario.Curso:
                            var curtmp = val as Curso;
                            if(curtmp != null)
                            {
                                int count = curtmp.Alumnos.Count;
                                Console.WriteLine("Curso: " + val.Nombre + " Cantidad Alumnos: " + count);
                            }
                            break;
                        default:
                            Console.WriteLine(val);
                            break;
                    }
                }
            }
        }

        public Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> GetDiccionarioObjetos()
        {
            var diccionario = new Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>>();

            //diccionario.Add(LlaveDiccionario.Escuela, new[] { Escuela });
            diccionario.Add(LlaveDiccionario.Curso, Escuela.Cursos.Cast<ObjetoEscuelaBase>());

            var listatmp = new List<Evaluación>();
            var listatmpas = new List<Asignatura>();
            var listatmpal = new List<Alumno>();

            foreach (var cur in Escuela.Cursos)
            {
                listatmpas.AddRange(cur.Asignaturas);
                listatmpal.AddRange(cur.Alumnos);

                foreach (var alum in cur.Alumnos)
                {
                    listatmp.AddRange(alum.Evaluaciones);
                }

            }
            diccionario.Add(LlaveDiccionario.Evaluación,
                                    listatmp.Cast<ObjetoEscuelaBase>());
            diccionario.Add(LlaveDiccionario.Asignatura,
                                    listatmpas.Cast<ObjetoEscuelaBase>());
            diccionario.Add(LlaveDiccionario.Alumno,
                                    listatmpal.Cast<ObjetoEscuelaBase>());
            return diccionario;
        }

        public void Inicializar()
        {
            Escuela = new Escuela("Platzi Academay", 2012, TiposEscuela.Primaria,
            ciudad: "Bogotá", pais: "Colombia"
            );

            CargarCursos();
            CargarAsignaturas();
            CargarEvaluaciones();

        }

        private List<Alumno> GenerarAlumnosAlAzar(int cantidad)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno { Nombre = $"{n1} {n2} {a1}" };

            return listaAlumnos.OrderBy((al) => al.UniqueId).Take(cantidad).ToList();
        }

        #region Cargar Información

        private void CargarEvaluaciones()
        {

            foreach (var curso in Escuela.Cursos)
            {
                foreach (var asignatura in curso.Asignaturas)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        var rnd = new Random(System.Environment.TickCount);

                        for (int i = 0; i < 5; i++)
                        {
                            var ev = new Evaluación
                            {
                                Asignatura = asignatura,
                                Nombre = $"{asignatura.Nombre} Ev#{i + 1}",
                                Nota = (float)(5 * rnd.NextDouble()),
                                Alumno = alumno
                            };
                            alumno.Evaluaciones.Add(ev);
                        }
                    }
                }
            }

        }

        public List<ObjetoEscuelaBase> TraerObjetosEscuela()
        {
            var ListaObj = new List<ObjetoEscuelaBase>();

                ListaObj.Add(Escuela);
                ListaObj.AddRange(Escuela.Cursos);
                
                foreach (var curso in Escuela.Cursos)
                {
                    ListaObj.AddRange(curso.Asignaturas);
                    ListaObj.AddRange(curso.Alumnos);

                    foreach (var alumno in curso.Alumnos)
                    {
                        ListaObj.AddRange(alumno.Evaluaciones);
                    }
                }


            return ListaObj;
        }

        private void CargarAsignaturas()
        {
            foreach (var curso in Escuela.Cursos)
            {
                var listaAsignaturas = new List<Asignatura>(){
                            new Asignatura{Nombre="Matemáticas"} ,
                            new Asignatura{Nombre="Educación Física"},
                            new Asignatura{Nombre="Castellano"},
                            new Asignatura{Nombre="Ciencias Naturales"}
                };
                curso.Asignaturas = listaAsignaturas;
            }
        }        
        private void CargarCursos()
        {
            Escuela.Cursos = new List<Curso>(){
                        new Curso(){ Nombre = "101", Jornada = TiposJornada.Mañana },
                        new Curso() {Nombre = "201", Jornada = TiposJornada.Mañana},
                        new Curso{Nombre = "301", Jornada = TiposJornada.Mañana},
                        new Curso(){ Nombre = "401", Jornada = TiposJornada.Tarde },
                        new Curso() {Nombre = "501", Jornada = TiposJornada.Tarde},
            };

            Random rnd = new Random();
            foreach (var c in Escuela.Cursos)
            {
                int cantRandom = rnd.Next(5, 20);
                c.Alumnos = GenerarAlumnosAlAzar(cantRandom);
            }
        }

        #endregion

        
    }
}