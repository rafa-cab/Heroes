using System.Text;
using Serilog;


Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.File("Logs/log.log", rollingInterval: RollingInterval.Day).CreateLogger();
Title = "Gestión Empresa Héroes";
OutputEncoding = Encoding.UTF8;
Clear();
Main();
Log.CloseAndFlush();
WriteLine("\n👋 Presiona una tecla para salir...");
ReadKey();
return;

void Main() {
    
}