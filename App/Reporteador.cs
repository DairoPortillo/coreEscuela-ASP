using System;
using System.Linq;
using System.Collections.Generic;
using CoreEscuela.Entidades;

namespace CoreEscuela.App
{
    public class Reporteador
    {
        Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> _diccionario;
        public Reporteador(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> DicObjEsc)
        {
            if (DicObjEsc == null)
            {
                throw new ArgumentNullException(nameof(DicObjEsc));
            }
            _diccionario = DicObjEsc;
        }

        public IEnumerable<Evaluación> getListaEvaluaciones()
        {
            var rta = _diccionario.TryGetValue(LlaveDiccionario.Evaluación, out IEnumerable<ObjetoEscuelaBase> lista);

            if (rta)
            {
                return lista.Cast<Evaluación>();
            }
            else
            {
                return new List<Evaluación>();
            }

        }

        public IEnumerable<string> getListaAsignaturas()
        {
            var listaEvaluaciones = getListaEvaluaciones();

            return (from ev in listaEvaluaciones select ev.Asignatura.Nombre).Distinct();
        }
    }
}