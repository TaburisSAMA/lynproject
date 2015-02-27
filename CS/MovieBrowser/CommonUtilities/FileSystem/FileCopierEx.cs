using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace CommonUtilities.FileSystem
{


    public class FileCopierEx
    {

        // ReSharper disable InconsistentNaming
#pragma warning disable 169
        #region Constants

        //constants that specify how the file is to be copied
        private const uint COPY_FILE_ALLOW_DECRYPTED_DESTINATION = 0x00000008;
        private const uint COPY_FILE_FAIL_IF_EXISTS = 0x00000001;
        private const uint COPY_FILE_OPEN_SOURCE_FOR_WRITE = 0x00000004;
        private const uint COPY_FILE_RESTARTABLE = 0x00000002;

        /// <summary>
        /// Callback reason passed as dwCallbackReason in CopyProgressRoutine.
        /// Indicates another part of the data file was copied.
        /// </summary>
        private const uint CALLBACK_CHUNK_FINISHED = 0;

        /// <summary>
        /// Callback reason passed as dwCallbackReason in CopyProgressRoutine.
        /// Indicates another stream was created and is about to be copied. This is the callback reason given when the callback routine is first invoked.
        /// </summary>
        private const uint CALLBACK_STREAM_SWITCH = 1;


        /// <summary>
        /// Return value of the CopyProgressRoutine.
        /// Indicates continue the copy operation.
        /// </summary>
        private const uint PROGRESS_CONTINUE = 0;

        /// <summary>
        /// Return value of the CopyProgressRoutine.
        /// Indicates cancel the copy operation and delete the destination file.
        /// </summary>
        private const uint PROGRESS_CANCEL = 1;

        /// <summary>
        /// Return value of the CopyProgressRoutine.
        /// Indicates stop the copy operation. It can be restarted at a later time.
        /// </summary>
        private const uint PROGRESS_STOP = 2;

        /// <summary>
        /// Return value of the CopyProgressRoutine.
        /// Indicates continue the copy operation, but stop invoking CopyProgressRoutine to report progress.
        /// </summary>
        private const uint PROGRESS_QUIET = 3;

        #endregion
#pragma warning restore 169
        // ReSharper restore InconsistentNaming

        #region Methods

        /// <summary>
        /// The CopyProgressRoutine delegate is an application-defined callback function used with the CopyFileEx and MoveFileWithProgress functions.
        /// It is called when a portion of a copy or move operation is completed.
        /// </summary>
        /// <param name="totalFileSize">Total size of the file, in bytes.</param>
        /// <param name="totalBytesTransferred">Total number of bytes transferred from the source file to the destination file since the copy operation began.</param>
        /// <param name="streamSize">Total size of the current file stream, in bytes.</param>
        /// <param name="streamBytesTransferred">Total number of bytes in the current stream that have been transferred from the source file to the destination file since the copy operation began. </param>
        /// <param name="dwStreamNumber">Handle to the current stream. The first time CopyProgressRoutine is called, the stream number is 1.</param>
        /// <param name="dwCallbackReason">Reason that CopyProgressRoutine was called.</param>
        /// <param name="hSourceFile">Handle to the source file.</param>
        /// <param name="hDestinationFile">Handle to the destination file.</param>
        /// <param name="lpData">Argument passed to CopyProgressRoutine by the CopyFileEx or MoveFileWithProgress function.</param>
        /// <returns>A value indicating how to proceed with the copy operation.</returns>
        protected uint CopyProgressCallback(
            long totalFileSize,
            long totalBytesTransferred,
            long streamSize,
            long streamBytesTransferred,
            uint dwStreamNumber,
            uint dwCallbackReason,
            IntPtr hSourceFile,
            IntPtr hDestinationFile,
            IntPtr lpData)
        {
            switch (dwCallbackReason)
            {
                case CALLBACK_CHUNK_FINISHED:
                    // Another part of the file was copied.
                    var e = new CopyProgressEventArgs(totalFileSize, totalBytesTransferred);
                    InvokeCopyProgress(e);
                    return e.Cancel ? PROGRESS_CANCEL : PROGRESS_CONTINUE;

                case CALLBACK_STREAM_SWITCH:
                    // A new stream was created. We don't care about this one - just continue the move operation.
                    return PROGRESS_CONTINUE;

                default:
                    return PROGRESS_CONTINUE;
            }
        }

        public void CopyFile(string sourceFile, string destinationFile)
        {
            var success = CopyFileEx(sourceFile, destinationFile, this.CopyProgressCallback, IntPtr.Zero, false, COPY_FILE_ALLOW_DECRYPTED_DESTINATION);

            //Throw an exception if the copy failed
            if (!success)
            {
                var error = Marshal.GetLastWin32Error();
                throw new Win32Exception(error);
            }
        }
        #endregion

        #region Events
        public event CopyProgressEventHandler CopyProgress;

        protected void InvokeCopyProgress(CopyProgressEventArgs e)
        {
            if (CopyProgress != null)
            {
                CopyProgress(this, e);
            }
        }
        #endregion

        #region P/Invoke

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool CopyFileEx(
            string lpExistingFileName,
            string lpNewFileName,
            CopyProgressRoutine lpProgressRoutine,
            IntPtr lpData,
            bool pbCancel,
            uint dwCopyFlags
            );
        #endregion

        /// <summary>
        /// The CopyProgressRoutine delegate is an application-defined callback function used with the CopyFileEx and MoveFileWithProgress functions.
        /// It is called when a portion of a copy or move operation is completed.
        /// </summary>
        private delegate uint CopyProgressRoutine(
            long totalFileSize,
            long totalBytesTransferred,
            long streamSize,
            long streamBytesTransferred,
            uint dwStreamNumber,
            uint dwCallbackReason,
            IntPtr hSourceFile,
            IntPtr hDestinationFile,
            IntPtr lpData);
    }


    /// <summary>
    /// Represents the method which handles the CopyProgress event.
    /// </summary>
    public delegate void CopyProgressEventHandler(object sender, CopyProgressEventArgs e);

    /// <summary>
    /// Provides data for the CopyProgress event.
    /// </summary>
    public class CopyProgressEventArgs : EventArgs
    {
        private readonly long _totalFileSize;
        private readonly long _totalBytesTransferred;

        /// <summary>
        /// Initializes a new instance of the CopyProgressEventArgs class.
        /// </summary>
        /// <param name="totalFileSize">The total file size, in bytes.</param>
        /// <param name="totalBytesTransferred">The total bytes transferred so far.</param>
        public CopyProgressEventArgs(long totalFileSize, long totalBytesTransferred)
        {
            Cancel = false;
            _totalFileSize = totalFileSize;
            _totalBytesTransferred = totalBytesTransferred;
        }

        /// <summary>
        /// Gets the total file size, in bytes, of the file being moved.
        /// </summary>
        /// <value>The total file size.</value>
        public long TotalFileSize
        {
            get { return _totalFileSize; }
        }

        /// <summary>
        /// Gets the total bytes transferred so far.
        /// </summary>
        /// <value>The total bytes transferred.</value>
        public long TotalBytesTransferred
        {
            get { return _totalBytesTransferred; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the event should be canceled.
        /// </summary>
        /// <value>True if the event should be canceled, False otherwise.</value>
        public bool Cancel { get; set; }
    }
}