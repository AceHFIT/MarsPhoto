using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Documents;
using System.Windows.Forms;

namespace MarsRoverPhonos
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Camera
    {
        public int id { get; set; }
        public string name { get; set; }
        public int rover_id { get; set; }
        public string full_name { get; set; }
    }

    public class Rover
    {
        public int id { get; set; }
        public string name { get; set; }
        public string landing_date { get; set; }
        public string launch_date { get; set; }
        public string status { get; set; }
    }

    public class Photo
    {
        public int id { get; set; }
        public int sol { get; set; }
        public Camera camera { get; set; }
        public string img_src { get; set; }
        public string earth_date { get; set; }
        public Rover rover { get; set; }
    }

    public class Root
    {
        public List<Photo> photos { get; set; }
    }



    public partial class MRP : Form
    {
        string jsonData;
        string theDate;
        public MRP()
        {
            InitializeComponent();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GetPhotos()
        {
            string sUrl;
            sUrl = "https://api.nasa.gov/mars-photos/api/v1/rovers/curiosity/photos?earth_date=" + theDate + "&api_key=DEMO_KEY";
            try
            {
                System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(sUrl);
                using (System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse())
                {

                    using (System.IO.Stream stream = response.GetResponseStream())
                    using (System.IO.StreamReader reader = new System.IO.StreamReader(stream))
                    {
                        jsonData = reader.ReadToEnd();
                    }

                    var parent = JObject.Parse(jsonData);
                    var theParent = JsonConvert.DeserializeObject<Root>(jsonData);

                    string url = theParent.photos[0].img_src;
                    WebClient webClient = new WebClient();
                    string fileName = Path.GetFileName(url);

                    if (Directory.Exists(Directory.GetCurrentDirectory() + "\\images"))
                        Directory.Delete(Directory.GetCurrentDirectory() + "\\images");
                    Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\images");
                    webClient.DownloadFile(url, Directory.GetCurrentDirectory() + "\\images\\" + fileName);
                    System.Drawing.Image myImage = Image.FromFile(Directory.GetCurrentDirectory()  + @"\\images\\" + fileName);
                    imgLstNasa.Images.Add(myImage);
                    this.BackgroundImage = myImage;
                    

                }
            }
            catch(HttpRequestException e)
            {

            }
        }

        public System.Drawing.Image DownloadImageFromUrl(string imageUrl)
        {
            System.Drawing.Image image = null;

            try
            {
                System.Net.HttpWebRequest webRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(imageUrl);
                webRequest.AllowWriteStreamBuffering = true;
                webRequest.Timeout = 30000;

                System.Net.WebResponse webResponse = webRequest.GetResponse();

                System.IO.Stream stream = webResponse.GetResponseStream();

                image = System.Drawing.Image.FromStream(stream);

                webResponse.Close();
            }
            catch (Exception ex)
            {
                return null;
            }

            return image;
        }
        private void btGetPhotos_Click(object sender, EventArgs e)
        {
            GetPhotos();
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.CustomFormat = "yyyy-dd-MM";
            theDate = dtpDate.Text;
            btGetPhotos.Enabled = true;
        }
    }
}
