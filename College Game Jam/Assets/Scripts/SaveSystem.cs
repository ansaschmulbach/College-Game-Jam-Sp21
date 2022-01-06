using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{

    public static void SaveSkewer(SkewerController sc)
    {
        Debug.Log("Saving!");
        BinaryFormatter bFormatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/skewer.file";
        FileStream stream = new FileStream(path, FileMode.Create);
        SkewerSaveData data = new SkewerSaveData(sc);
        bFormatter.Serialize(stream, data);
        stream.Close();
    }
    
    
    public static SkewerSaveData LoadSkewer()
    {
        string path = Application.persistentDataPath + "/skewer.file";
        if (File.Exists(path))
        {
            BinaryFormatter bFormatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            SkewerSaveData ssd = bFormatter.Deserialize(stream) as SkewerSaveData;
            stream.Close();
            return ssd;
        }
        else
        {
            Debug.Log("yikesssss");
            return null;
        }
    }

}
