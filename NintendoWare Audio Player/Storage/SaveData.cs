using MessagePack;
using System.Collections.Generic;

namespace NintendoWare_Audio_Player.Storage
{
    [MessagePackObject]
    public class SaveData
    {
        [Key(0)]
        public Dictionary<string, string> audioFileData = 
            new Dictionary<string, string>();
    }
}