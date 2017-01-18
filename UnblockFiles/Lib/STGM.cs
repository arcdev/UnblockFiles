// ReSharper disable InconsistentNaming

using System;

namespace Lib
{
	/// <summary>
	/// The STGM constants are flags that indicate conditions for creating and deleting the object and access modes for the object. The STGM constants are included in the IStorage, IStream, and IPropertySetStorage interfaces and in the StgCreateDocfile, StgCreateStorageEx, StgCreateDocfileOnILockBytes, StgOpenStorage, and StgOpenStorageEx functions.
	/// These elements are often combined using an ORoperator.They are interpreted in groups as listed in the following table.It is not valid to use more than one element from a single group.
	/// Use a flag from the creation group when creating an object, such as with StgCreateStorageEx or IStorage::CreateStream.
	/// </summary>
	/// <a href="https://msdn.microsoft.com/en-us/library/aa380337(v=vs.85).aspx">source</a>
	[Flags]
	public enum STGM : long
	{
		//Access	
		READ = 0x00000000L,
		WRITE = 0x00000001L,
		READWRITE = 0x00000002L,
		//Sharing
		SHARE_DENY_NONE = 0x00000040L,
		SHARE_DENY_READ = 0x00000030L,
		SHARE_DENY_WRITE = 0x00000020L,
		SHARE_EXCLUSIVE = 0x00000010L,
		PRIORITY = 0x00040000L,
		//Creation
		CREATE = 0x00001000L,
		CONVERT = 0x00020000L,
		FAILIFTHERE = 0x00000000L,
		//Transactioning
		DIRECT = 0x00000000L,
		TRANSACTED = 0x00010000L,
		//Transactioning Performance
		NOSCRATCH = 0x00100000L,
		NOSNAPSHOT = 0x00200000L,
		//Direct SWMR and Simple
		SIMPLE = 0x08000000L,
		DIRECT_SWMR = 0x00400000L,
		//Delete On Release
		DELETEONRELEASE = 0x04000000L
	}
}