using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoad
{

    public static List<Player> savedPlayers = new List<Player>();
    public static List<byte[]> savedImages = new List<byte[]>();

    //it's static so we can call it from anywhere
    public static void Save()
    {
        SaveLoad.savedPlayers.Add(GameManager.instance.getPlayer());
        BinaryFormatter bf = new BinaryFormatter();
        //Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
        FileStream file = File.Create(Application.persistentDataPath + "/savedGames.gd"); //you can call it anything you want
        bf.Serialize(file, SaveLoad.savedPlayers);
        file.Close();
    }

    //it's static so we can call it from anywhere
    public static void SaveImage(byte[] im)
    {
        SaveLoad.savedImages.Add(im);
        BinaryFormatter bf = new BinaryFormatter();
        //Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
        FileStream file = File.Create(Application.persistentDataPath + "/savedIm.gd"); //you can call it anything you want
        bf.Serialize(file, SaveLoad.savedImages);
        file.Close();
    }
    public static void clear()
    {
        if (File.Exists(Application.persistentDataPath + "/savedGames.gd"))
        {
            File.Delete(Application.persistentDataPath + "/savedGames.gd");
           
        }
    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/savedGames.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
            SaveLoad.savedPlayers = (List<Player>)bf.Deserialize(file);
            file.Close();
        }
        if (File.Exists(Application.persistentDataPath + "/savedIm.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedIm.gd", FileMode.Open);
            SaveLoad.savedImages = (List<byte[]>)bf.Deserialize(file);
            file.Close();
        }
    }
}

