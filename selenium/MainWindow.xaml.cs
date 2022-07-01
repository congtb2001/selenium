using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace selenium
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //tao delay
            int milliseconds = 2000;
            //tao chromdriver de chay tren chrom
            ChromeDriver chromeDriver = new ChromeDriver();
            //lay duong link cua trang web ma minh muon kiem thu
            chromeDriver.Url = "https://demo.guru99.com/v4/";
            chromeDriver.Navigate();
            //lay bang xpath cho chac chan
            var searchName = chromeDriver.FindElement(By.XPath("/html/body/form/table/tbody/tr[1]/td[2]/input"));
            searchName.SendKeys("mngr416655");

            var searchPW = chromeDriver.FindElement(By.XPath("/html/body/form/table/tbody/tr[2]/td[2]/input"));
            searchPW.SendKeys("Ypevysa");
            
            Thread.Sleep(milliseconds);
            var btnLogin = chromeDriver.FindElement(By.XPath("/html/body/form/table/tbody/tr[3]/td[2]/input[1]"));
            btnLogin.Click();
            Thread.Sleep(milliseconds);
            var text = chromeDriver.FindElement(By.XPath("/html/body/table/tbody/tr/td/table/tbody/tr[2]/td/marquee"));
            // dung try catch de bat loi 
            try
            {
                Assert.AreEqual("Welcome To Manager's Page of Guru99 Bank", text.Text);
                lblResult.Content = "thanh cong";
                lblResult.Background = Brushes.Green;

            }
            catch (Exception ex)
            {
                //xuat loi cua he thong
                //lblResult.Content= ex.Message;


                lblResult.Content = "loi roi kia";
                lblResult.Background = Brushes.Red;
            }
        }
    }
}
