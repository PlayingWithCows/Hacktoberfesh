using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    private static GameData s_Instance = null;

    public int playerLevel;
    public int playerExperience;
    public int permanentSkillPoints;
    public int money;
    public int premiumMoney;
    public string selectedMap;
    public int advertBoostLevel;
    public float advertBoostTimeLeft;
    public List<string> unlockedItems = new List<string>();
    public float playerSpeed = 1;


        void Awake()
    {
        if (s_Instance == null)
        {
            s_Instance = this;
            DontDestroyOnLoad(gameObject);

            SaveData data = SaveManager.LoadGame();
            if (data != null)
            {

                playerLevel = data.playerLevel;
                playerExperience = data.playerExperience;
                permanentSkillPoints = data.permanentSkillPoints;
                money = data.money;
                premiumMoney = data.premiumMoney;
                selectedMap = data.selectedMap;
                advertBoostLevel = data.advertBoostLevel;
                advertBoostTimeLeft = data.advertBoostTimeLeft;
                playerSpeed = data.playerSpeed;


                foreach (string item in data.unlockedItems) 
                {
                    if (item != "empty")
                    {
                        unlockedItems.Add(item);
                    }
                }

            }

        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void SaveGame()
    {
        SaveManager.SaveGame(this);
    }

    public void AddStuff()
    {
        playerLevel += 1;
        money += 100;
    }
}
