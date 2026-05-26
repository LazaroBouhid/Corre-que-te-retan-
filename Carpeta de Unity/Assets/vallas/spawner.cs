using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {

    [SerializeField] float timeToSpawn = 1.0f;

    public GameObject[] obsPref;

    public int r;

    // Start is called before the first frame update
    void Start()
    {
        Spawn ();
    }

    void Spawn(){
        r = Random.Range (0, obsPref.Length);
        Instantiate(obsPref [r], transform.position, transform.rotation);
        Invoke ("Spawn", timeToSpawn);
    }

}
