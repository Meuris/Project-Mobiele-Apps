﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneClassLibrary1
{
    public class FileIO
    {
        public void SaveDataToFile(string filename, string text)
        {
            using (Mutex mutex = new Mutex(true, "MyData"))
            {
                mutex.WaitOne();
                try
                {
                    using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
                    {
                        using (IsolatedStorageFileStream rawStream = isf.CreateFile(filename))
                        {
                            StreamWriter writer = new StreamWriter(rawStream);
                            writer.Write(text);
                            writer.Close();
                        }
                    }
                }
                catch { }
                finally
                {
                    mutex.ReleaseMutex();
                }
            }
        }
    }
}
