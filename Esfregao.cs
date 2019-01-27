using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esfregao : MonoBehaviour {

	private void OnTriggerEnter(Collider obj)
    {
    	if (obj.gameObject.tag == "cocozinho")
        {
            // add efeito          
            Destroy(obj.gameObject);
        }
    }
}
