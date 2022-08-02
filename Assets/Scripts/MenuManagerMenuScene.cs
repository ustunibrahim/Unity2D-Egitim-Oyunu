using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuManagerMenuScene : MonoBehaviour
{
    public GameObject dataBoard;
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
    public void PlayButton()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void DataBoardButton()
    {
        DataManager.Instance.LoadData();
        dataBoard.transform.GetChild(1).GetComponent<Text>().text = DataManager.Instance.totalShotBullet.ToString();
        dataBoard.transform.GetChild(2).GetComponent<Text>().text = DataManager.Instance.totalEnemyKilled.ToString();
        dataBoard.SetActive(true);
    }
    public void xButton()
    {
        dataBoard.SetActive(false);
    }
}
