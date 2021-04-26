/*Scene Loader / manager 
 Brittany blair*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneLoader : MonoBehaviour
{
    //Get the score text
    public Text Score = null;
    public int Count = 0;
    [SerializeField] int MaxScore = 0;
    public Button NextButton = null;

    //Get the winScreen
    [SerializeField] public Image WinScreen = null;
    [SerializeField] public Image LoseScreen = null;
    [SerializeField] Text FinalScore = null;

    //How many gems are present in this level?
    [SerializeField] public int GemsInLevel = 0;
    public int GemCount = 0;

    //is the game at the end
    public bool EndScreen = false;

    //public Button lv1, lv2, lv3, lv4, lv5, lv6, lv7, lv8, lv9, lv10;
    //int levelPassed;

    //Images so when the player collects a gem the gem will show up on the top right of the players screen. 
    //if they dont have a gem thats present in a level there will be an empty grey slot.
    //public Image FirstGem = null;
    //public Image SecondGem = null;
    //public Image ThirdGem = null;
    //
    //public Image GemSlot1 = null;
    //public Image GemSlot2 = null;
    //public Image GemSlot3 = null;


    // Start is called before the first frame update
    void Start()
    {
        //This part is for Level Map
        //levelPassed = PlayerPrefs.GetInt("levelPassed");
        //lv2.interactable = false;

        // if(GemsInLevel ==1)
        // {
        //     GemSlot2.IsDestroyed();
        //     GemSlot3.IsDestroyed();
        // }
        //
        // if(GemsInLevel == 2)
        // {
        //     GemSlot3.IsDestroyed();
        //
        // }
        //
        // if( GemsInLevel == 0)
        // {
        //     GemSlot1.IsDestroyed();
        //     GemSlot2.IsDestroyed();
        //     GemSlot3.IsDestroyed();
        // }

        WinScreen.gameObject.SetActive(false);
        LoseScreen.gameObject.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Controls()
    {
        SceneManager.LoadScene("Controls");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void WorldMap()
    {
        SceneManager.LoadScene("WorldMap");
    }

    public void Level1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void Level3()
    {
        SceneManager.LoadScene("Level3");
    }

    public void Level4()
    {
        SceneManager.LoadScene("Level4");
    }

    public void Level5()
    {
        SceneManager.LoadScene("Level5");
    }

    public void Level6()
    {
        SceneManager.LoadScene("Level6");
    }

    public void Level7()
    {
        SceneManager.LoadScene("Level7");
    }

    public void Level8()
    {
        SceneManager.LoadScene("Level8");
    }
    public void Level9()
    {
        SceneManager.LoadScene("Level9");
    }
    public void Level10()
    {
        SceneManager.LoadScene("Level10");
    }
    public void LevelMap()
    {
        SceneManager.LoadScene("LevelMap");
    }

    public void levelWin()
    {
        WinScreen.gameObject.SetActive(true);
        EndScreen = true;
        FinalScore.text = Score.text + "/" + MaxScore;
    }

    public void LevelLost()
    {
        LoseScreen.gameObject.SetActive(true);
    }


    public void RegularTile()
    {

        Count = Count + 50;

        string UpdateScore = "Score: " + Count;

        Score.text = UpdateScore;

    }

    public void StickyTile()
    {

        Count = Count + 100;

        string UpdateScore = "Score: " + Count;

        Score.text = UpdateScore;

    }

    public void Gem1()
    {
        GemCount++;
        //GemSlot1 = FirstGem;

        Count = Count + 200;

        string UpdateScore = "Score: " + Count;

        Score.text = UpdateScore;

    }

    public void Gem2()
    {
        GemCount++;
        //GemSlot2 = SecondGem;

        Count = Count + 300;

        string UpdateScore = "Score: " + Count;

        Score.text = UpdateScore;

    }

    public void Gem3()
    {
        GemCount++;
        //GemSlot3 = ThirdGem;

        Count = Count + 500;

        string UpdateScore = "Score: " + Count;

        Score.text = UpdateScore;

    }
    public void QuitGame()
    {
     Application.Quit();
        
    }

    //public void LevelMap()
    //{
    //    SceneManager.LoadScene("LevelMap");

    //}
}


