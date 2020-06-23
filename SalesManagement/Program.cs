using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            int total = 0;

            SalesCounter sales = new SalesCounter(ReadSals("Sales.csv"));

            foreach (var item in sales._sales)
            {
                total += item.Amount;
            }

            Console.WriteLine("全体の売り上げ : {0}円",total);
        }

        //売上データを読み込み、Saleオブジェクトのリストを返す
        static List<Sale> ReadSals(string filePath)
        {
            //売上データを入れるリストオブジェクトを生成
            var sales = new List<Sale>();

            //ファイルから読み込み
            string[] lines = File.ReadAllLines(filePath);

            //読み込んだ行の数だけ繰り返す
            foreach (string line in lines)
            {
                string[] items = line.Split(',');

                Sale sale = new Sale
                {
                    ShopName = items[0],
                    ProductCategory = items[1],
                    Amount = int.Parse(items[2])
                };

                //saleオブジェクトをリストに追加
                sales.Add(sale);
            }
            return sales;
        }
    }
}
