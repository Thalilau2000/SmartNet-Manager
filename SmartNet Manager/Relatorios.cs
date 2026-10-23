using System;

public class Relatorios
{
    public void GerarRelatorio(int autenticados, int naoAutenticados, int totalReservas, int totalAcoes)
    {
        Console.WriteLine("\n=== RELATÓRIO GERAL ===");
        Console.WriteLine($"Dispositivos autenticados: {autenticados}");
        Console.WriteLine($"Dispositivos não autenticados: {naoAutenticados}");
        Console.WriteLine($"Total de IPs reservados: {totalReservas}");
        Console.WriteLine($"Total de ações registradas no histórico: {totalAcoes}");
    }
}

