using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameController : MonoBehaviour
{
    public int[] highScores = new int[10];


    private GameData CreateSaveDataObject()
    {
        GameData save = new GameData();
        for (int i = 0; i < highScores.Length; i++)
        {
            save.highScores[i] = highScores[i];
        }
        return save;
    }

    public void SaveHighScores(int score)
    {
        //Use the score to update the highScores array of the game controller
        //In the code below, I am using hard coded values to show you how the saving process works
        //Your code should add the score in the highScores array of the game controller
        highScores[0] = 10;
        highScores[1] = 20;
        highScores[2] = 30;
        highScores[3] = 40;
        highScores[4] = 50;
        highScores[5] = 65;

        GameData save = CreateSaveDataObject();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gameSave.save");
        bf.Serialize(file, save);
        file.Close();
    }

    public void ReadHighScores()
    {
        if (File.Exists(Application.persistentDataPath + "/gameSave.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gameSave.save", FileMode.Open);
            GameData save = (GameData)bf.Deserialize(file);
            file.Close();

            for (int i = 0; i < highScores.Length; i++)
            {
                highScores[i] = save.highScores[i];
            }
        }
    }


}
