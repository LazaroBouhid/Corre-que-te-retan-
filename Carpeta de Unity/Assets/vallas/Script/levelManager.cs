using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelManager : MonoBehaviour
{
        public static levelManager LM;

        [SerializeField] GameObject mGameOver;
    // Start is called before the first frame update
    void Start()
    {
        LM = this;
        mGameOver.SetActive (false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOver(){
        Time.timeScale = 0; //ESTO HAY QUE CAMBIAR
        mGameOver.SetActive(true);
    }

    public void Restart(){
        Application.LoadLevel(1);
        mGameOver.SetActive(false);
        Time.timeScale = 1;
    }
    public void Menu(){
        Application.LoadLevel(0);
        mGameOver.SetActive(false);
        Time.timeScale = 1;
    }
}
