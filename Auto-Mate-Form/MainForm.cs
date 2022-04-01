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
    public partial class MainForm : Form
    {
        CancellationTokenSource _KarsiUrunKontroltokenSource = null;
        CancellationTokenSource _UrunBultokenSource = null;





        public MainForm()
        {
            InitializeComponent();
        }
        public void Form1_Load(object sender, EventArgs e)
        {
            KarsiUrunKontrolBaslat.Enabled = true;
            KarsiUrunKontrolDurdur.Enabled = false;
            ÜrünBulBaşlat.Enabled = true;
            ÜrünBulDurdur.Enabled = false;



        }

        public void GosterCikis_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        public void PencereGizle_Click(object sender, EventArgs e)
        {
            this.Hide();
            BildirimIcon.Visible = true;
        }

        public void Goster_Click(object sender, EventArgs e)
        {
            this.Show();
            BildirimIcon.Visible = false;


        }

        private void GizleCikis_Click(object sender, EventArgs e)
        {
            this.Close();

        }



        public async void KarsiUrunKontrolBaslatButon_Click(object sender, EventArgs e)
        {
            _Application _ExcelApl = null;


            try
            {
                _ExcelApl = new _Excel.Application
                {
                    Visible = false,
                    DisplayAlerts = false

                };

                Workbook DropShippingList = _ExcelApl.Workbooks.Open(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\DropShippingList.xlsx", 0, false, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, false, false, 0);

                Worksheet DropShippingSheets = (Worksheet)DropShippingList.Worksheets[1];

                if (DropShippingList.ReadOnly == true)
                {
                    throw new Exception();
                }



                _KarsiUrunKontroltokenSource = new CancellationTokenSource();
                var KarsiUrunKontroltoken = _KarsiUrunKontroltokenSource.Token;


                int Kacinci = Convert.ToInt32((double)(DropShippingSheets.Cells[1, 14] as _Excel.Range).Value2);
                int count = DropShippingSheets.Cells.Find("*", System.Reflection.Missing.Value,
                                   System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                                   _Excel.XlSearchOrder.xlByRows, _Excel.XlSearchDirection.xlPrevious,
                                   false, System.Reflection.Missing.Value, System.Reflection.Missing.Value).Row;

                _KarsiUrunKontrolprogressBar.Value = 0;

                KarsiUrunKontrolProgressQuantity.Text = "Aktif";

                KarsiUrunKontrolBaslat.Text = "Başlatıldı";
                KarsiUrunKontrolDurdur.Text = "Durdur";


                KarsiUrunKontrolDurdur.Enabled = true;
                KarsiUrunKontrolBaslat.Enabled = false;
                ÇıkışButon.Enabled = false;


                var progress = new Progress<int>(value =>
                {
                    _KarsiUrunKontrolprogressBar.Value = value;

                });
                var progress2 = new Progress<int>(value =>
                {

                    KarsiUrunKontrolProgressQuantity.Text = Convert.ToString(value) + "/" + count;


                });

                var Stok_Kontrol_to_Main = new Progress<int>(value =>
                {
                    string date = DateTime.Now.ToString("HH:mm:ss dd-MM");
                    KarsiUrunKontrolurun_degisikligi.AppendText("[" + date + "] " + value + " numaralı karşı ürünün stoğu değiştirilmiştir.\n");
                    KarsiUrunKontrolurun_degisikligi.SelectionStart = KarsiUrunKontrolurun_degisikligi.TextLength;
                    KarsiUrunKontrolurun_degisikligi.ScrollToCaret();

                    BildirimIcon.ShowBalloonTip(3000, "Karşı Stok Değişikliği", value + " numaralı karşı ürünün stoğu değiştirilmiştir.", ToolTipIcon.Info);


                });

                var Fiyat_Kontrol_to_Main = new Progress<int>(value =>
                {
                    string date = DateTime.Now.ToString("HH:mm:ss dd-MM");
                    KarsiUrunKontrolurun_degisikligi.AppendText("[" + date + "] " + value + " numaralı karşı ürünün fiyatı değiştirilmiştir.\n");
                    KarsiUrunKontrolurun_degisikligi.SelectionStart = KarsiUrunKontrolurun_degisikligi.TextLength;
                    KarsiUrunKontrolurun_degisikligi.ScrollToCaret();
                    BildirimIcon.ShowBalloonTip(3000, "Karşı Fiyat Değişikliği", value + " numaralı karşı ürünün fiyatı değiştirilmiştir.", ToolTipIcon.Info);


                });

                var Baglanti = new Progress<string>(value =>
                {
                    string date = DateTime.Now.ToString("HH:mm:ss dd-MM");

                    if (value.Contains("başarısız"))
                    {
                        BağlantıHataları.AppendText("[" + date + "] " + value);
                        BağlantıHataları.SelectionStart = KarsiUrunKontrolbaglanti_bildirim.TextLength;
                        BağlantıHataları.ScrollToCaret();

                        BildirimIcon.ShowBalloonTip(3000, "Bağlantı Hatası", "Bağlantı başarısız", ToolTipIcon.Error);

                        DropShippingList.Close(true);


                        KarsiUrunKontrolDurdur.Enabled = false;
                        KarsiUrunKontrolBaslat.Enabled = true;
                        if (KarsiUrunKontrolBaslat.Enabled == true & ÜrünBulBaşlat.Enabled == true)
                        {
                            ÇıkışButon.Enabled = true;
                        }
                        KarsiUrunKontrolBaslat.Text = "Tekrar dene";

                    }
                    else if (value.Contains("geçersiz"))
                    {

                        BağlantıHataları.AppendText("[" + date + "] " + value);
                        BağlantıHataları.SelectionStart = KarsiUrunKontrolbaglanti_bildirim.TextLength;
                        BağlantıHataları.ScrollToCaret();
                        BildirimIcon.ShowBalloonTip(3000, "Link geçersiz", "Link geçersiz", ToolTipIcon.Error);
                    }
                    else
                    {

                        KarsiUrunKontrolbaglanti_bildirim.AppendText("[" + date + "] " + value);
                        KarsiUrunKontrolbaglanti_bildirim.SelectionStart = KarsiUrunKontrolbaglanti_bildirim.TextLength;
                        KarsiUrunKontrolbaglanti_bildirim.ScrollToCaret();

                    }

                });

                try
                {


                    await Task.Run(() => KarsiUrunKontrol.GetHtmlAsync(Kacinci, progress, progress2, Stok_Kontrol_to_Main, Fiyat_Kontrol_to_Main, Baglanti, KarsiUrunKontroltoken, DropShippingList, DropShippingSheets));

                    KarsiUrunKontrolBaslat.Text = "Tekrar";

                    KarsiUrunKontrolProgressQuantity.Text = "Bütün ürünler kontrol edildi";

                    KarsiUrunKontrolBaslat.Enabled = true;
                    KarsiUrunKontrolDurdur.Enabled = false;
                    if (KarsiUrunKontrolBaslat.Enabled == true && ÜrünBulBaşlat.Enabled == true)
                    {
                        ÇıkışButon.Enabled = true;
                    }


                }

                catch (OperationCanceledException ex)
                {

                    DropShippingList.Close(true);

                    KarsiUrunKontrolDurdur.Text = "Durduruldu";
                    KarsiUrunKontrolBaslat.Text = "Devam et";



                    KarsiUrunKontrolDurdur.Enabled = false;
                    KarsiUrunKontrolBaslat.Enabled = true;

                    if (KarsiUrunKontrolBaslat.Enabled == true && ÜrünBulBaşlat.Enabled == true)
                    {
                        ÇıkışButon.Enabled = true;
                    }


                }
                finally
                {
                    _KarsiUrunKontroltokenSource.Dispose();
                }
            }
            catch (Exception)
            {
                KarsiUrunKontrolDurdur.Text = "Durdur";
                KarsiUrunKontrolBaslat.Text = "Tekrar dene";



                KarsiUrunKontrolDurdur.Enabled = false;
                KarsiUrunKontrolBaslat.Enabled = true;
                _ExcelApl.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(_ExcelApl);
                KarsiUrunKontrolProgressQuantity.Text = "Excel dosyası kullanımda";
                if (KarsiUrunKontrolBaslat.Enabled == true && ÜrünBulBaşlat.Enabled == true)
                {
                    ÇıkışButon.Enabled = true;

                }
            }
        }

        public void KarsiUrunKontrolDurdurButon_Click(object sender, EventArgs e)
        {
            _KarsiUrunKontroltokenSource.Cancel();

        }



        public void ÇıkışButon_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void TümünüDurdurButon_Click(object sender, EventArgs e)
        {
            if (KarsiUrunKontrolBaslat.Enabled == false)
            {
                _KarsiUrunKontroltokenSource.Cancel();
            }

        }

        public async void ÜrünBulBaşlat_Click(object sender, EventArgs e)
        {
            

            _Application _ExcelApl = null;


            try
            {
                _ExcelApl = new _Excel.Application
                {
                    Visible = false,
                    DisplayAlerts = false

                };

                Workbook UrunBulList = _ExcelApl.Workbooks.Open(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\UrunBulList.xlsx", 0, false, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, false, false, 0);

                Worksheet UrunBulSheet = (Worksheet)UrunBulList.Worksheets[1];
                Worksheet UrunBulSheet2 = (Worksheet)UrunBulList.Worksheets[2];


                if (UrunBulList.ReadOnly == true)
                {
                    throw new Exception();
                }


                int Kacinci = Convert.ToInt32((double)(UrunBulSheet.Cells[1, 13] as _Excel.Range).Value2);

                _UrunBultokenSource = new CancellationTokenSource();
                var UrunBultokenSourcetoken = _UrunBultokenSource.Token;


                ÜrünBulBaşlat.Text = "Başlatıldı";
                ÜrünBulDurdur.Text = "Durdur";
                UrunBulDurum.Text = "Aktif";


                ÜrünBulDurdur.Enabled = true;
                ÜrünBulBaşlat.Enabled = false;

                ÇıkışButon.Enabled = false;



                try
                {


                    await Task.Run(() => UrunBul.GetHtmlAsync(UrunBulList, UrunBulSheet, UrunBulSheet2, Kacinci, UrunBultokenSourcetoken));

                    ÜrünBulBaşlat.Text = "Tekrar";
                    UrunBulDurum.Text = "Tamamlandı";

                    ÜrünBulBaşlat.Enabled = true;
                    ÜrünBulDurdur.Enabled = false;
                    if (KarsiUrunKontrolBaslat.Enabled == true && ÜrünBulBaşlat.Enabled == true)
                    {
                        ÇıkışButon.Enabled = true;
                    }

                }

                catch (OperationCanceledException ex)
                {
                    UrunBulList.Close(true);

                    ÜrünBulDurdur.Text = "Durduruldu";
                    ÜrünBulBaşlat.Text = "Devam et";
                    UrunBulDurum.Text = "Durduruldu";



                    ÜrünBulDurdur.Enabled = false;
                    ÜrünBulBaşlat.Enabled = true;
                    if (KarsiUrunKontrolBaslat.Enabled == true && ÜrünBulBaşlat.Enabled == true)
                    {
                        ÇıkışButon.Enabled = true;
                    }


                }
                finally
                {
                    _UrunBultokenSource.Dispose();
                }
            }

            catch (Exception)
            {
                ÜrünBulDurdur.Text = "Durdur";
                ÜrünBulBaşlat.Text = "Tekrar dene";



                ÜrünBulDurdur.Enabled = false;
                ÜrünBulBaşlat.Enabled = true;
                _ExcelApl.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(_ExcelApl);
                UrunBulDurum.Text = "Excel dosyası kullanımda";
                if (KarsiUrunKontrolBaslat.Enabled == true && ÜrünBulBaşlat.Enabled == true)
                {
                    ÇıkışButon.Enabled = true;

                }
            }



        }

        private void ÜrünBulDurdur_Click(object sender, EventArgs e)
        {
            _UrunBultokenSource.Cancel();
        }


    }
}
