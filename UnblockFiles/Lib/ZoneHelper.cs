using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Lib
{
	public static class ZoneHelper
	{
		public static string GetZone(string filename)
		{
			IPersistFile persistFile = null;
			IZoneIdentifier zoneId = null;
			try
			{
				persistFile = (IPersistFile) new PersistentZoneIdentifier();
				//const int mode = (int) (STGM.READWRITE | STGM.SHARE_EXCLUSIVE);
				const int mode = (int) STGM.READ;
				try
				{
					persistFile.Load(filename, mode);
				}
				catch (FileNotFoundException)
				{
					return "(none)";
				}
				catch (UnauthorizedAccessException)
				{
					return "(access denied)";
				}

				zoneId = (IZoneIdentifier) persistFile;

				URLZONE zone;
				var getIdResult = zoneId.GetId(out zone);
				return zone.ToString();
			}
			finally
			{
				if (persistFile != null)
				{
					Marshal.ReleaseComObject(persistFile);
				}
				if (zoneId != null)
				{
					Marshal.ReleaseComObject(zoneId);
				}
			}
		}

		public static void Remove(string filename)
		{
			IPersistFile persistFile = null;
			IZoneIdentifier zoneId = null;
			try
			{
				// need to cast because we can't directly implement the interface in C# code
				persistFile = (IPersistFile) new PersistentZoneIdentifier();
				const int mode = (int) (STGM.READWRITE | STGM.SHARE_EXCLUSIVE);

				URLZONE zone;
				try
				{
					persistFile.Load(filename, mode);
					// need to cast because we can't directly implement the interface in C# code
					zoneId = (IZoneIdentifier) persistFile;
					var getIdResult = zoneId.GetId(out zone);
				}
				catch (FileNotFoundException)
				{
					zone = URLZONE.LOCAL_MACHINE;
				}
				catch (UnauthorizedAccessException)
				{
					zone = URLZONE.INVALID;
				}
				if (zone == URLZONE.LOCAL_MACHINE || zone == URLZONE.INVALID)
				{
					Console.WriteLine($"Nothing to remove on '{filename}'");
					return;
				}

				var removeResult = zoneId.Remove();

				persistFile.Save(filename, true);
			}
			finally
			{
				// don't forget to release the COM objects

				if (persistFile != null)
				{
					Marshal.ReleaseComObject(persistFile);
				}
				if (zoneId != null)
				{
					Marshal.ReleaseComObject(zoneId);
				}
			}
		}
	}
}