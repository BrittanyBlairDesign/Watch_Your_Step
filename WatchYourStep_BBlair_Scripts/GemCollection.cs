using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GemCollection : MonoBehaviour
{
    //Scene manager variables
    private GameObject thisManager = null;
    private SceneLoader thisSceneLoader = null;

    //SFX
    GameObject LevelSFX;
    SoundEffects Effectplay;

    //Bools to determine the worth of this gem
    [SerializeField] private bool thisGem1 = false;
    [SerializeField] private bool thisGem2 = false;
    [SerializeField] private bool thisGem3 = false;

    //Start of the game
    protected void Start()
    {
        // find the scene manager and get their scene loader script
        thisManager = GameObject.FindGameObjectWithTag("Manager");
        thisSceneLoader = thisManager.GetComponent<SceneLoader>();

        LevelSFX = GameObject.FindGameObjectWithTag("Sounds");
        Effectplay = LevelSFX.GetComponent<SoundEffects>(); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject aOtherObject = collision.gameObject;

        //check for the Movement script attached to the character
        Movement aMovement;
        aMovement = aOtherObject.GetComponent<Movement>();

        if(aMovement != null)
        {
            // find out what kind of gem this is, then add that gems worth to the score
            // before deactivating the gem.
             if (thisGem1)
             {
                Effectplay.PlayGem1();
                thisSceneLoader.Gem1();
                this.gameObject.SetActive(false);
             }
             else
             if (thisGem2)
             {
                Effectplay.PlayGem2();
                thisSceneLoader.Gem2();
                this.gameObject.SetActive(false);
             }
             else
             if (thisGem3)
             {
                Effectplay.PlayGem3();
                thisSceneLoader.Gem3();
                this.gameObject.SetActive(false);
             }
        }
    }
}
