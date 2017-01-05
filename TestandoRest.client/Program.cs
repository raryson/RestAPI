using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestandoRest.client
{
    class Program
    {
        static void Main(string[] args)
        {

            for(int i=0;i<10; i++)
            {

                Console.WriteLine("Digite o nome do produto");
                string nomeProduto = Console.ReadLine();
                Console.WriteLine("Digite o valor de um produto");
                string valorProduto = Console.ReadLine();
                string conteudo;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:50319/api/Carrinho/");
                request.Method = "POST";

                string json = "{'Produtos':[{'Id':6237,'Preco':"+valorProduto+",'Nome':'"+nomeProduto+"','Quantidade':3}],'Endereço':'Rua Vergueiro 3185, 8 andar, Sao Paulo','Id':2}";
                byte[] jsonBytes = Encoding.UTF8.GetBytes(json);
                request.GetRequestStream().Write(jsonBytes, 0, jsonBytes.Length);

                request.ContentType = "application/json";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
               
                Console.WriteLine(response.StatusCode);
                Console.WriteLine(response.Headers["Location"]);
            }

        }
        public void testaGet()
        {

            Console.WriteLine("\nDigite o nome do controller que você quer acessar: ");
            var controller = Console.ReadLine();

            Console.WriteLine("Digite o número do ID que você deseja verificar: ");
            var id = Console.ReadLine();

            Console.WriteLine("Digite o formato que você quer a tua resposta");
            var formato = Console.ReadLine();

            string conteudo;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:50319/api/" + controller + "/" + id);
            request.Method = "GET";
            request.Accept = "application/" + formato;

            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                conteudo = reader.ReadToEnd();
            }
            Console.Write(conteudo);

        }

    }
}
