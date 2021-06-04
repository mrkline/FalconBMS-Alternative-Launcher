using System.IO;

namespace FalconBMS.Launcher
{
    class Backup
    {
        private static readonly string backupDir = "/User/Config/Backup/";

        public static void CreateDirectory(AppRegInfo appReg)
        {
            if (!Directory.Exists(appReg.GetInstallDir() + backupDir))
            {
                Directory.CreateDirectory(appReg.GetInstallDir() + backupDir);
            }
        }

        public static void CopyFileAndMakeWriteable(AppRegInfo appReg, string src)
        {
            string fbackupname = appReg.GetInstallDir() + backupDir + Path.GetFileName(src);
            if (!File.Exists(fbackupname) & File.Exists(src))
            {
                File.Copy(src, fbackupname, false);
            }
            File.SetAttributes(src, File.GetAttributes(src) & ~FileAttributes.ReadOnly);
        }
    }
}
