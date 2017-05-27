using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using System;
using System.IO;
using System.Threading;

namespace BenchmarkTeoVincent
{
    class Program
    {
        static void Main(string[] args)
        {
            //for (int i = 0; i < 10; i++) // uncomment and fire up the same test many times
            {
                Summary summary = BenchmarkRunner.Run<CtiTransformatorTester>();
                Console.WriteLine(summary);

                CopyResultsToHistory();
            }

            Console.WriteLine("\n\n press enter to exit...");
            Console.ReadLine();
        }

        static void CopyResultsToHistory()
        {
            string folderName = DateTime.Now.ToString("yy_MM_dd__HH_mm_ss");
            DirectoryCopy(@".\BenchmarkDotNet.Artifacts\results", $@".\TestResultsHistory\{folderName}", true);
        }

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }
    }
}
