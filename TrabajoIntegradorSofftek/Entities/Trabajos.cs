namespace TrabajoIntegradorSofftek.Entities
{
    public class TrabajosDto
    {
        public int codTrabajos {  get; set; }
        public DateTime fecha { get; set; }
        public int codProyecto { get; set; }
        public ServiciosDto codServicio { get; set; }
        public int cantHoras { get; set; }
        public double valorHora { get; set; }
        public double costo {  get; set; }
    }
}
