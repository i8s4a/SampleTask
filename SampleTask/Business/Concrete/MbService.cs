using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Business.Concrete
{
	public class MbService
	{
		public string Usd_Sell { get; set; }
		public string Euro_Sell { get; set; }
		public void CurrencyForeignService()
		{
			string today = "http://www.tcmb.gov.tr/kurlar/today.xml";

			var xmlDoc = new XmlDocument();
			xmlDoc.Load(today);

			//string USD_Buy = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
			Usd_Sell = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;

			//string EURO_Buy = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
			Euro_Sell = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
        }
	}
}
