using System.IO;
//using System.Text.Json;
using Newtonsoft.Json;

namespace day7_shop
{
    class Program
    {
        static void Main(string[] args)
        {
            var json = File.ReadAllText("data.json");
            var gift = JsonConvert.DeserializeObject<Gift>(json);

            gift.GiftMotherInLaw();
            gift.GiftYourself();
            gift.ProductCheapesBuy();
            gift.ProductRandomBuy();
            gift.GetTotalPrice();
            gift.GetSumCheapProduct();
            gift.GetCheapProduct();
        }
    }
}