using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TigerForge;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    private int shotBullet, enemyKilled;
    public int totalShotBullet, totalEnemyKilled;
    EasyFileSave myFile;
    void Awake()
    {
        if (Instance==null)
        {
            Instance = this;
            StartProcess();
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    
    void Update()
    {
        
    }

    public int ShotBullet
    {
        get
        {
            return shotBullet;
        }
        set
        {
            shotBullet = value;
            GameObject.Find("ShotBulletText").GetComponent<Text>().text = "SHOT BULLET : " + shotBullet.ToString();
           
        }
    }

    public int EnemyKilled 
    {
        get
        {
            return enemyKilled;
        }
        set
        {
            enemyKilled = value;
            GameObject.Find("EnemyKilledText").GetComponent<Text>().text = "ENEMY KILLED : " + shotBullet.ToString();
            WinProcess();
        }
    
    
    }
    void StartProcess()
    {
        myFile = new EasyFileSave();
        LoadData();
    }
    public void SaveData()
    {
        totalShotBullet += shotBullet;
        totalEnemyKilled += enemyKilled;
        myFile.Add("totalShotBullet", totalShotBullet);
        myFile.Add("totalEnemyKilled", enemyKilled);

        myFile.Save();
    }

    public void LoadData()
    {
        if (myFile.Load())
        {
            totalShotBullet = myFile.GetInt("totalShotBullet");
            totalEnemyKilled = myFile.GetInt("totalEnemyKilled");

        }
    }
    public void WinProcess()
    {
        if (enemyKilled>=5)
        {
            print("KAZANDINIZ");
        }
    }
    public void LoseProcess()
    {
        print("KAYBETTINIZ");
    }

}
