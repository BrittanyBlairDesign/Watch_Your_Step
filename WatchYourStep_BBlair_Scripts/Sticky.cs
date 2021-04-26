/*Sticky Tile Script 
 Brittany Blair*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticky : MonoBehaviour
{
    //Killspot spawn
    [SerializeField] private GameObject thisDeath = null;

    //Step count
    [SerializeField] private int thisStepCount = 2;

    //hasbeenStepped on
    private bool Stepped = false;

    //thisSpawntimer
    [SerializeField] public float thisSpawnTimer = .5f;

    //Scene mangager for score updates
    private GameObject thisManager = null;
    private SceneLoader thisSceneLoader = null;

    //Called at the beginning of the scene
    protected void Start()
    {
        thisManager = GameObject.FindGameObjectWithTag("Manager");
        thisSceneLoader = thisManager.GetComponent<SceneLoader>();
    }

    private void Update()
    {
        if (Stepped)
        {
            // if no hit points were left, then after the timer spawn a collision box to avoid backtracking.
            if (thisSpawnTimer > 0)
            {
                thisSpawnTimer -= Time.deltaTime;
            }
            else
            {
                Instantiate(thisDeath, this.transform.position, Quaternion.identity);
                this.gameObject.SetActive(false);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject aOtherObject = collision.gameObject;

        Movement aMovement;
        aMovement = aOtherObject.GetComponent<Movement>();

        if (aMovement != null)
        {
            //Snap position of the player to the center of the sticky block
            Vector3 aDirection = aMovement.LastDirection;
            aMovement.thisDirection = aDirection;

            //reduce the tile's hit count
            thisStepCount--;

            //Update the score
            thisSceneLoader.StickyTile();

            //check if the tile has other hit points
            if (thisStepCount <= 0)
            {
                Stepped = true;
            }

        }
    }
}
