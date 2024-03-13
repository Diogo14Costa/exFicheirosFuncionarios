using System;
using System.IO;
namespace ex1TRev
{
    struct Endereco
    {
        public string Nome;
        public string Rua;
        public int Numero;
        public string CodPostal;
    }

    class Program
    {

        static void Main(string[] args)
        {
            Endereco[] funcionarios = new Endereco[5];

            // Preenchendo os dados dos funcionários (apenas para exemplo)
            for (int i = 0; i < funcionarios.Length; i++)
            {
                funcionarios[i].Nome = "Funcionário " + (i + 1);
                funcionarios[i].Rua = "Rua " + (i + 1);
                funcionarios[i].Numero = i + 1;
                funcionarios[i].CodPostal = "0000-" + (i + 1);
            }

            string filePath = "funcionarios.dat";
            EscreverEnderecosEmArquivo(funcionarios, filePath);

            Endereco[] funcionariosLidos = LerEnderecosDoArquivo(filePath);
            ApresentarEnderecos(funcionariosLidos);
        }

        static void EscreverEnderecosEmArquivo(Endereco[] enderecos, string filePath)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
            {
                foreach (Endereco endereco in enderecos)
                {
                    writer.Write(endereco.Nome);
                    writer.Write(endereco.Rua);
                    writer.Write(endereco.Numero);
                    writer.Write(endereco.CodPostal);
                }
            }
        }

        static Endereco[] LerEnderecosDoArquivo(string filePath)
        {
            Endereco[] enderecos = new Endereco[5];

            using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                for (int i = 0; i < enderecos.Length; i++)
                {
                    enderecos[i].Nome = reader.ReadString();
                    enderecos[i].Rua = reader.ReadString();
                    enderecos[i].Numero = reader.ReadInt32();
                    enderecos[i].CodPostal = reader.ReadString();
                }
            }

            return enderecos;
        }

        static void ApresentarEnderecos(Endereco[] enderecos)
        {
            foreach (Endereco endereco in enderecos)
            {
                Console.WriteLine($"Nome: {endereco.Nome}, Rua: {endereco.Rua}, Número: {endereco.Numero}, Código Postal: {endereco.CodPostal}");
            }
        }
    }
}