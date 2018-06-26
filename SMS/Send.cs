using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SMS
{
    class Send
    {
        public static async Task PostRequestAsync(string msid, string message, string naming, string login, string password)
        {
            WebRequest request = WebRequest.Create(string.Format("http://mtscommunicator.ru/m2m/m2m_api.asmx/SendMessage?" +
                "msid={0}&message={1}&naming={2}&login={3}&password={4}"));
            WebResponse response = await request.GetResponseAsync();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
            response.Close();
        }
    }
}
