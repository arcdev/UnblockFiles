//using System.Runtime.InteropServices;
//
//namespace Lib
//{
//	/*
//MIDL_INTERFACE("0000010b-0000-0000-C000-000000000046")
//IPersistFile : public IPersist
//{
//public:
//	virtual HRESULT STDMETHODCALLTYPE IsDirty( void) = 0;
//
//	virtual HRESULT STDMETHODCALLTYPE Load( 
//		/* [in]
//		__RPC__in LPCOLESTR pszFileName,
//		/* [in]
//		DWORD dwMode) = 0;
//
//	virtual HRESULT STDMETHODCALLTYPE Save(
//		/* [unique][in]
//		__RPC__in_opt LPCOLESTR pszFileName,
//		/* [in]
//		BOOL fRemember) = 0;
//
//	virtual HRESULT STDMETHODCALLTYPE SaveCompleted(
//		/* [unique][in]
//		__RPC__in_opt LPCOLESTR pszFileName) = 0;
//
//	virtual HRESULT STDMETHODCALLTYPE GetCurFile(
//		/* [out]
//		__RPC__deref_out_opt LPOLESTR *ppszFileName) = 0;
//
//};
//
// */
//
//
//	/// <summary>
//	/// Enables an object to be loaded from or saved to a disk file, rather than a storage object or stream. Because the information needed to open a file varies greatly from one application to another, the implementation of IPersistFile::Load on the object must also open its disk file
//	/// </summary>
//	/// <a href="https://msdn.microsoft.com/en-us/library/ms687223%28v=vs.85%29.aspx?f=255&amp;MSPPError=-2147217396">source</a>
//	[ComImport]
//	[Guid("0000010b-0000-0000-C000-000000000046")]
//	public interface IPersistFile
//	{
//		/// <summary>
//		/// Determines whether an object has changed since it was last saved to its current file
//		/// </summary>
//		/// <returns>This method returns S_OK to indicate that the object has changed. Otherwise, it returns S_FALSE.</returns>
//		/// <a href="https://msdn.microsoft.com/en-us/library/ms682410(v=vs.85).aspx">source</a>
//		int IsDirty();
//
//		/// <summary>
//		/// Opens the specified file and initializes an object from the file contents
//		/// </summary>
//		/// <param name="pszFileName">The absolute path of the file to be opened</param>
//		/// <param name="dwMode">The access mode to be used when opening the file. Possible values are taken from the STGM enumeration. The method can treat this value as a suggestion, adding more restrictive permissions if necessary. If dwMode is 0, the implementation should open the file using whatever default permissions are used when a user opens the file.</param>
//		/// <returns>
//		/// S_OK - The method completed successfully.
//		/// E_OUTOFMEMORY - The object could not be loaded due to a lack of memory.
//		/// E_FAIL - The object could not be loaded for some reason other than a lack of memory.
//		/// </returns>
//		int Load(string pszFileName, STGM dwMode);
//
//		/// <summary>
//		/// Saves a copy of the object to the specified file
//		/// </summary>
//		/// <param name="pszFileName">The absolute path of the file to which the object should be saved. If pszFileName is NULL, the object should save its data to the current file, if there is one.</param>
//		/// <param name="fRemember">Indicates whether the pszFileName parameter is to be used as the current working file. If TRUE, pszFileName becomes the current file and the object should clear its dirty flag after the save. If FALSE, this save operation is a Save A Copy As ... operation. In this case, the current file is unchanged and the object should not clear its dirty flag. If pszFileName is NULL, the implementation should ignore the fRemember flag.</param>
//		/// <returns>If the object was successfully saved, the return value is S_OK. Otherwise, it is S_FALSE. This method can also return various storage errors.</returns>
//		/// <a href="https://msdn.microsoft.com/en-us/library/ms693701(v=vs.85).aspx">source</a>
//		int Save(string pszFileName, bool fRemember);
//
//		/// <summary>
//		/// Notifies the object that it can write to its file
//		/// </summary>
//		/// <param name="pszFileName">The absolute path of the file where the object was saved previously</param>
//		/// <returns>This method always returns S_OK</returns>
//		/// <a href="https://msdn.microsoft.com/en-us/library/ms694310(v=vs.85).aspx">source</a>
//		int SaveCompleted(string pszFileName);
//
//		/// <summary>
//		/// Retrieves the current name of the file associated with the object.
//		/// </summary>
//		/// <param name="ppszFileName">The path for the current file or the default file name prompt (such as *.txt). If an error occurs, ppszFileName is set to NULL</param>
//		/// <returns>
//		/// S_OK - A valid absolute path was returned successfully.
//		/// S_FALSE - The default save prompt was returned.
//		/// S_OUTOFMEMRORY - The operation failed due to insufficient memory.
//		/// E_FAIL - The operation failed due to some reason other than isufficient memory.
//		/// </returns>
//		/// <a href="https://msdn.microsoft.com/en-us/library/ms683925(v=vs.85).aspx">source</a>
//		int GetCurFile(out string ppszFileName);
//	}
//}