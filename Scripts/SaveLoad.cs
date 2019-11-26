using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoad : MonoBehaviour
{
   public static void Save<T>(T objectToSave, string key) {
        string path = Application.persistentDataPath + "/saves/";
        Directory.CreateDirectory(path);
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream fileStream = new FileStream(path + key + ".txt", FileMode.Create)) {
            formatter.Serialize(fileStream, objectToSave);
        }

        Debug.Log("saved!");
    }

    public static T Load<T>(string key) {
        string path = Application.persistentDataPath + "/saves/";
        BinaryFormatter formatter = new BinaryFormatter();
        T returnValue = default(T);
        using (FileStream fileStream = new FileStream(path + key + ".txt", FileMode.Open)) {
            returnValue = (T) formatter.Deserialize(fileStream);
        }

        return returnValue;
    }

    public static bool SaveExists(string key, string formate) {
        string path = Application.persistentDataPath + "/saves/" + key + formate;
        return File.Exists(path);
    }

    public static void SeriouslyDeleteAllSaveFiles() {
        string path = Application.persistentDataPath + "/saves/";
        DirectoryInfo directory = new DirectoryInfo(path);
        directory.Delete(true);
        Directory.CreateDirectory(path);
    }

    
    public static void SaveTexture(Texture2D texture, string key) {
        // convert texture 
        Texture2D newTex = new Texture2D(1024, 1024, TextureFormat.RGBA32, false);  
        newTex.SetPixels(texture.GetPixels());
        newTex.Apply();
        
        // encode and save 
        byte[] bytes = newTex.EncodeToPNG();
        string path = Application.persistentDataPath + "/saves/"+ key +".png";
        File.WriteAllBytes(path, bytes);
        
    }

    public static Texture2D LoadTexture(string key) {
        string path = Application.persistentDataPath + "/saves/"+ key +".png";
        byte[] data = File.ReadAllBytes(path);
        Texture2D newTex = new Texture2D(1024, 1024, TextureFormat.RGBA32, false); 
        newTex.LoadImage(data);
        newTex.Apply();
        
        return newTex;
    }
}
