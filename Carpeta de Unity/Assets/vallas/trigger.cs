using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    [SerializeField] GameObject mGameOver;
    [SerializeField] GameObject floor;
     private AudioSource choqueSonido;
    void Start()
    {
        choqueSonido = GetComponent<AudioSource>();
    }    
    void OnTriggerEnter(Collider coll){
        if (coll.CompareTag ("Obstacle")){
            playerController.PC.anim.SetTrigger ("lost");
            choqueSonido.Play();
            GameOver ();
        }
    }

    void GameOver(){
        levelGenerator.LG.levelSpeed = 0;
        playerController.PC.enabled = false;
        FindObjectOfType<ScoreInGame>().enabled = false;
        Invoke ("MenuGameOver", 1);

    }
    void MenuGameOver(){
        levelManager.LM.GameOver();
    }
}
