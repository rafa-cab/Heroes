namespace Gestion.Models;

public class Mision
{

    public string? Nombre { get; set; }
    public int Dificultad { get; set; } // 1 al 10
    public string Estado { get; set; } = "Pendiente";

    // Lista para almacenar los héroes asignados
    public List<Heroe> HeroesAsignados { get; set; } = new List<Heroe>();

    public Mision(string? nombre, int dificultad)
    {
        Nombre = nombre;
        Dificultad = dificultad;
    }

    // MÉTODO PARA AÑADIR HÉROES
    public void AsignarHeroe(Heroe h)
    {
        if (Estado == "Pendiente")
        {
            HeroesAsignados.Add(h);
            Console.WriteLine($"{h.Nombre} ha sido unido a la misión {Nombre}.");
        }
    }

    public void ResolverMision()
    {
        // El umbral ahora depende de la dificultad (puedes ajustar el multiplicador)
        int poderRequerido = Dificultad * 100;
        int poderTotal = HeroesAsignados.Sum(h => h.CalcularPoder());

        Console.WriteLine($"\n--- ⚔️ EJECUTANDO MISIÓN: {Nombre} ---");
        Console.WriteLine($"Poder del equipo: {poderTotal} | Requerido: {poderRequerido}");

        if (poderTotal >= poderRequerido)
        {
            Estado = "Completada";
            Console.WriteLine("✅ ¡Misión Exitosa!");

            foreach (var h in HeroesAsignados)
            {
                // Llamamos al método con la cantidad de XP (ejemplo: 50 * dificultad)
                h.GanarExperiencia(50 * Dificultad);
            }
        }
        else
        {
            Estado = "Fallida";
            Console.WriteLine("❌ La misión ha fracasado...");

            foreach (var h in HeroesAsignados)
            {
                // Usamos el nuevo método de pérdida de energía
                h.PerderEnergia(10 * Dificultad);
            }

        }
    }

}