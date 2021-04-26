/*Destructable tile Script
 Brittany Blair*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Destructable : MonoBehaviour
{
    //This is for LevelMap

    public string nextLevel = null;
    public int levelToUnlock = 0;

    
    
    //Killspot spawn
    [SerializeField] private GameObject thisDeath = null;

    //Step count
    [SerializeField] private int thisStepCount = 2;

    //was it stepped on?
    private bool Stepped = false;
    //Timer
    [SerializeField] private float thisSpawnTimer = .01f;

    //Sprite renderer to change sprite if tile can be hit multiple times
    [SerializeField] private SpriteRenderer thisSR = null;
    [SerializeField] private Sprite TwoHits = null;
    [SerializeField] private Sprite oneHit = null;
    [SerializeField] private Sprite EndTile = null;
    [SerializeField] private Sprite[] OneHitSprites = null;
    [SerializeField] private Sprite[] TwoHitSprites = null;

    //Scenemanager to update the score
    private GameObject thisManager = null;
    private SceneLoader thisSceneLoader = null;

    // IS this tile the Final level tile?
    [SerializeField] private bool FinalTile = false;

    private void Awake()
    {
        int m = PlayerPrefs.GetInt("LevelPlaying");
        if (m <= 1)
        {
            PlayerPrefs.SetInt("LevelPlaying", 1);
        }
        else if (m >= 8)
        {
            PlayerPrefs.SetInt("LevelPlaying", 1);
        }

       // 

    }

    // Start is called before the first frame update
    private void Start()
    {
        //Level Count
       

        PlayerPrefs.SetInt("LevelPlaying", levelToUnlock - 1);
        //End level count

        int SpriteCount = TwoHitSprites.Length;
        int RandomSprite = Random.Range(0, SpriteCount);

        //check and see if this tile has multiple hit points
        if (thisStepCount == 2)
        {

            TwoHits = TwoHitSprites[RandomSprite];
            thisSR.sprite = TwoHits;
        }
        
        if(thisStepCount == 1)
        {
            oneHit = OneHitSprites[RandomSprite];
            thisSR.sprite = oneHit;
        }

        oneHit = OneHitSprites[RandomSprite];

        if (FinalTile)
        {
            thisSR.sprite = EndTile;
        }



        // find the scene manager and get the scene loader script saved in a var.
        thisManager = GameObject.FindGameObjectWithTag("Manager");
        thisSceneLoader = thisManager.GetComponent<SceneLoader>();
    }

    //Update
    private void Update()
    {
        if (Stepped)
        {
            // if there are no more hit points left then, after the timer spawn a collisoin box to avoid back tracking and destroy self.
            if (thisSpawnTimer > 0)
            {
                thisSpawnTimer -= Time.deltaTime;
            }
            else
            {
                if (FinalTile)
                {
                 
                    thisSceneLoader.levelWin();
                    Debug.Log("Won");


                    //access to level control for next level
                    LevelMapWin();

                }
                else
                {
                    Instantiate(thisDeath, this.transform.position, Quaternion.identity);
                    this.gameObject.SetActive(false);
                }

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject aOtherObject = collision.gameObject;

        //check for the movement script that is on the character prefab
        Movement aMovement;
        aMovement = aOtherObject.GetComponent<Movement>();


        if (aMovement != null)
        {
            // If this tile is the last tile in the game than trigger the win screen.
            // otherwise do nothing.
            if (FinalTile)
            {
                thisSceneLoader.RegularTile();
                Stepped = true;
                //LevelMapWin();
                

            }
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject aOtherObject = collision.gameObject;

        //check for the movement script that is on the character prefab
        Movement aMovement;
        aMovement = aOtherObject.GetComponent<Movement>();


        if (aMovement != null)
        {
            // update the steped on counter
            thisStepCount--;

            // update the scene's score 
            thisSceneLoader.RegularTile();

            //set the sprite to one hit
            thisSR.sprite = oneHit;

            // check and see if there are any hitpoints left
            if (thisStepCount <= 0)
            {
                Stepped = true;

            }

        }
    }
    //Update level has reached
        private void LevelMapWin()
        {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        Debug.Log("levelReached");
        gameObject.GetComponent<StartLevelMap>().FirstTimeCall = false;
    }


}
