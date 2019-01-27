using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class esfrega : MonoBehaviour {

	private bool clean;
	private Vector3 lastInstance;
	// Use this for initialization
	void Start () {
		this.clean = true;
	}

	void limparEsfregao(){
		this.clean = true;
	}

	void sujarEsfregao(){
		this.clean = false;
	}

	void addCoco(GameObject coco, Vector3 posicao){
        Instantiate(coco, new Vector3(	posicao.x+3, 
        								posicao.y, 
        								posicao.z+3), 
        								Quaternion.identity);
	}

	private void OnTriggerEnter(Collider obj)
    {
    	GameObject coco_atual = obj.gameObject;
		Vector3 posicao_coco = coco_atual.transform.position;

    	if (coco_atual.tag == "cocozinho" && clean == true)
        {
            Destroy(coco_atual);
           	sujarEsfregao();
        }
        else if(coco_atual.tag == "cocozinho" && clean == false){
        	addCoco(coco_atual, posicao_coco); 
	    }
        else if(coco_atual.name == "balde"){
        	limparEsfregao();
        }
    }
}