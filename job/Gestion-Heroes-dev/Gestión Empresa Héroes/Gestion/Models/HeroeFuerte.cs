using Gestion.Config;

namespace Gestion.Models;

public sealed record HeroeFuerte: Heroe {
    public required int Fuerza { get; set; }
    
    public override int CalcularPoder() => Energia + Nivel * HeroesConfig.MultiplicadorNivelCalcPoder + Fuerza + (int)Rareza;
    
    public override string ToString() => base.ToString() + $"  |  Fuerza: {Fuerza}";
}