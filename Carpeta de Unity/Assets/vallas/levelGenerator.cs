using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelGenerator : MonoBehaviour {
    
    public static levelGenerator LG;
    
    public float levelSpeed;
        
    [SerializeField] int health = 5; 
    void Awake(){
        LG = this;
    }

    // Start is called before the first frame update
    void Start() {
        Invoke("Autodestruction", health);
    }

    // Update is called once per frame
    void Update() {
        transform.Translate (Vector3.forward * levelSpeed * Time.deltaTime);
    }
    
    void Autodestruction () {
        Destroy (gameObject);
    }
}
