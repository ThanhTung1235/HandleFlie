using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using HelloWorld.Entity;
using Newtonsoft.Json;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HelloWorld
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //const string URL = "https://daokhanh-201004.appspot.com/"; // phần gốc của địa chỉ website
            //string urlParameters = "_api/v1/account/" + txtboxPhone.Text; // giá trị = URI của API + số điện thoại truyền vào

            //// tạo 1 request --> URL
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL + urlParameters); // tạo 1 request --> URL API
            //request.Method = "GET"; // method "GET" tức là lấy giá trị từ API về theo SDT

            //HttpWebResponse Response = (HttpWebResponse)await request.GetResponseAsync(); // nhận trả về
            //StreamReader ResponseDataStream = new StreamReader(Response.GetResponseStream()); // lấy dữ liệu được trả về và đọc
            //var result = ResponseDataStream.ReadToEnd(); // cho dữ liệu sang biến result
            //Debug.WriteLine(result); // chỉ in result

            //// đoạn dưới này sử dụng newtons --> Object
            //Customer account = JsonConvert.DeserializeObject<Customer>(result);
            //txtGetName.Text = account.Fullname;
            //txtGetEmail.Text = account.Email;


            const string URL = "https://daokhanh-201004.appspot.com/";
            string urlParmeter = "_api/v1/account/" + txtboxPhone.Text;
            string _bestUrl = URL + urlParmeter;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_bestUrl);
            request.Method = "GET";

            HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();
            StreamReader resStreamReader = new StreamReader(response.GetResponseStream());
            string result = resStreamReader.ReadToEnd();

            Customer customer = JsonConvert.DeserializeObject<Customer>(result);
            Debug.WriteLine(customer.Fullname);
            Debug.WriteLine(customer.Email);
            Debug.WriteLine(customer.Phone);
            txtGetName.Text = customer.Fullname;
            txtGetEmail.Text = customer.Phone;

        }
    }
}
