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
            SalesCounter sales = new SalesCounter("Sales.csv");

            Dictionary<string,int> amoutPerStore = sales.GetPerStoreSales();

            //出力
            foreach (var item in amoutPerStore)
            {
                Console.WriteLine("{0}の売り上げ合計 : {1}", item.Key, item.Value);

            }

            #region 改良前
            ////var total = new int[] { 0, 0, 0, 0, 0 };
            //int[] total = { 0, 0, 0, 0, 0 };

            //SalesCounter sales = new SalesCounter(ReadSals("Sales.csv"));

            //foreach (var item in sales._sales)
            //{
            //    #region 店舗毎の合計の処理
            //    //if (item.ShopName.Equals("新宿店"))
            //    //{
            //    //    total += item.Amount;
            //    //}
            //    //if (item.ShopName.Equals("浅草店"))
            //    //{
            //    //    total2 += item.Amount;
            //    //}
            //    //if (item.ShopName.Equals("丸の内店"))
            //    //{
            //    //    total3 += item.Amount;
            //    //}
            //    //if (item.ShopName.Equals("横浜店"))
            //    //{
            //    //    total4 += item.Amount;
            //    //}
            //    #endregion

            //    if (item.ProductCategory.Equals("カステラ"))
            //    {
            //        total[0] += item.Amount;
            //    }
            //    if (item.ProductCategory.Equals("餅菓子"))
            //    {
            //        total[1] += item.Amount;
            //    }
            //    if (item.ProductCategory.Equals("まんじゅう"))
            //    {
            //        total[2] += item.Amount;
            //    }
            //    if (item.ProductCategory.Equals("羊羹"))
            //    {
            //        total[3] += item.Amount;
            //    }
            //    //合計
            //    total[4] += item.Amount;
            //}
            //#region　店舗毎の合計の表示
            ////Console.WriteLine("新宿店   : {0}円",total);
            ////Console.WriteLine("浅草店   : {0}円", total2);
            ////Console.WriteLine("丸の内店 : {0}円", total3);
            ////Console.WriteLine("横浜店   : {0}円", total4);
            //#endregion

            //Console.WriteLine("カステラ   : {0}円", total[0]);
            //Console.WriteLine("餅菓子  　 : {0}円", total[1]);
            //Console.WriteLine("まんじゅう : {0}円", total[2]);
            //Console.WriteLine("羊羹   　　: {0}円", total[3]);
            //Console.WriteLine("");
            //Console.WriteLine("全体     　: {0}円", total[4]);
            #endregion
        }

    }
}
