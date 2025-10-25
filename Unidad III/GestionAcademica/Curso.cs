using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAcademica
{
    public class Curso
    {
        #region Atributos
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public Profesor Profesor { get; set; }
        public List<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();
        // Para guardar notas directamente aquí también (opcional, pero útil)
        public Dictionary<Estudiante, float> Notas { get; set; } = new Dictionary<Estudiante, float>();
        #endregion

        #region Constructor
        public Curso(string codigo, string nombre)
        {
            Codigo = codigo;
            Nombre = nombre;
        }
        #endregion

        #region Métodos
        public void AgregarEstudiante(Estudiante e)
        {
            if (!Estudiantes.Contains(e))
                Estudiantes.Add(e);
        }

        public void AsignarProfesor(Profesor p)
        {
            Profesor = p;
            if (!p.CursosAsignados.Contains(this))
                p.CursosAsignados.Add(this);
        }

        public void RegistrarNota(Estudiante estudiante, float nota)
        {
            if (Estudiantes.Contains(estudiante))
            {
                // Guardar nota en el diccionario del curso
                if (Notas.ContainsKey(estudiante))
                    Notas[estudiante] = nota;
                else
                    Notas.Add(estudiante, nota);

                // Actualizar también en el diccionario de notas del estudiante
                estudiante.Notas[Nombre] = nota;
            }
            else
            {
                Console.WriteLine("El estudiante no está inscrito en este curso.");
            }
        }

        public float CalcularPromedio()
        {
            if (Notas.Count == 0)
                return 0;

            float suma = 0;
            foreach (var nota in Notas.Values)
            {
                suma += nota;
            }
            return suma / Notas.Count;
        }

        public void MostrarInformacionCurso()
        {
            Console.WriteLine($"Curso: {Nombre} (Código: {Codigo})");
            if (Profesor != null)
            {
                Console.WriteLine($"Profesor asignado: {Profesor.Nombre} - Especialidad: {Profesor.Especialidad}");
            }
            else
            {
                Console.WriteLine("Profesor no asignado.");
            }
            Console.WriteLine($"Estudiantes inscritos: {Estudiantes.Count}");
            foreach (var estudiante in Estudiantes)
            {
                estudiante.MostrarInformacion();
            }
            Console.WriteLine($"Promedio del curso: {CalcularPromedio()}");
        }
        #endregion
    }
}
