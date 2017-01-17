using System;
using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Lib
{
	[TestClass]
	public class LibTests
	{
		[TestMethod]
		public void Remove()
		{
			const string filename = @"C:\Users\Aaron\Downloads\unfiled\20170114_134608.jpg";
			ZoneHelper.Remove(filename);
		}

		[TestMethod]
		public void GetZone_LocalMachine()
		{
			const string filename = @"C:\Users\Aaron\Downloads\unfiled\20170114_134608.jpg";
			var actual = ZoneHelper.GetZone(filename);
			Assert.AreEqual(URLZONE.LOCAL_MACHINE, actual);
		}

		[TestMethod]
		public void GetZone_Internet()
		{
			const string filename = @"C:\Users\Aaron\Downloads\unfiled\20170114_134547.jpg";
			var actual = ZoneHelper.GetZone(filename);
			Assert.AreEqual(URLZONE.INTERNET, actual);
		}

		[TestMethod]
		public void GetZone_None()
		{
			const string filename = @"C:\Users\Aaron\Downloads\unfiled\20170114_134603.jpg";
			var actual = ZoneHelper.GetZone(filename);
			Assert.AreEqual(URLZONE.INVALID, actual);
		}
	}
}
