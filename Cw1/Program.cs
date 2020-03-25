using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cwiczenia1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var url = "https://www.pja.edu.p";

            var client = new HttpClient();
            var result = await client.GetAsync(url);

            try
            {

                if (result.IsSuccessStatusCode)
                {

                    string html = await result.Content.ReadAsStringAsync();

                    var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+",
                        RegexOptions.IgnoreCase);

                    var matches = regex.Matches(html);
                    foreach (var m in matches)
                    {
                        Console.WriteLine(m);
                    }


                }


                Console.WriteLine("Hello World!");
            }catch(InvalidOperationException e)
            {
                throw new ArgumentException("Wrong adress");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Error while requesting");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            client.Dispose();


        }
    }
}