using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MaliciousFileProcessor
{
    public class FileHelper
    {
        #region Fields
        IEnumerable<string> filters = null;
        public int i = 0;
        private Dictionary<string, string> maliciousUrls = new Dictionary<string, string>();
        private Dictionary<string, string> maliciousDomains = new Dictionary<string, string>();

        private object mLock = new object();
        private object dLock = new object();

        string dailyPath = @"C:\Users\user\Desktop\MaliciousFile\MaliciousUrlDaily.zip";
        string weeklyPath = @"C:\Users\user\Desktop\MaliciousFile\MaliciousUrlWeekly.zip";
        #endregion

        #region Methods
        public void ReadFilters(string path)
        {
            filters = ReadLinesFromZippFile(weeklyPath, "Papa@Petux1973#aval$4700");

            foreach (var filterText in filters)
            {
                if (filterText.StartsWith("!--Skip from Version"))
                {
                    break;
                }
                if (!filterText.StartsWith("!") && !filterText.StartsWith("[") && filterText.ToString() != "")
                {
                    AddMaliciousUrlFilter(filterText);
                }
            }

            Console.WriteLine("Filter Counts : " + maliciousUrls.Count());
            Console.WriteLine("Domain Counts :" + maliciousDomains.Count());
            Console.WriteLine("Exceptions :" + i);
        }

        public void AddMaliciousUrlFilter(string filter)
        {
            lock (mLock)
            {
                if (filter != null)
                {
                    if (!maliciousUrls.ContainsKey(filter))
                    {
                        maliciousUrls.Add(filter, "u");
                    }

                    try
                    {
                        Uri filterDomain = new Uri(filter);
                        maliciousDomains.Add(filterDomain.AbsoluteUri, "d");
                    }
                    catch (Exception ex)
                    {
                        i++;
                        Console.WriteLine(filter);
                    }
                }
            }
        }

        private void AddMaliciousUrlDomain(string filter)
        {
            lock (dLock)
            {
                if (filter != null)
                {
                    if (!maliciousUrls.ContainsKey(filter))
                    {
                        maliciousUrls.Add(filter, "u");
                    }

                    try
                    {
                        Uri filterDomain = new Uri(filter);
                        maliciousDomains.Add(filterDomain.AbsoluteUri, "d");
                    }
                    catch (Exception ex)
                    {
                        i++;
                    }
                }
            }
        }


        public static IEnumerable<string> ReadLinesFromZippFile(string filterFilePath, string password)
        {
            var file = ExtractZipFile(filterFilePath, password);
            if (file.Count() == 1)
            {
                // ensure stream rewind
                file[0].Position = 0;
                using (var sr = new StreamReader(file[0]))
                {
                    while (!sr.EndOfStream)
                    {
                        yield return sr.ReadLine();
                    }
                }
            }
        }

        public static MemoryStream[] ExtractZipFile(string archiveFilenameIn, string password)
        {
            var res = new List<MemoryStream>();

            ZipFile zf = null;
            try
            {
                FileStream fs = File.OpenRead(archiveFilenameIn);
                zf = new ZipFile(fs);
                if (!String.IsNullOrEmpty(password))
                {
                    zf.Password = password; // AES encrypted entries are handled automatically
                }

                foreach (ZipEntry zipEntry in zf)
                {
                    if (!zipEntry.IsFile)
                    {
                        continue; // Ignore directories
                    }

                    String entryFileName = zipEntry.Name;
                    // to remove the folder from the entry:- entryFileName = Path.GetFileName(entryFileName);
                    // Optionally match entrynames against a selection list here to skip as desired.
                    // The unpacked length is available in the zipEntry.Size property.

                    byte[] buffer = new byte[4096]; // 4K is optimum
                    Stream zipStream = zf.GetInputStream(zipEntry);


                    // Unzip file in buffered chunks. This is just as fast as unpacking to a buffer the full size
                    // of the file, but does not waste memory.
                    // The "using" will close the stream even if an exception occurs.
                    var streamWriter = new MemoryStream();
                    StreamUtils.Copy(zipStream, streamWriter, buffer);
                    res.Add(streamWriter);

                }
            }
            finally
            {
                if (zf != null)
                {
                    zf.IsStreamOwner = true; // Makes close also shut the underlying stream
                    zf.Close(); // Ensure we release resources
                }
            }

            return res.ToArray();
        }
        #endregion
    }
}
