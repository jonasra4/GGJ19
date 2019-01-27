using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatGenerator : MonoBehaviour {


	public GameObject cat;
 	
	void Start()
    {
        InvokeRepeating("SpawCat", 1.0f, 1.0f);
    }

    void SpawCat()
    {	
    	Vector3 position = new Vector3(Random.Range(-3.0f, 3.0f), 2.3F, Random.Range(-3.0f, 3.0f));
      	Instantiate(cat, new Vector3(position.x,position.y,position.z), Quaternion.identity);
    }
}
