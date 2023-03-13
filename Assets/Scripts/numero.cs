using UnityEngine;
using System.Collections;

public class numero : MonoBehaviour {

	public AudioClip clip;
	private float timeVida;
	public  float tempoMaxVida;


	void Start () {
		timeVida = 0;
	}
	
	// Update is called once per frame
	void Update () {

		timeVida += Time.deltaTime;//o objeto e excluso apos um tempo de vida
		if (timeVida >= tempoMaxVida) {
			Destroy(gameObject);
			timeVida = 0;
		}

	}

	void OnCollisionEnter2D(Collision2D colisor){
		if (colisor.gameObject.tag == "Player") { //qundo o collisor colidir com o player(tag do personagem)
			Destroy(gameObject);//destri o colisor
		}

	}

}
