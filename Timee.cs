using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timee : MonoBehaviour {


    private float timer = 0.0f; // tempo de tentavas de spawn
    private float timer2 = 0.0f; // tempo que nao deve ser spawnado

    private float visualTime = 0.0f;
    private int width, height;
    private float value = 10.0f;
    private float scrollBar = 1.0f;


	private float waitTime = 5f; // 5 segundos
   	private bool isSpaw = false;
   	public float timeNoSpawn = 90.0f;

   	[Range(0,1.0f)]
    public float chanceSpawn = 0.3f;
    
    public GameObject cat;
    
    void Awake()
    {
        //width = Screen.width;
        //height = Screen.height;
        Time.timeScale = scrollBar;
    }

	
	void Update()
    {
        timer += Time.deltaTime;
       	timer2 += Time.deltaTime;

        // Check if we have reached beyond 2 seconds.
        // Subtracting two is more accurate over time than resetting to zero.
        
        if(timer2 > timeNoSpawn ){ 
        	isSpaw = false;
        }


        if (timer > waitTime && !isSpaw) // A cada X segundos tenta criar um gato
        {       		
       		float trySpaw = Random.Range(0, 1.0f);

       		if (trySpaw >= chanceSpawn){
        		SpawCat();
        		isSpaw = true;
        		timer2 = 0;
       		}

            visualTime = timer;

            // Remove the recorded 2 seconds.
            timer = timer - waitTime;
            Time.timeScale = scrollBar;
        }
    }

    void SpawCat()
    {	
    	Vector3 position = new Vector3(Random.Range(-2.0f, 2.0f), 2.3F, Random.Range(-2.0f, 2.0f));
      	Instantiate(cat, new Vector3(position.x,position.y,position.z), Quaternion.identity);
    }
}
