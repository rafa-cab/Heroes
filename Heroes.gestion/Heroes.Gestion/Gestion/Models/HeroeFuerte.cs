using Gestion.Config;

namespace Gestion.Models;

public sealed class HeroeFuerte : Heroe 
{
    public  required int Fuerza { get; set; }

    // Al heredar, le pasamos "Fuerte" a la base
    public HeroeFuerte(int fuerza) : base("Fuerte") 
    {
        Fuerza = fuerza;
    }
    
    public override int CalcularPoder() 
    {
        double poderCalculado = (Fuerza * 1.5) + (Energia * 0.2);
        return (int)poderCalculado;
    }
    
    public override string ToString() => base.ToString() + $" | Fuerza: {Fuerza}";
}