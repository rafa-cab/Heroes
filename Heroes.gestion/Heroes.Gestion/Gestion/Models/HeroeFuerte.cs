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

    public override void SubirNivel()
    {
        base.SubirNivel();
        Fuerza += 2;
        WriteLine("bono de Clase : +2 Fuerza (Total: {Fuerza})");
    }
public override string ToString() => base.ToString() + $" | Fuerza: {Fuerza}";
}

    
    