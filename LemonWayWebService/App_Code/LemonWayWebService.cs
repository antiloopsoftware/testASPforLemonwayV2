using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Xml;

/// <summary>
/// Summary description for LemonWayWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class LemonWayWebService : WebService
{
    private static readonly ILog log = LogManager.GetLogger(typeof(LemonWayWebService));

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Fibonacci(int n)
    {
        try
        {
            int res = getFibonacci(n);

            var keyValues = new Dictionary<string, string>
            {
                { "response", res.ToString()}
            };

            JavaScriptSerializer js = new JavaScriptSerializer();
            var response = js.Serialize(keyValues);
            log.Debug(String.Format("Fibonacci function with parameter {0} has return {1}", n, response.ToString()));

            return response;
        }

        catch (Exception ex)
        {
            var keyValues = new Dictionary<string, string>
            {
                { "error", ex.Message}
            };

            JavaScriptSerializer js = new JavaScriptSerializer();
            var response = js.Serialize(keyValues);
            log.Error(String.Format("Fibonacci function with parameter {0} has return {1}", n, response.ToString()));

            return response;
        }
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string XmlToJson(string xml)
    {
        try
        { 
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            string jsonText = JsonConvert.SerializeXmlNode(doc);

            log.Debug(String.Format("XmlToJson function with parameter {0} has return {1}", xml, jsonText));

            return jsonText;
        }

        catch (Exception ex)
        {
            if (ex is XmlException)
            {
                string errorMessage = "Bad Xml format";
                log.Error(String.Format("XmlToJson function with parameter {0} has return {1}", xml, errorMessage));

                return errorMessage;
            }

            else
            {
                log.Fatal(String.Format("XmlToJson function with parameter {0} has return {1}", xml, ex.Message));

                return ex.Message;
            }
        }
    }

    public int getFibonacci(int n)
    {
        if (n < 1 || n > 100)
        {
            log.Error(String.Format("getFibonacci function receives a bad parameter : {0}", n, -1));
            return -1;
        }

        /*
         * Foreach snippet written by Sam Allen, sam@dotnetperls.com. © 2007-2016.
         * code source page : http://www.dotnetperls.com/fibonacci
         */

        int a = 0;
        int b = 1;

        for (int i = 0; i < n; i++)
        {
            int temp = a;
            a = b;
            b = temp + b;
        }

        return a;
    }


}
