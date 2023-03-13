using UnityEngine;
using System.Collections;

public class instanciador : MonoBehaviour {

	public GameObject[] objetos;

	private bool Esquerda = true;
	public float velocidade = 3f;
	public float tempodeLocomocao;

	public float instanciadorTempo = 5f;
	public float instanciadorDelay = 3f;

	private float timeMovimento = 0f;
	
	private int valoMinRondom = 0;

	void Start () {
		InvokeRepeating ("Spawn", instanciadorTempo, instanciadorDelay);
	}
	
	// Update is called once per frame
	void Update () {
		Movimentar ();
	}

	void Spawn(){
		int index = Random.Range (valoMinRondom, objetos.Length);
		Instantiate (objetos[index], transform.position, objetos[index].transform.rotation);
	}

	void Movimentar(){

		timeMovimento += Time.deltaTime;

		if (timeMovimento <= tempodeLocomocao) {
			if (Esquerda) {
					transform.Translate (-Vector2.right * velocidade * Time.deltaTime);
					transform.eulerAngles = new Vector2 (0, 0);
			} else {
					transform.Translate (-Vector2.right * velocidade * Time.deltaTime);
					transform.eulerAngles = new Vector2 (0, 180);
			}
		} else {
			Esquerda =  !Esquerda;
			timeMovimento=0;
		}

	}

}
