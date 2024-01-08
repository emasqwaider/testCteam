using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FileReadWriteDataSaver : DataSaveBase
{
    public List<PlayerProfile> playerProfiles = new List<PlayerProfile>();

    private PlayerProfile player = new PlayerProfile();
    public PlayerProfile player1 = new PlayerProfile();
    public PlayerProfile player2 = new PlayerProfile();

    bool isAiPlayer1 = false;
    bool isAiPlayer2 = false;
    public bool isMainMenu = true;

    public Text playername;
    public int carType = 0;

    public carmodels cars;



    private void Start()
    {
        if (isMainMenu)
        {
            //try
            //{
            //    Load();
            //}
            //catch
            //{

            //    if (playerProfiles.Count < 2)
            //    {
            //        // Create a fake profile for player 1
            //        PlayerProfile fakePlayer1 = new PlayerProfile
            //        {
            //            playerName = "FakePlayer1",
            //            carType = 1,  // Set the desired car type
            //            isAi = true   // You can set isAi to true for AI profiles
            //        };
            //        playerProfiles.Add(fakePlayer1);

            //        // Create a fake profile for player 2
            //        PlayerProfile fakePlayer2 = new PlayerProfile
            //        {
            //            playerName = "FakePlayer2",
            //            carType = 2,  // Set the desired car type
            //            isAi = true   // You can set isAi to true for AI profiles
            //        };
            //        playerProfiles.Add(fakePlayer2);
            //    }

            //    // Save the updated profiles to the file
            //    Save();
            //}
            //playerProfiles.Clear();
        }
        else
        {
            Load();
        }
        
    }
    public void SetPlayer1Ai()
    {
        isAiPlayer1 = true;
        player1.isAi = true;
    }
    public void SetPlayer2Ai()
    {
        isAiPlayer2 = true;
        player2.isAi = true;
    }
    public void CreatProfile()
    {

        PlayerProfile newPlayer = new PlayerProfile(); // Create a new PlayerProfile object

        newPlayer.playerName = playername.text;
        newPlayer.carType = carType;

        if ( playerProfiles.Count >= 1)
        {
            newPlayer.player2 = true;
            newPlayer.player1 = !newPlayer.player2;
        }else
        {
            newPlayer.player1 = true;
            newPlayer.player2 = !newPlayer.player1;
        }



        playerProfiles.Add(newPlayer);

        Debug.Log("Create Profile Function");
        foreach (var profile in playerProfiles)
        {
            Debug.Log(profile.playerName);
        }
    }
     public void CarTypePlayer1()
    {
        Debug.Log(cars.index);
        player1.carType = cars.index;
        Player1();
    }
    public void CarTypePlayer2()
    {
        player2.carType = cars.index;
        Player2();
    }
    public void Player1()
    {
        Debug.Log($"player1 name: {player1.playerName}, carType: {player1.carType}, is Ai? {player1.isAi}");
    }
    public void Player2()
    {
        Debug.Log($"player2 name: {player2.playerName}, carType: {player2.carType}, is Ai? {player2.isAi}");
    }
    public override void Save()
    {
        string path = Application.persistentDataPath + "/PlayerProfiles.txt";

        using (StreamWriter writer = new StreamWriter(path))
        {
            foreach (var playerProfile in playerProfiles)
            {
                Debug.Log(playerProfile.playerName + "  Save()");

                writer.WriteLine($"{playerProfile.playerName},{playerProfile.carType},{playerProfile.isAi},{playerProfile.player1},{playerProfile.player2},{playerProfile.time},{playerProfile.coins}");
            }
        }
    }

    public override void Load()
    {
        string path = Application.persistentDataPath + "/PlayerProfiles.txt";
        Debug.Log(Application.persistentDataPath);

        if (File.Exists(path))
        {
            playerProfiles.Clear();

            using (StreamReader reader = new StreamReader(path))
            {
                List<string> lines = new List<string>();

                string currentLine;
                while ((currentLine = reader.ReadLine()) != null)
                {
                    lines.Add(currentLine);
                }

                if (lines != null)
                {
                    foreach (string line in lines)
                    {
                        string[] values = line.Split(',');

                        if (values.Length == 7)
                        {
                            PlayerProfile newProfile = new PlayerProfile();
                            newProfile.playerName = values[0];
                            newProfile.carType = int.Parse(values[1]);
                            newProfile.isAi    = bool.Parse(values[2]);
                            newProfile.player1 = bool.Parse(values[3]);
                            newProfile.player2 = bool.Parse(values[4]);
                            newProfile.time    = float.Parse(values[5]);
                            newProfile.coins   = int.Parse(values[6]);
                            playerProfiles.Add(newProfile);
                        }
                        else
                        {
                            Debug.LogError("Invalid line format: " + line);
                        }
                    }
                }
                else
                {
                    Debug.LogError("Lines list is null");
                }
            }

            int profileCount = playerProfiles.Count;

            if (profileCount >= 2)
            {
                // Assign the last two profiles to player1 and player2
                player1 = playerProfiles[profileCount - 2];
                player2 = playerProfiles[profileCount - 1];
            }
            else
            {
                // player1 = playerProfiles[profileCount - 2];
                // Debug.LogError("Insufficient profiles to assign to player1 and player2");
               // throw new ArgumentNullException(nameof(playerProfiles));
            }

            foreach (var playerProfile in playerProfiles)
            {
                Debug.Log("Player Name: " + playerProfile.playerName + ", Car Type: " + playerProfile.carType +
                    ", isPlayer1= " + playerProfile.player1 + ", isPlayer2= "+playerProfile.player2+ " time = "+ playerProfile.time);
            }
        }
        else
        {
            Debug.Log("File does not exist at path: " + path);
        }
    }

    public void EditCarType(string playerName, int newCarType)
    {
        PlayerProfile targetPlayer = playerProfiles.Find(profile => profile.playerName == playerName);

        if (targetPlayer != null)
        {
            targetPlayer.carType = newCarType;

            Save();

            Debug.Log($"Car type for {playerName} updated to {newCarType}");
        }
        else
        {
            Debug.LogError($"Player profile not found for {playerName}");
        }
    }

}