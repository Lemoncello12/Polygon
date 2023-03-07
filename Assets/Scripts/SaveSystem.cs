using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayer(LocalSave save)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/polygondata.pasta";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(save);

        //Stopped at timestamp 10:58 of the video
    }
}
