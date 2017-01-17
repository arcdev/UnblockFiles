using System.Runtime.InteropServices;

namespace Lib
{
	/*
MIDL_INTERFACE("cd45f185-1b21-48e2-967b-ead743a8914e")
IZoneIdentifier : public IUnknown
{
public:
	virtual HRESULT STDMETHODCALLTYPE GetId( 
		// [out]
	__RPC__out DWORD * pdwZone) = 0;

	virtual HRESULT STDMETHODCALLTYPE SetId(
		// [in] 
		DWORD dwZone) = 0;

	virtual HRESULT STDMETHODCALLTYPE Remove(void) = 0;

};

*/

	/// <summary>
	/// Provides methods for getting and setting the security zone for a file
	/// </summary>
	/// <remarks>The IZoneIdentifier interface inherits from the IUnknown interface</remarks>
	/// <a href="https://msdn.microsoft.com/en-us/library/ms537032%28v=vs.85%29.aspx?f=255&amp;MSPPError=-2147217396">source</a>
	[ComImport]
	[Guid("cd45f185-1b21-48e2-967b-ead743a8914e")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IZoneIdentifier //: IUnknown
	{
		/// <summary>
		/// Gets the current security zone.
		/// </summary>
		/// <param name="pdwZone">A pointer to a <see cref="URLZONE"/> value.</param>
		/// <returns>S_OK Indicates success; E_ACCESSDENIED Indicates that dwZone is an untrusted zone.</returns>
		/// <remarks>This method can also return an HRESULT derived from the Microsoft Win32 error code ERROR_NOT_FOUND to indicate that the zone is unavailable.</remarks>
		int GetId(out URLZONE pdwZone);
		
		/// <summary>
		/// Sets the current security zone.
		/// </summary>
		/// <param name="dwZone"></param>
		/// <returns>S_OK Indicates success; E_ACCESSDENIED Indicates that dwZone is an untrusted zone.</returns>
		int SetId(URLZONE dwZone);

		/// <summary>
		/// Sets the current zone to <see cref="URLZONE.LOCAL_MACHINE"/>
		/// </summary>
		/// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		int Remove();
	}
}