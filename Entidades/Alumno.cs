namespace CoreEscuela.Entidades
{
    public class Alumno
    {
        public string UniqueId { get; private set; }
        public string Nombre { get; set; }

        public Alumno()
        {
            UniqueId = System.Guid.NewGuid().ToString();
        }
    }
}