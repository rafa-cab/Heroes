namespace Gestion.Models;

public class Misiones
{
    public string ID  { get; set; }
    public int Dificultad {get; set; }

    public enum EstadoMision
    {
    Pendiente, 
    Completada
        

    }


}