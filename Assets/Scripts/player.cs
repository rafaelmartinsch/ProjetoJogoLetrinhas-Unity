using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	public float velocidade;

	//animaçoes
	public Transform playerPersonagem;
	private Animator animator;

	//responsavel por pular
	public bool estanoChao;//isground
	public float forca;//force
	public float tempodePulo= 0.4f;//(junptime)sao quatro imagem entao 0.4 esse tempo ja esta definido no animation 
	public float tempodeAnimacao= 0.4f;//junpdelay
	public bool estaPulando;//junped
	public Transform chao;//(ground)usarei no game object


	void Start () {
		animator = playerPersonagem.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		Movimentar ();
	}

	void Movimentar(){

		//para vereficar quando ele esta no chao;
		estanoChao = Physics2D.Linecast (this.transform.position, chao.position, 1 <<LayerMask.NameToLayer("Plataforma"));

		//chamar prmeira animaçao 
		animator.SetFloat ("run", Mathf.Abs(Input.GetAxis("Horizontal")));


		if(Input.GetAxisRaw("Horizontal")>0){// variavel ja implmrntada que pega a posiçao horizontal
			transform.Translate(Vector2.right * velocidade * Time.deltaTime); //x,y, delta time padroniza para todos os computadores 
			transform.eulerAngles = new Vector2(0,0);//x,y inverte no eixo y 
		}
		if(Input.GetAxisRaw("Horizontal")<0){// variavel ja implmrntada que pega a posiçao horizontal
			transform.Translate(Vector2.right * velocidade * Time.deltaTime); //-x,y, delta time padroniza para todos os computadores 
			transform.eulerAngles = new Vector2(0,180); //vira o personagem(inverte a imagem) quando ele andar para a direita
		}


		if (Input.GetButtonDown ("Jump") && estanoChao && !estaPulando) { //açao ao pressionar o botao, TBM PODE USAR GetKeyDown ("w") E Input.GetAxisRaw("Vertical")>0) PARA A SETA PARA CIMA
			GetComponent<Rigidbody2D>().AddForce(transform.up * forca);
			tempodePulo = tempodeAnimacao;
			animator.SetTrigger("jump");
			estaPulando=true;
		}



		tempodePulo -= Time.deltaTime;

		if(tempodePulo <=0 && estanoChao && estaPulando){
			animator.SetTrigger("chao");
			estaPulando = false;
		}


	}
}
