using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Windows.Storage;

namespace Live_Clock_Tile.Core
{
    public class LibraryFace
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public string Img { get; set; }
        public string Wide { get; set; }

    }

    public class LibraryList
    {
        List<LibraryFace> lib = new List<LibraryFace>();

        public LibraryList()
        {
            //load new list from file
        }

        public List<LibraryFace> getList()
        {
            return loadData();
        }

        public List<LibraryFace> justGetList()
        {
            return lib;
        }

        public void justSave()
        {
            saveData();
        }


        public void justAdd(string name, string img, string wide)
        {
            if (!doesNameExist(name))
            {
                lib.Add(new LibraryFace { Name = name, Price = "free", Img = img, Wide = wide });
            }
        }

        public void add(string name, string img, string wide)
        {
            if (!doesNameExist(name))
            {
                lib.Add(new LibraryFace { Name = name, Price = "free", Img = img, Wide = wide });
                saveData();
            }
        }

        public List<LibraryFace> loadData()
        {
            try
            {
                using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream stream = myIsolatedStorage.OpenFile("Clocks.xml", FileMode.Open))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(List<LibraryFace>));
                        lib = (List<LibraryFace>)serializer.Deserialize(stream);
                        return lib;
                    }
                }
            }
            catch
            {
                //add some code here
            }
            return lib; 
        }

        public void saveData()
        {
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.Indent = true;

            using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream stream = myIsolatedStorage.OpenFile("Clocks.xml", FileMode.Create))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<LibraryFace>));
                    using (XmlWriter xmlWriter = XmlWriter.Create(stream, xmlWriterSettings))
                    {
                        serializer.Serialize(xmlWriter, lib);
                    }
                }
            }

        }

        public void deleteData()
        {
            var isoStore = IsolatedStorageFile.GetUserStoreForApplication();

            if (isoStore.FileExists("Clocks.xml")) 
            { 
                isoStore.DeleteFile("Clocks.xml");
            }
        }

        public bool doesNameExist(string name)
        {
            foreach (LibraryFace l in lib)
            {
                if (l.Name.Equals(name))
                    return true;
            }
            return false;
        }
    }
}
