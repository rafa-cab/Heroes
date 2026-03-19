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
    public override void SubirNivel()
    {
        base.SubirNivel();  // Ejecuta la lógica base (Nivel++)
        Inteligencia += 3;    // EFECTO SECUNDARIO: +3 de Estrategia
        Console.WriteLine($"🧠 Bono de Clase: +3 Estrategia (Total: {Inteligencia})");
    }
    
    public override string ToString() => base.ToString() + $" | Inteligencia: {Inteligencia}";
}