namespace Practica2.Models
{
    //Clase creada para permitir la creacion de metodos genericos con cada tabla que la herede 
    public class Generic
    {
        public int Id { get; set; }
        public int EstadoId { get; set; }
        public DateTime? FechaHoraReg { get; set; }
    }
}
