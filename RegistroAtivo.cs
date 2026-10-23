public class RegistroAtivo
{
    public string EnderecoIP { get; set; } // ex: 192.168.0.1
    public string Nome { get; set; } // ex: "AP01"
    public string MacAddress { get; set; } // ex: "00:1B:44:11:3A:B7"
    public static string[] Funcoes = { "DHCP", "Firewall", "Autenticacao", "Historico" };

    public RegistroAtivo(string nome)
    {
        Nome = nome;
    }

    public void ProcessarFilaAutenticacao()
    {
        Console.WriteLine($"[Autenticacao] Dispositivo {Nome} autenticado com sucesso.");
    }
}
