﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
  public class FileHelper
    {
        public static void BytesToDisk(byte[] data, string filename)
        {
            try
            {
                FileStream stream = new FileStream(filename, FileMode.Create);
                BinaryWriter writer = new BinaryWriter(stream);
                writer.Write(data);
                writer.Close();
            }
            catch (Exception ex)
            {
            }
        }

        public static byte[] DiskToBytes(string filename)
        {
            try
            {
                FileStream stream = new FileStream(filename, FileMode.Open);
                byte[] bytes = new byte[stream.Length];
                stream.Read(bytes, 0, (int)stream.Length);
                stream.Close();
                return bytes;
            }
            catch (Exception ex)
            {
                //EventLogger.WriteEntry("MX2", ex.Message, EventLogEntryType.Error, 742);
                return new byte[0];
            }
        }

        public static void CheckOrCreateDirectory(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }

        public static bool CheckFileExists(string filename)
        {
            if (File.Exists(filename))
                return true;
            else
                return false;

        }

        public static void CreateTextFile(string text, string fileName)
        {
            StreamWriter sw = File.CreateText(fileName);
            sw.Write(text);
            sw.Close();
        }
        public static void AppendToTextFile(string text, string fileName)
        {
            StreamWriter sw = File.AppendText(fileName);
            sw.WriteLine(text);
            sw.Close();
        }

        public static bool OpenFile(string path)
        {
            if (path != String.Empty)
            {
                if (File.Exists(path))
                {
                    try
                    {
                        Process p = Process.Start(path);
                        return true;
                    }
                    catch
                    {
                        return false;                        
                    }
                }
            }
            return false;
        }
        public static bool RenameFile(string originalPath, string newPath)
        {
            if (originalPath != String.Empty && newPath != String.Empty)
            {
                if (File.Exists(originalPath))
                {
                    try
                    {
                        File.Move(originalPath, newPath);
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
            return false;
        }
        public static void DeleteFile(string filename)
        {
            if (filename != String.Empty)
                if (File.Exists(filename))
                    File.Delete(filename);
        }
    }
}

