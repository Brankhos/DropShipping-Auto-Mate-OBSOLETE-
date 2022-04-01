using System;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Globalization;
using System.Net.Http;
using HtmlAgilityPack;
using System.Net;
using System.Net.Http.Headers;
using System.IO;
using System.Threading;
using System.Collections;


namespace Auto_Mate_Form
{
    public class KarsiUrunKontrol
    {
        public static async Task GetHtmlAsync(int Kacinci, IProgress<int> progress, IProgress<int> progress2, IProgress<int> Stok_Kontrol_to_Main, IProgress<int> Fiyat_Kontrol_to_Main, IProgress<string> Baglanti, CancellationToken token, Workbook DropShippingList, Worksheet DropShippingSheets)
        {




            int count = DropShippingSheets.Cells.Find("*", System.Reflection.Missing.Value,
                               System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                               _Excel.XlSearchOrder.xlByRows, _Excel.XlSearchDirection.xlPrevious,
                               false, System.Reflection.Missing.Value, System.Reflection.Missing.Value).Row;






            var LogFilePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\log.txt";
            using var LogFile = new StreamWriter(LogFilePath, append: true);

            CookieContainer cookies = new CookieContainer();

            var proxy = new WebProxy()
            {

                UseDefaultCredentials = false,
                Credentials = CredentialCache.DefaultNetworkCredentials
            };

            ServicePointManager.Expect100Continue = false;
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            HttpClientHandler handler = new HttpClientHandler()
            {
                UseProxy = true,
                PreAuthenticate = true,
                Proxy = proxy,
                AllowAutoRedirect = true,
                CookieContainer = cookies,
                UseCookies = true,
                DefaultProxyCredentials = CredentialCache.DefaultCredentials,
            };

            if (handler.SupportsAutomaticDecompression)
            {
                handler.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            }

            using HttpClient httpClient = new HttpClient(handler);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Add("Accept", "*/*");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
            httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");
            httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)");
            httpClient.DefaultRequestHeaders.Add("user-agent", "Please don't ban again... I am just testing...");

            for (int i = Kacinci; i <= count; i++)
            {
                if (token.IsCancellationRequested)
                {
                    token.ThrowIfCancellationRequested();
                }
                string date = DateTime.Now.ToString("hh:mm:ss dd-MM");




                string HucreB = (string)(DropShippingSheets.Cells[i, 2] as _Excel.Range).Value2;
                int HucreC = Convert.ToInt32((DropShippingSheets.Cells[i, 3] as _Excel.Range).Value2);
                string HucreD = (string)(DropShippingSheets.Cells[i, 4] as _Excel.Range).Value2;
                string HucreE;
                try
                {
                    HucreE = (DropShippingSheets.Cells[i, 5] as _Excel.Range).Cells.Hyperlinks[1].Address;


                }
                catch (Exception)
                {
                    HucreE = (string)(DropShippingSheets.Cells[i, 5] as _Excel.Range).Value2;
                }



                int HucreF = Convert.ToInt32((DropShippingSheets.Cells[i, 6] as _Excel.Range).Value2);

                double HucreG = Convert.ToDouble((DropShippingSheets.Cells[i, 7] as _Excel.Range).Value2);
                double HucreH = Convert.ToDouble((DropShippingSheets.Cells[i, 8] as _Excel.Range).Value2);
                string HucreI = (string)(DropShippingSheets.Cells[i, 9] as _Excel.Range).Value2;
                double HucreJ = Convert.ToDouble((DropShippingSheets.Cells[i, 10] as _Excel.Range).Value2);
                



                //string HucreB = Convert.ToString(deger[$"A{i}"].StringValue);
                //int HucreC = Convert.ToInt32(deger[$"B{i}"].Int32Value);
                //string HucreD = Convert.ToString(deger[$"C{i}"].StringValue);
                //string HucreE = Convert.ToString(deger[$"D{i}"].StringValue);
                //int HucreF = Convert.ToInt32(deger[$"E{i}"].Int32Value);
                //double HucreG = Convert.ToDouble(deger[$"F{i}"].DoubleValue);
                //double HucreH = Convert.ToDouble(deger[$"G{i}"].DoubleValue);
                //string HucreI = Convert.ToString(deger[$"H{i}"].StringValue);
                //double HucreJ = Convert.ToDouble(deger[$"I{i}"].DoubleValue);



                if (false == String.IsNullOrEmpty(HucreE) && (HucreE.Contains(".com") == true || HucreE.Contains(".ca") == true))
                {

                    if (false == HucreE.Contains("https"))
                    {
                        HucreE = "https://" + HucreE;
                    }


                    var Baglanti_durumu = i + " numaralı ürün için bağlantı sağlanıyor.\n";
                    Baglanti.Report(Baglanti_durumu);


                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, HucreE);
                    HttpResponseMessage response = await httpClient.SendAsync(request);
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        Baglanti_durumu = i + " numaralı ürün için bağlantı başarılı.\n";
                        Baglanti.Report(Baglanti_durumu);

                        string html_content = await response.Content.ReadAsStringAsync();


                        var htmlDocument = new HtmlAgilityPack.HtmlDocument();
                        htmlDocument.LoadHtml(html_content);

                        var nodes = htmlDocument.DocumentNode.SelectNodes("//div[@id='ppd']");
                        if (nodes != null)
                        {

                            var Stok_Kontrol_To_Parse = Stok_Kontrol_to_Main;
                            var Fiyat_Kontrol_To_Parse = Fiyat_Kontrol_to_Main;

                            //deger[$"C{i}"].StringValue = Stok_kontrol(htmlDocument, i, HucreD, LogFile, date, Stok_Kontrol_To_Parse);       //MEVCUT STOK

                            DropShippingSheets.Cells[i, 4] = Stok_kontrol(htmlDocument, i, HucreD, LogFile, date, Stok_Kontrol_To_Parse);






                            if (Convert.ToInt32((DropShippingSheets.Cells[i, 3] as _Excel.Range).Value2) == 0) //ürün resmi ekleme
                            {
                                string resimbilgi = htmlDocument.DocumentNode.SelectSingleNode("//img[@id='landingImage']").Attributes["data-old-hires"].Value;

                                Microsoft.Office.Interop.Excel.Range oRange = (Microsoft.Office.Interop.Excel.Range)DropShippingSheets.Cells[i, 1];

                                float Left = (float)((double)oRange.Left);
                                float Top = (float)((double)oRange.Top);
                                const float ImageSize = 64;
                                oRange.RowHeight = ImageSize;
                                oRange.ColumnWidth = ImageSize / 5;

                                DropShippingSheets.Shapes.AddPicture(resimbilgi, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, Left, Top, ImageSize, ImageSize);

                            }



                            //deger[$"A{i}"].StringValue = Asin_kontrol(nodes, HucreB);//Asin kontrol

                            DropShippingSheets.Cells[i, 2] = Asin_kontrol(nodes, HucreB);

                            var FiyatList = new ArrayList();
                            FiyatList = Fiyat_kontrol(nodes, i, HucreC, HucreF, HucreG, HucreH, HucreJ, LogFile, date, Fiyat_Kontrol_To_Parse);  //Fiyat Kontrol

                            //deger[$"B{i}"].Int32Value = (int)FiyatList[0];
                            //deger[$"E{i}"].Int32Value = (int)FiyatList[1];
                            // deger[$"F{i}"].DoubleValue = (double)FiyatList[2];
                            //deger[$"G{i}"].DoubleValue = (double)FiyatList[3];
                            //deger[$"I{i}"].DoubleValue = (double)FiyatList[4];

                            DropShippingSheets.Cells[i, 3] = (int)FiyatList[0];
                            DropShippingSheets.Cells[i, 6] = (int)FiyatList[1];
                            DropShippingSheets.Cells[i, 7] = (double)FiyatList[2];
                            DropShippingSheets.Cells[i, 8] = (double)FiyatList[3];
                            DropShippingSheets.Cells[i, 10] = (double)FiyatList[4];




                        }
                        else
                        {
                            LogFile.WriteLine("[" + date + "] Amazon sitesini kriptoladı...");
                            Baglanti_durumu = i + " numaralı ürün için bağlantı başarısız. Site kriptolandı.\n";
                            Baglanti.Report(Baglanti_durumu);
                            return;
                        }


                        //deger[$"D{i}"].StringValue = HucreE; // linkler
                        //deger[$"H{i}"].StringValue = HucreI; // linkler

                        //deger["M1"].Int32Value = i;


                        if (false == String.IsNullOrEmpty(HucreE) && (HucreE.Contains(".com") == true || HucreE.Contains(".ca") == true))
                        {
                            DropShippingSheets.Cells[i, 5] = "=HYPERLINK(\"" + HucreE + "\", \"" + HucreE + "\")";
                        }
                        DropShippingSheets.Cells[i, 9] = HucreI;

                        DropShippingSheets.Cells[1, 14] = i;


                        var percentComplete = (i * 100) / count;
                        progress.Report(percentComplete);
                        var progressQuantity = i;
                        progress2.Report(progressQuantity);
                        ;

                        if (i == count)
                        {
                            DropShippingSheets.Cells[1, 14] = 1;
                        }


                        DropShippingList.Save();


                    }
                    else
                    {

                        LogFile.WriteLine("[" + date + "] Amazon sitesine izin vermiyor");
                        Baglanti_durumu = i + " numaralı ürün için bağlantı başarısız. FireWall.\n";
                        Baglanti.Report(Baglanti_durumu);

                        var percentComplete = (i * 100) / count;
                        progress.Report(percentComplete);
                        var progressQuantity = i;
                        progress2.Report(progressQuantity);
                        ;

                        if (i == count)
                        {
                            DropShippingSheets.Cells[1, 14] = 1;
                        }



                    }
                }
                else
                {
                    LogFile.WriteLine("[" + date + "] " + i + " numaralı ürünün linki geçersiz.");
                    var Baglanti_durumu = i + " numaralı ürünün linki geçersiz.\n";
                    Baglanti.Report(Baglanti_durumu);

                }
            }

            httpClient.Dispose();
            handler.Dispose();
            DropShippingList.Close(true);

        }



        static string Stok_kontrol(HtmlAgilityPack.HtmlDocument htmlDocument, int i, string HucreD, StreamWriter LogFile, string date, IProgress<int> Stok_Kontrol_To_Parse)           //MEVCUT STOK
        {


            var instockarray = htmlDocument.DocumentNode.SelectNodes("//div[@id='availability']");
            HtmlNode instock = instockarray[0];
            string instockvalue = instock.SelectSingleNode(".//span").InnerText.Trim('\r', '\n', '\t', '₺', '$', '£', '.');
            if (HucreD != instockvalue)
            {
                HucreD = instockvalue;
                string stok_bildiri = i + " numaralı ürünün stoğu değiştirildi.";
                LogFile.WriteLine("[" + date + "]" + stok_bildiri);
                var Stok_durum = i;
                Stok_Kontrol_To_Parse.Report(Stok_durum);
            }


            return (HucreD);


        }

        static string Asin_kontrol(HtmlNodeCollection nodes, string HucreB)                  //Asin kontrol
        {






            HtmlNode item = nodes[0];
            if (item.SelectSingleNode(".//input[@id='ASIN']").Attributes["value"].Value != null)  //for ASIN
            {
                string ProductASIN = item.SelectSingleNode(".//input[@id='ASIN']").Attributes["value"].Value;
                HucreB = ProductASIN;
            }
            else if (item.SelectSingleNode(".//input[@id='attach-baseAsin']").Attributes["value"].Value != null)           //for baseAsin
            {
                string ProductASIN = item.SelectSingleNode(".//input[@id='attach-baseAsin']").Attributes["value"].Value;
                HucreB = ProductASIN;
            }


            return (HucreB);

        }



        static ArrayList Fiyat_kontrol(HtmlNodeCollection nodes, int i, int HucreC, int HucreF, double HucreG, double HucreH, double HucreJ, StreamWriter LogFile, string date, IProgress<int> Fiyat_Kontrol_To_Parse)
        {

            var dondur = new ArrayList();

            if (HucreF == 0)
            {
                HucreF = 20;
            }
            HtmlNode item = nodes[0];
            if (item.SelectSingleNode(".//span[@id='priceblock_ourprice']") != null)  //OUR PRICE İÇİN
            {
                string Price = item.SelectSingleNode(".//span[@id='priceblock_ourprice']").InnerText.Trim('\r', '\n', '\t', '₺', '$', '£');
                Price = Price.Replace(",", "").Replace(".", "");
                Price = Price.Remove(Price.Length - 2);
                int newPrice = Convert.ToInt32(Price);
                HucreC = newPrice;
                HucreG = (HucreC / (double)100) * HucreF;
                HucreH = Convert.ToInt32(HucreG + HucreC) + 0.99;

                if (HucreJ != HucreH)
                {
                    HucreJ = HucreH;
                    string fiyat_bildiri = i + " numaralı ürünün stoğu değiştirildi.";
                    LogFile.WriteLine("[" + date + "]" + fiyat_bildiri);
                    var Fiyat_durum = i;
                    Fiyat_Kontrol_To_Parse.Report(Fiyat_durum);
                }



            }
            else if (item.SelectSingleNode(".//span[@id='priceblock_saleprice']") != null) //SALE PRICE İÇİN
            {
                string Price = item.SelectSingleNode(".//span[@id='priceblock_saleprice']").InnerText.Trim('\r', '\n', '\t', '₺', '$', '£');
                Price = Price.Replace(",", "").Replace(".", "");
                Price = Price.Remove(Price.Length - 2);
                int newPrice = Convert.ToInt32(Price);
                HucreC = newPrice;
                HucreG = (HucreC / (double)100) * HucreF;
                HucreH = Convert.ToInt32(HucreG + HucreC) + 0.99;

                if (HucreJ != HucreH)
                {
                    HucreJ = HucreH;
                    string fiyat_bildiri = i + " numaralı ürünün stoğu değiştirildi.";
                    LogFile.WriteLine("[" + date + "]" + fiyat_bildiri);
                    var Fiyat_durum = i;
                    Fiyat_Kontrol_To_Parse.Report(Fiyat_durum);
                }

            }

            dondur.Add(HucreC);
            dondur.Add(HucreF);
            dondur.Add(HucreG);
            dondur.Add(HucreH);
            dondur.Add(HucreJ);

            return (dondur);
        }

    }



}