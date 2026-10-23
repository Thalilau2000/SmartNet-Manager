using System;

class Program
{
    static void Main()
    {
        var dhcp = new ServidorDHCP();
        var fila = new FilaAutenticacao();
        var dashboard = new Dashboard();
        var auditoria = new Auditoria();
        var firewall = new Firewall();
        var relatorios = new Relatorios();

        while (true)
        {
            Console.WriteLine("\n=== SMARTNET MANAGER ===");
            Console.WriteLine("1 - Reservar IP (DHCP)");
            Console.WriteLine("2 - Autenticar dispositivo");
            Console.WriteLine("3 - Exibir Dashboard");
            Console.WriteLine("4 - Rollback de ação");
            Console.WriteLine("5 - Gerar Relatórios");
            Console.WriteLine("6 - Aplicar Firewall Dinâmico");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");

            string opc = Console.ReadLine();

            switch (opc)
            {
                case "1":
                    Console.Write("Digite o IP: ");
                    string ip = Console.ReadLine();

                    Console.Write("Digite o MAC Address: ");
                    string mac = Console.ReadLine();

                    dhcp.ReservarIP(ip, mac);
                    auditoria.Registrar("DHCP", $"Reserva de IP {ip} para MAC {mac}");
                    break;

                case "2":
                    Console.Write("Nome do dispositivo: ");
                    string nome = Console.ReadLine();

                    var dispositivo = new RegistroAtivo(nome);

                    Console.Write("Digite o IP do dispositivo: ");
                    dispositivo.EnderecoIP = Console.ReadLine();

                    Console.Write("Digite o MAC Address: ");
                    dispositivo.MacAddress = Console.ReadLine();

                    fila.AdicionarNaFila(dispositivo);
                    fila.ProcessarFila();

                    dashboard.RegistrarAtivo(dispositivo);

                    auditoria.Registrar("Autenticacao", $"Dispositivo {nome} autenticado");
                    break;

                case "3":
                    dashboard.ExibirDashboard();
                    break;

                case "4":
                    Console.Write("Digite o índice da ação para rollback: ");
                    int idx = int.Parse(Console.ReadLine());

                    auditoria.Rollback(idx);
                    break;

                case "5":
                    relatorios.GerarRelatorio(
                        autenticados: dashboard.TotalAtivos(),
                        naoAutenticados: 0, // opcional, podemos melhorar depois
                        totalReservas: dhcp.TotalReservas(),
                        totalAcoes: auditoria.TotalAcoes()
                    );
                    break;

                case "6":
                    Console.Write("Nome do dispositivo: ");
                    string n = Console.ReadLine();

                    Console.Write("MAC Address: ");
                    string m = Console.ReadLine();

                    Console.Write("Regra de firewall: ");
                    string r = Console.ReadLine();

                    firewall.AplicarFirewallDinamico(n, m, r);
                    auditoria.Registrar("Firewall", $"Regra aplicada: {r}");
                    break;

                case "0":
                    Console.WriteLine("Encerrando o sistema...");
                    return;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }
}

