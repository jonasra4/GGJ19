using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Gun : MonoBehaviour {

	
	public float range = 100f;
	public Camera fpsCam;

	public Text textDinheiro;
	public int dinheiro = 950;
	
	public GameObject player;



	private string itemAtual;//item que foi selecionado

	void Update () {
		
		if(Input.GetButtonDown("Fire1")){
			Shoot();
		}	
		textDinheiro.text = dinheiro.ToString();
	}

	void Shoot(){
		
		RaycastHit hit;
		
		if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) {
		
			GameObject box = hit.transform.gameObject;

			if(hit.transform.tag == "box"){
				GameObject ChildGameObject0 = hit.transform.GetChild(0).gameObject; 
				ChildGameObject0.transform.parent= null;
				Destroy(box);
			}

			Item itemComprado = hit.collider.GetComponent<Item>();

			if(itemComprado.preco <= dinheiro){

				dinheiro -= itemComprado.preco;
      			Instantiate(itemComprado.itemPrefab, new Vector3(player.transform.position.x, 
      															 player.transform.position.y, 
      															 player.transform.position.z-5), Quaternion.identity);

			}
		}
	

	}
}
