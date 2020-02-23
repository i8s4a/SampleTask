using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;

namespace Business.Concrete.ServiceAdapter
{
	public class ServiceAdapter:IServiceAdapter
	{
		public void ServiceData()
		{
			MbService mbService = new MbService();
			mbService.CurrencyForeignService();
		}
	}
}
