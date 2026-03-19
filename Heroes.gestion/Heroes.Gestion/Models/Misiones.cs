namespace Gestion.Models;

public class Mision
{

    public required string Nombre { get;set ; }
    public required int Dificultad { get; set; } // 1 al 10
    public EstadoMision Estado { get; set; }
    public List<Heroe> HeroesAsignados { get; set; } = new List<Heroe>();
    public enum EstadoMision 
    {

        Completada = 1,
        Fallida = 2,
        Pendiente = 3,

    };
    

    public Mision(string nombre, int dificultad)
    {
        Nombre = nombre;
        Dificultad = dificultad;
        Estado = EstadoMision.Completada;
        Estado = EstadoMision.Fallida;
        Estado = EstadoMision.Pendiente;
    }
    
    // MÉTODO PARA AÑADIR HÉROES
    public void AsignarHeroe(Heroe h)
    {
        if (Estados == "2")
        {
            HeroesAsignados.Add(h);
            Console.WriteLine($"{h.Nombre} ha sido unido a la misión {Nombre}.");
        }
    }

    public required string? Estados { get; set; }

    public void SimularMisionMenu()
    {
        // El umbral ahora depende de la dificultad (puedes ajustar el multiplicador)
        int poderRequerido = Dificultad * 100;
        int poderTotal = HeroesAsignados.Sum(h => h.CalcularPoder());

        Console.WriteLine($"\n--- ⚔️ EJECUTANDO MISIÓN: {Nombre} ---");
        Console.WriteLine($"Poder del equipo: {poderTotal} | Requerido: {poderRequerido}"); 
        if (HeroesAsignados.Count == 0)
        {
            Console.WriteLine("⚠️ No puedes iniciar una misión sin héroes.");
            return;
        }

        Estado = EstadoMision.Pendiente;
        Console.WriteLine($"🚀 Iniciando misión: {Nombre}...");

       
        foreach (var h in HeroesAsignados)
        {
            poderTotal += h.CalcularPoder();
        }

        // Lógica de éxito: Dificultad * 20 (por ejemplo)
        if (poderTotal >= (Dificultad * 20))
        {
            Estado = EstadoMision.Completada; // 👈 Cambio de estado a Éxito
            Console.WriteLine("✅ ¡Misión SUPERADA!");
        }
        else
        {
            Estado = EstadoMision.Fallida;    // 👈 Cambio de estado a Fracaso
            Console.WriteLine("❌ Misión FALLIDA.");
        }
    }
    /*public void SimularMision() 
    {
        if (Asignado == null || EquipoAsignado.Count == 0)
        {
            Console.WriteLine("⚠️ No hay héroes en esta misión.");
            return;
        }

        double poderTotal = EquipoAsignado.Sum(h => h.CalcularPoderTotal());
        double umbral = Dificultad * 80;

        Console.WriteLine($"\nSimulando: {Nombre}...");
        if (poderTotal >= umbral) {
            Estado = EstadoMision.Completada;
            Console.WriteLine("✅ ¡Victoria!");
            foreach(var h in EquipoAsignado) h.GanarExperiencia(50);
        } else {
            Estado = EstadoMision.Fallida;
            Console.WriteLine("❌ Fracaso.");
            foreach(var h in EquipoAsignado) h.Energia = Math.Max(0, h.Energia - 30);
        }
    }*/

    
}