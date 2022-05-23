using System;
using System.IO;
using System.Net;
using System.Text;

namespace Utils
{
    public static class UtilWeb
    {
        public static string WebResponseGet(HttpWebRequest pWebRequest)
        {
            StreamReader responseReader = null;
            string responseData = "";

            try
            {
                responseReader = new StreamReader(pWebRequest.GetResponse().GetResponseStream(), Encoding.UTF8);
                responseData = responseReader.ReadToEnd();
            }
            finally
            {
                if (responseReader != null)
                {
                    responseReader.Close();
                    responseReader = null;
                }
            }
            return responseData;
        }

        public static string WebRequest(string httpMethod, string url, byte[] byteData)
        {
            HttpWebRequest webRequest = null;
            string responseData = "";

            webRequest = System.Net.WebRequest.Create(url) as HttpWebRequest;
            webRequest.Method = httpMethod;
            webRequest.ServicePoint.Expect100Continue = false;
            webRequest.Timeout = 600000;
            webRequest.ContentType = "application/x-www-form-urlencoded";

            if (httpMethod == "POST")
            {
                webRequest.ContentLength = 0;

                if (byteData != null)
                {
                    webRequest.ContentLength = byteData.Length;

                    Stream dataStream = webRequest.GetRequestStream();
                    dataStream.Write(byteData, 0, byteData.Length);
                    dataStream.Close();
                }
            }
            try
            {
                responseData = WebResponseGet(webRequest);
            }
            catch (WebException ex)
            {
                string message = url;
                try
                {
                    StreamReader sr = new StreamReader(ex.Response.GetResponseStream());
                    message += "\r\nError: " + sr.ReadToEnd();
                }
                catch { }

                // Error reading the error response, throw the original exception
                throw new Exception(message, ex);
            }

            webRequest = null;

            return responseData;
        }

        public static string WebRequest(string httpMethod, string url, string token, byte[] byteData = null)
        {
            HttpWebRequest webRequest = null;
            string responseData = "";

            webRequest = System.Net.WebRequest.Create(url) as HttpWebRequest;
            webRequest.Method = httpMethod;
            webRequest.ServicePoint.Expect100Continue = false;
            webRequest.Timeout = 600000;
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Headers.Add("Authorization", "Bearer " + token);
            if (httpMethod == "POST")
            {
                webRequest.ContentLength = 0;

                if (byteData != null)
                {
                    webRequest.ContentLength = byteData.Length;

                    Stream dataStream = webRequest.GetRequestStream();
                    dataStream.Write(byteData, 0, byteData.Length);
                    dataStream.Close();
                }
            }
            try
            {
                responseData = WebResponseGet(webRequest);
            }
            catch (WebException ex)
            {
                string message = url;
                try
                {
                    StreamReader sr = new StreamReader(ex.Response.GetResponseStream());
                    message += "\r\nError: " + sr.ReadToEnd();
                }
                catch { }

                // Error reading the error response, throw the original exception
                //throw new Exception(message, ex);
                return "";
            }

            webRequest = null;

            return responseData;
        }

    }
}
