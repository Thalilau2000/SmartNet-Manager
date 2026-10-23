using System;

public class Firewall
{
    public void AplicarFirewallDinamico(string nome, string macAddress, string regraFirewall)
    {
        Console.WriteLine($"[Firewall] Regra aplicada ao dispositivo {nome} ({macAddress}): {regraFirewall}");
    }
}
