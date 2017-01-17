// ReSharper disable InconsistentNaming
namespace Lib
{
	/// <summary>
	/// Contains all the predefined zones used by Windows Internet Explorer.
	/// </summary>
	/// <remarks>In Windows Server 2003 and later, to specify a zone in the enhanced security configuration, combine one of the above values with ESC_FLAG using a bitwise OR.</remarks>
	/// <a href="https://msdn.microsoft.com/en-us/library/ms537175(v=vs.85).aspx">source</a>
	public enum URLZONE
	{
		/// <summary>
		/// Internet Explorer 7. Invalid zone. Used only if no appropriate zone is available.
		/// </summary>
		INVALID = -1,
		/// <summary>
		/// Minimum value for a predefined zone.
		/// </summary>
		PREDEFINED_MIN = 0,
		/// <summary>
		/// Zone used for content already on the user's local computer. This zone is not exposed by the user interface.
		/// </summary>
		LOCAL_MACHINE = 0,
		/// <summary>
		/// Zone used for content found on an intranet
		/// </summary>
		INTRANET,
		/// <summary>
		/// Zone used for trusted Web sites on the Internet
		/// </summary>
		TRUSTED,
		/// <summary>
		/// Zone used for most of the content on the Internet
		/// </summary>
		INTERNET,
		/// <summary>
		/// Zone used for Web sites that are not trusted
		/// </summary>
		UNTRUSTED,
		/// <summary>
		/// Maximum value for a predefined zone
		/// </summary>
		PREDEFINED_MAX = 999,
		/// <summary>
		/// Minimum value allowed for a user-defined zone
		/// </summary>
		USER_MIN = 1000,
		/// <summary>
		/// Maximum value allowed for a user-defined zone
		/// </summary>
		USER_MAX = 10000
	}
}