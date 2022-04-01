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
    public class UrunBul
    {
        public static async Task GetHtmlAsync(Workbook UrunBulList, Worksheet UrunBulSheet, Worksheet UrunBulSheet2, int Kacinci, CancellationToken UrunBultokenSourcetoken)
        {
            int count = UrunBulSheet.Cells.Find("*", System.Reflection.Missing.Value,
                               System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                               _Excel.XlSearchOrder.xlByRows, _Excel.XlSearchDirection.xlPrevious,
                               false, System.Reflection.Missing.Value, System.Reflection.Missing.Value).Row;


            int count2 = UrunBulSheet2.Cells.Find("*", System.Reflection.Missing.Value,
                              System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                              _Excel.XlSearchOrder.xlByRows, _Excel.XlSearchDirection.xlPrevious,
                              false, System.Reflection.Missing.Value, System.Reflection.Missing.Value).Row;



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
                if (UrunBultokenSourcetoken.IsCancellationRequested)
                {
                    UrunBultokenSourcetoken.ThrowIfCancellationRequested();
                }
                string date = DateTime.Now.ToString("hh:mm:ss dd-MM");

            }

            httpClient.Dispose();
            handler.Dispose();
            UrunBulList.Close(true);


        }
    }
}