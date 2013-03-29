using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.IO.IsolatedStorage;
using System.IO;
using Microsoft.Phone.Storage;
using Windows.Storage;

namespace QuestionAppTemplate.Classes
{
    /// <summary>
    /// Provides helper methods for serialization and retrieval of files in the Windows Phone architecture.
    /// </summary>
    public sealed class FileIO
    {
        /// <summary>
        /// Retrieves a file from the Local Folder, 1 folder deep.
        /// </summary>
        /// <param name="folderName">The folder name in which the file is nested in.</param>
        /// <param name="location">The relative location of the file.</param>
        /// <returns>Returns a string containing the content of the file.</returns>
        public static async Task<string> ReadLocalFolder(string folderName, string location)
        {
            StorageFolder local = ApplicationData.Current.LocalFolder;
            StorageFolder internalFolder = await local.GetFolderAsync(folderName);
            Stream file = await internalFolder.OpenStreamForReadAsync(location);
            StreamReader reader = new StreamReader(file);
            return await reader.ReadToEndAsync();
        }

        public static async Task<string> ReadStaticResource(string fileName)
        {
            Stream resource = System.Windows.Application.GetResourceStream(new Uri(fileName, UriKind.Relative)).Stream;
            return await new StreamReader(resource).ReadToEndAsync();
        }

        /// <summary>
        /// Adds a file to Isolated Storage.
        /// </summary>
        /// <typeparam name="T">Object Type to Serialize</typeparam>
        /// <param name="obj">Object to serialize.</param>
        /// <param name="fileName">Location of the file in Isolated Storage</param>
        /// <param name="callback">Accepts an anonymous method that handles an exception.</param>
        public static void WriteIsolatedStorage<T>(T obj, string fileName, Action<Exception> callback)
        {
            XmlWriterSettings writerSettings =
                    new XmlWriterSettings
                    {
                        Indent = true,
                        IndentChars = "\t"
                    };

            try
            {
                var store = IsolatedStorageFile.GetUserStoreForApplication();
                IsolatedStorageFileStream stream = store.OpenFile(fileName, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);

                XmlSerializer serializer = new XmlSerializer(typeof(T));

                using (XmlWriter xmlWriter = XmlWriter.Create(stream, writerSettings))
                {
                    serializer.Serialize(xmlWriter, obj);
                }

                stream.Close();
            }
            catch (Exception emAll)
            {
                callback(emAll);
            }
        }


        /// <summary>
        /// Reads a file from the Isolated Storage.
        /// </summary>
        /// <typeparam name="T">Object Type to return</typeparam>
        /// <param name="fileName">File Location of the object.</param>
        /// <param name="callback">Callback if an exception occurs.</param>
        /// <returns></returns>
        public static T WriteIsolatedStorage<T>(string fileName, Action<Exception> callback)
        {
            try
            {
                var store = IsolatedStorageFile.GetUserStoreForApplication();
                IsolatedStorageFileStream stream = store.OpenFile(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);

                XmlSerializer serializer = new XmlSerializer(typeof(T));
                object a = serializer.Deserialize(stream);

                if (a == null) { callback(new Exception("Object Null")); }
                stream.Close();
                return (T)a;
            }
            catch (Exception emAll)
            {
                callback(emAll);
            }
            return default(T);
        }


    }

}

