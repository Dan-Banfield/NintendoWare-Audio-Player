using System.IO;
using MessagePack;

namespace NintendoWare_Audio_Player.Storage
{
    public static class SaveSystem
    {
        private const string SAVE_FILE_NAME = "save.dat";

        public static SaveData saveDataInstance = LoadSaveData();

        public static void SaveCurrentData()
        {
            byte[] saveDataBytes = MessagePackSerializer.Serialize(saveDataInstance);
            File.WriteAllBytes(SAVE_FILE_NAME, saveDataBytes);
        }

        private static SaveData LoadSaveData()
        {
            if (!File.Exists(SAVE_FILE_NAME)) return new SaveData();

            byte[] saveDataBytes = File.ReadAllBytes(SAVE_FILE_NAME);
            return saveDataBytes.Length == 0 ?
                new SaveData() : 
                MessagePackSerializer.Deserialize<SaveData>(saveDataBytes);
        }
    }
}