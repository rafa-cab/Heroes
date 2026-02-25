using Gestion.Config;

namespace Gestion.Models;

/*public sealed class HeroeInteligente: Heroe {

    public HeroeInteligente(string tipoheroe, Inteligencias inteligencia)
    {
        Inteligencia = inteligencia;
        
    }

    public required Inteligencias Inteligencia { get; set; }
    public enum Inteligencias { Baja = 10, Media = 30, Alta = 50 }


    
    
    public override int CalcularPoder() => Energia + Nivel * HeroesConfig.MultiplicadorNivelCalcPoder + (int)Inteligencia + (int)Rareza;
    
    public override string ToString() => base.ToString() + $"  |  Inteligencia: {Inteligencia}";*/

public sealed class HeroeInteligente : Heroe 
{
    public int Inteligencia { get; set; }

    // Al heredar, le pasamos "Inteligente" a la base
    public HeroeInteligente(int inteligencia) : base("Inteligente") 
    {
        Inteligencia = inteligencia;
    }
    
    public override int CalcularPoder() => 
        (int)(Energia + (Nivel * 12) + (Inteligencia * 2) + Rareza);
    
    public override string ToString() => base.ToString() + $" | Inteligencia: {Inteligencia}";
}