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
				persistFile = (IPersistFile)new PersistentZoneIdentifier();
				const int mode = (int) (STGM.READWRITE | STGM.SHARE_EXCLUSIVE);

				URLZONE zone;
				try
				{
					persistFile.Load(filename, mode);
					zoneId = (IZoneIdentifier)persistFile;
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

				//persistZoneId.SetId(URLZONE.LOCAL_MACHINE);
				var removeResult = zoneId.Remove();

				persistFile.Save(filename, true);
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
	}
}