using System;
using System.Collections.Generic;

public class FilaAutenticacao
{
    private Queue<RegistroAtivo> fila = new Queue<RegistroAtivo>();

    public int TotalAutenticados { get; private set; }

    public void AdicionarNaFila(RegistroAtivo dispositivo)
    {
        fila.Enqueue(dispositivo);
        Console.WriteLine($"Dispositivo {dispositivo.Nome} entrou na fila de autenticação.");
    }

    public void ProcessarFila()
    {
        if (fila.Count == 0)
        {
            Console.WriteLine("Nenhum dispositivo na fila.");
            return;
        }

        var dispositivo = fila.Dequeue();
        dispositivo.ProcessarFilaAutenticacao();
        TotalAutenticados++;
    }
}
