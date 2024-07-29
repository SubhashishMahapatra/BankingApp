using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BankAppUsingList.Models
{
    internal class SerializationDeserialization
    {
        public static void Serialization(List<Account> account)
        {
            File.WriteAllText("AccountData.json", JsonConvert.SerializeObject(account));
        }

        public static List<Account> Deserialization()
        {
            string fileName = "AccountData.json";
            if (File.Exists(fileName))
            {
                string json = File.ReadAllText(fileName);
                return JsonConvert.DeserializeObject<List<Account>>(json);
            }
            else
            {
                return new List<Account> ();
            }
        }
    }
}
