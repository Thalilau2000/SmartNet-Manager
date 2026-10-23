using System;
using System.Collections.Generic;

public class Dashboard
{
    private List<RegistroAtivo> ativos = new List<RegistroAtivo>();
    private Random rnd = new Random();

    public void RegistrarAtivo(RegistroAtivo dispositivo)
    {
        ativos.Add(dispositivo);
    }

    public void ExibirDashboard()
    {
        Console.WriteLine("\n=== DASHBOARD ===");

        foreach (var d in ativos)
        {
            int consumo = rnd.Next(50, 501); // limite de 500 Mbps
            Console.WriteLine($"{d.Nome} | IP: {d.EnderecoIP} | MAC: {d.MacAddress} | Consumo: {consumo} Mbps");
        }

        Console.WriteLine($"Total de dispositivos ativos: {ativos.Count}");
    }

    public int TotalAtivos()
    {
        return ativos.Count;
    }
}
