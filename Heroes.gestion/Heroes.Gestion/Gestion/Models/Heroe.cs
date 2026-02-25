using Gestion.Config;

namespace Gestion.Models;


public abstract class Heroe : IHeroe
{

    protected Heroe(string fuerte)
    {
     
    }


    public required int Id { get; init; }
    public required string? Nombre { get; init; }
    public required int Nivel { get; set; }
    public required TipoHeroes TipoHeroe { get; set; }
    public required int Energia { get; set; }
    public required int Experiencia { get; set; }
    public required Rarezas Rareza { get; set; }

    public enum Rarezas
    {

        Común = 100,
        Especial = 200,
        Raro = 300,
        Épico = 400,
        Legendario = 500

    }
    public enum TipoHeroes
    {
    HeroeFuerte,
    HeroeInteligente
    } 

   

    public void Descansar()
    {
        if (Energia >= HeroesConfig.EnergiaMaxima)
        {
            Energia = HeroesConfig.EnergiaMaxima;
            WriteLine($"🦸 {Nombre} ya está a tope.");
            return;
        }

        Energia = Math.Min(HeroesConfig.EnergiaMaxima, Energia + HeroesConfig.EnergiaRestauraDescansar);
        WriteLine($"🦸 {Nombre} ha descansado bien. +{HeroesConfig.EnergiaRestauraDescansar} Energía.");
    }

    public abstract int CalcularPoder();

    public void GanarExperiencia(int xp)
    {
        Console.WriteLine($"✨ {Nombre} ha ganado {xp} de experiencia.");

        // Tu lógica de While actual está muy bien, solo asegúrate de que use HeroesConfig
        while (xp > 0)
        {
            if (Nivel >= HeroesConfig.UmbralesNivel.Length - 1) break;

            int objetivo = HeroesConfig.UmbralesNivel[Nivel];
            int faltaParaSubir = objetivo - Experiencia;

            if (xp >= faltaParaSubir)
            {
                xp -= (objetivo - Experiencia);
                Experiencia = 0;
                Nivel++;
                Console.WriteLine($"⭐ ¡SUBIDA DE NIVEL! {Nombre} ahora es Nivel {Nivel}.");
            }
            else
            {
                Experiencia += xp;
                xp = 0;
            }
        }
    }

    public void PerderEnergia(int cantidad)
    {
        Energia = Math.Max(0, Energia - cantidad);
        Console.WriteLine($"🔋 {Nombre} ha perdido energía. Energía restante: {Energia}");
    }

    public override string ToString() =>
        $"{Id:D2} |  Nombre: {Nombre}  |  Nivel: {Nivel}  |  Energía: {Energia}  |  Experiencia:  {Experiencia} | TiposHeroes: {TipoHeroe}";

}

