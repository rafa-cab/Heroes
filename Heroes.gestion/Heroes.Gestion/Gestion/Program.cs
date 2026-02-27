using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Gestion.Models; // Asegúrate de que tus clases Heroe y Mision existan en esta carpeta

namespace GestionHeroica
{
    class Program
    {

        // Listas globales para persistir los datos durante la ejecución
        static List<Heroe> listaHeroes = new List<Heroe>();
        static List<Mision> listaMisiones = new List<Mision>();

        static void Main(string[] args)
        {
            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("===SISTEMA DE GESTIÓN DE HÉROES===");
                Console.WriteLine("1. Crear nuevo Héroe");
                Console.WriteLine("2. Visualizar Héroes registrados");
                Console.WriteLine("3. Crear nueva Misión");
                Console.WriteLine("4. Asignar Héroes a una Misión");
                Console.WriteLine("5. Simular desarrollo de una Misión");
                Console.WriteLine("6. Ranking de Héroes (Poder)");
                Console.WriteLine("7. Buscar Héroes/Misiones");
                WriteLine("8. Salir");
                WriteLine("9.Nico");
                Console.Write("\nSeleccione una opción: ");

                string? opcion = ReadLine();

                switch (opcion)
                {
                    case "1": CrearHeroe(); break;
                    case "2": VisualizarHeroes( listaHeroes); break;
                    case "3": CrearMision(); break;
                    case "4": AsignarHeroeAMision(); break;
                    case "5": SimularMisionMenu(); break; 
                    case "6": MostrarRanking(); break;
                    case "7": Buscar(); break;
                    case "8": salir = true; break;
                    case "9": Nico() ;
                        break;
                    default: WriteLine("Opción no válida."); break;
                }

                if (!salir)
                {
                    WriteLine("\nPresione cualquier tecla para continuar...");
                    ReadKey();
                }
            }
        }

        // --- MÉTODOS DEL MÉNU ---

        
        static void CrearHeroe()
        {
            Console.WriteLine("\n--- RECLUTAR NUEVO HÉROE ---");
            Console.WriteLine("¿Tipo de héroe? (1. Fuerte / 2. Inteligente)");
            string? seleccion = ReadLine();

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine()!;

            Console.Write("Nivel inicial: ");
            int nivel = int.Parse(ReadLine() ?? throw new InvalidOperationException());

            Console.Write("Energía: ");
            int energia = int.Parse(ReadLine() ?? throw new InvalidOperationException());

            Console.Write("Experiencia: ");
            int experiencia = int.Parse(ReadLine() ?? throw new InvalidOperationException());

            // Mostrar opciones de Rareza basadas en tu Enum
            Console.WriteLine("Rareza (Comun, Raro, Epico, Legendario): ");
            Enum.TryParse(Console.ReadLine(), true, out Heroe.Rarezas rarezaElegida);

            Heroe nuevoHeroe;

            if (seleccion == "1")
            {
                Console.Write("Puntos de Fuerza: ");
                int fuerza = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

                // Inicialización con las propiedades 'required'
                nuevoHeroe = new HeroeFuerte(fuerza)
                {
                    Id = listaHeroes.Count + 1,
                    Nombre = nombre,
                    Nivel = nivel,
                    Energia = energia,
                    Experiencia = experiencia,
                    Rareza = rarezaElegida,
                    Fuerza = fuerza,
                    TipoHeroe = Heroe.TipoHeroes.HeroeFuerte
                };
            }
            else
            {
                Console.Write("Puntos de Inteligencia: ");
                int inteligencia = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

                nuevoHeroe = new HeroeInteligente(inteligencia)
                {
                    Id = listaHeroes.Count + 1,
                    Nombre = nombre,
                    Nivel = nivel,
                    Energia = energia,
                    Experiencia = experiencia,
                    Rareza = rarezaElegida,
                    Inteligencia = inteligencia,
                    TipoHeroe = Heroe.TipoHeroes.HeroeInteligente
                };
            }

            listaHeroes.Add(nuevoHeroe);
            Console.WriteLine($"\n✅ ¡{nuevoHeroe.Nombre} ({nuevoHeroe.TipoHeroe}) ha sido registrado con éxito!");
        }

    

     static void VisualizarHeroes(IEnumerable listaHeroes)
    {
        Console.WriteLine("\n--- LISTA DE HÉROES ---");

        // Convertimos a Heroe para poder usar los métodos de lista
        var listaFiltro = listaHeroes.Cast<Heroe>();

        if (listaFiltro.Count() == 0) 
        {
            Console.WriteLine("No hay héroes registrados.");
            return;
        }

        foreach (Heroe h in listaFiltro) 
        {
            Console.WriteLine(h.ToString());
        }
    }
        static void CrearMision()
        {
            Console.Write("Nombre de la misión: ");
            string  nombre = Console.ReadLine()!;
            Console.Write("Dificultad (1-10): ");
            
            if (int.TryParse(Console.ReadLine(), out int dif))
            {
                listaMisiones.Add(new Mision(nombre, dif)
                {
                    Nombre = nombre,
                    Dificultad = 0,
                    Estado = Mision.EstadoMision.Pendiente,
                    Estados = null
                });
                Console.WriteLine("Misión registrada.");
            }
            else
            {
                Console.WriteLine("Dificultad no válida. Debe ser un número.");
            }
        }

        static void AsignarHeroeAMision()
        {
            if (listaHeroes.Count == 0 || listaMisiones.Count == 0) {
                Console.WriteLine("Faltan héroes o misiones.");
                return;
            }
            // Listar misiones para elegir
            for (int i = 0; i < listaMisiones.Count; i++) Console.WriteLine($"{i}. {listaMisiones[i].Nombre}");
            Console.Write("Seleccione índice de Misión: ");
            int idM = int.Parse(Console.ReadLine() ?? "0");

            VisualizarHeroes(listaHeroes);
            Console.Write("ID del Héroe a añadir: ");
            int idH = int.Parse(Console.ReadLine() ?? "0");

            var heroe = listaHeroes.FirstOrDefault(h => h.Id == idH);
            if (heroe != null && idM < listaMisiones.Count) {
                listaMisiones[idM].AsignarHeroe(heroe);
                Console.WriteLine($"✅ {heroe.Nombre} asignado a {listaMisiones[idM].Nombre}");
            }
        }

        static void SimularMisionMenu()
        {
            if (listaMisiones.Count == 0) {
                Console.WriteLine("No hay misiones para simular.");
                return;
            }

            for (int i = 0; i < listaMisiones.Count; i++) 
                Console.WriteLine($"{i}. {listaMisiones[i].Nombre} (Estado: {listaMisiones[i].Estado})");

            Console.Write("Seleccione índice de misión para simular: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index < listaMisiones.Count)
            {
                // Aquí llamamos al método que DEBE ESTAR dentro de la clase Mision
                listaMisiones[index].SimularMisionMenu();
            }
            else { Console.WriteLine("Selección inválida."); }
        } static void MostrarRanking()
        {
            Console.WriteLine("\n--- TOP HÉROES POR PODER ---");
            var ranking = listaHeroes.OrderByDescending(h => h.CalcularPoder()).ToList();
            for (int i = 0; i < ranking.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {ranking[i].Nombre} - Poder: {ranking[i].CalcularPoder()}");
            }
        }

        static void Buscar()
        {
            Console.Write("Ingrese nombre a buscar: ");
            string  entrada = Console.ReadLine()!;
            if (string.IsNullOrEmpty(entrada)) return;

            string busqueda = entrada.ToLower();
            var encontrados = listaHeroes.Where(h => h.Nombre != null && h.Nombre.ToLower().Contains(busqueda));
            foreach (var h in encontrados) Console.WriteLine(h.ToString());
        }

        static void Nico()
        {
            WriteLine("--------------------------------");
            WriteLine("Nico es muchisimo peor que Rafa ");
            WriteLine("--------------------------------");
        }
    }
    
    
}