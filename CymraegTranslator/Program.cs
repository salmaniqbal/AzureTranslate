using System;
using System.Collections.Generic;
using System.Net.Http;

namespace CymraegTranslator
{
    class Program
    {

        static string host = "https://api.microsofttranslator.com";
        static string path = "/V2/Http.svc/Translate";

        // NOTE: Replace this example key with a valid subscription key.
        static string key = "xx";

        // Set this language
        static string translateToLanguage = "cy";

        async static void TranslateText()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", key);

            var translateRequest = new KeyValuePair<string, string>("Hello, what seems to be the issue?", translateToLanguage);

            string uri = host + path + "?to=" + translateRequest.Value + "&text=" + System.Net.WebUtility.UrlEncode(translateRequest.Key);

            HttpResponseMessage response = await client.GetAsync(uri);

            string result = await response.Content.ReadAsStringAsync();
            // NOTE: A successful response is returned in XML. You can extract the contents of the XML as follows.
            // var content = XElement.Parse(result).Value;
            Console.WriteLine(result);

        }
        static void Main(string[] args)
        {
            TranslateText();
            Console.ReadLine();
        }
    }
}
