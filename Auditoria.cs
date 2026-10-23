using System;
using System.Collections.Generic;

public class Auditoria
{
    public class Log
    {
        public DateTime Data { get; set; }
        public string Acao { get; set; }
        public string Descricao { get; set; }
    }

    private List<Log> historico = new List<Log>();

    public void Registrar(string acao, string descricao)
    {
        historico.Add(new Log
        {
            Data = DateTime.Now,
            Acao = acao,
            Descricao = descricao
        });

        Console.WriteLine($"[LOG] {acao} - {descricao}");
    }

    public void Rollback(int index)
    {
        if (index < 0 || index >= historico.Count)
        {
            Console.WriteLine("Rollback inválido: índice fora do intervalo.");
            return;
        }

        var log = historico[index];
        historico.RemoveAt(index);

        Console.WriteLine($"Rollback realizado da ação: {log.Acao}");

        Registrar("Rollback", $"Reversão da ação: {log.Acao}");
    }

    public int TotalAcoes()
    {
        return historico.Count;
    }
}
