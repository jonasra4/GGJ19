using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Gun : MonoBehaviour {

	
	public float range = 100f;
	public Camera fpsCam;

	public Text textDinheiro;
	public int dinheiro;
	
	public GameObject player;


	void Update () {
		
		if(Input.GetButtonDown("Fire1")){
			Shoot();
		}	
		textDinheiro.text = dinheiro.ToString();
	}

	void Shoot(){
		
		RaycastHit hit;
		
		if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) {
			
			GameObject box = hit.transform.gameObject; // salva referencia do pai (box)

			if(hit.transform.tag == "box"){
				GameObject ChildGameObject0 = hit.transform.GetChild(0).gameObject; 
				 
				ChildGameObject0.transform.parent= null;
				Destroy(box);
				ChildGameObject0.GetComponent<ParticleSystem>().Play();
			}

			Item itemComprado = hit.collider.GetComponent<Item>();

			if( itemComprado && itemComprado.preco <= dinheiro){

				dinheiro -= itemComprado.preco;
      			Instantiate(itemComprado.itemPrefab, new Vector3(player.transform.position.x, 
      															 player.transform.position.y, // o valor pode variar depedendo de como o personage estaconfigurado
      															 player.transform.position.z-5), Quaternion.identity);

			}
		}
	

	}
}
