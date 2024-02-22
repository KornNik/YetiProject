using Skytanet.SimpleDatabase;

namespace Helpers.Extensions
{
    static class SaveFileExtender
    {
        public static bool IsSaveFileExist(string saveFileName, string keyName)
        {
            SaveFile saveFile = new SaveFile(saveFileName);
            var saveFileStatus = saveFile.HasKey(keyName);
            saveFile.Close();
            return saveFileStatus;
        }
        public static T LoadFile<T>(string saveFileName, string keyName)
        {
            if (IsSaveFileExist(saveFileName, keyName))
            {
                SaveFile saveFile = new SaveFile(saveFileName);
                var data = saveFile.Get<T>(keyName);
                saveFile.Close();
                return data;
            }
            else
            {
                return default;
            }
        }
        public static void SaveFile(string saveFileName, string keyName, object saveValue)
        {
            if (IsSaveFileExist(saveFileName, keyName))
            {
                SaveFile saveFile = new SaveFile(saveFileName);
                saveFile.Set(keyName, saveValue);
                saveFile.Close();
            }
        }
        public static void SaveFileFresh(string saveFileName, string keyName, object saveValue)
        {
            SaveFile saveFile = new SaveFile(saveFileName);
            saveFile.Set(keyName, saveValue);
            saveFile.Close();
        }
        public static void DeleteSaveFile(string saveFileName, string keyName)
        {
            if (IsSaveFileExist(saveFileName, keyName))
            {
                SaveFile saveFile = new SaveFile(saveFileName);
                saveFile.Delete(keyName);
                saveFile.Close();
            }
        }
    }
}
