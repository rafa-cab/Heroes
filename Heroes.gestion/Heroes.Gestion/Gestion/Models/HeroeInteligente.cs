using Gestion.Config;

namespace Gestion.Models;

public sealed class HeroeInteligente : Heroe 
{
    public int Inteligencia { get; set; }

    // Al heredar, le pasamos "Inteligente" a la base
    public HeroeInteligente(int inteligencia) : base("Inteligente") 
    {
        Inteligencia = inteligencia;
    }
    
    public override int CalcularPoder() 
    {
        double poderCalculado = (Inteligencia * 2.0) + (Nivel * 10);
        return (int)poderCalculado;
    }
    
    public override string ToString() => base.ToString() + $" | Inteligencia: {Inteligencia}";
}