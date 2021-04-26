using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class flamethrowerScript : MonoBehaviour

{
    public float timer;
    public float timerBetweenRestart;
    public float anticipation;
    public BoxCollider2D flameCollider;
    public GameObject fire;


    //Find the scene loader
    GameObject Manager;
    SceneLoader thisLoader;

    // Start is called before the first frame update
    void Start()
    {
        flameCollider = GetComponent<BoxCollider2D>();
        StartCoroutine(flameDelay());

        //Get the Manager from the scene

        Manager = GameObject.FindGameObjectWithTag("Manager");
        thisLoader = Manager.GetComponent<SceneLoader>();
    }

    // Update is called once per frame
    void Update()


    {
        
    }

    IEnumerator flameDelay()
    {
        fire.SetActive(true);
        yield return new WaitForSeconds(anticipation);
        flameCollider.enabled = true;
        
        yield return new WaitForSeconds(timer);
        flameCollider.enabled = false;
        fire.SetActive(false);
        yield return new WaitForSeconds(timerBetweenRestart);
        StartCoroutine(flameDelay());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Death();
        }

    }

    void Death()
    {
        thisLoader.LevelLost();      
    }
}
