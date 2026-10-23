using System;
using System.Collections.Generic;

public class ServidorDHCP
{
    private Dictionary<string, string> reservas = new Dictionary<string, string>();
    private HashSet<string> macsRegistrados = new HashSet<string>();

    public void ReservarIP(string ip, string mac)
    {
        if (macsRegistrados.Contains(mac))
        {
            Console.WriteLine("Erro: Este MAC já possui reserva.");
            return;
        }

        reservas[ip] = mac;
        macsRegistrados.Add(mac);

        Console.WriteLine($"Reserva criada: IP {ip} vinculado ao MAC {mac}");
    }

    public int TotalReservas()
    {
        return reservas.Count;
    }
}
