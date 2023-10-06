using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Inimigos : MonoBehaviour
{
    public GameObject laserDoInimigo;
    public Transform localDoDisparo;
    public GameObject itemParaDropar;
    public GameObject efeitoDeExplosao;

    public float velocideDoInimigo;
    public float tempoMaximoEntreOsLasers;
    public float tempoAtualDosLasers;
    public int chanceParaDropar;
    public int danoDaNave;

    public int vidaMaximaDoInimigo;
    public int vidaAtualDoInimigo;
    public int pontosParaDar;

    public bool inimigoAtirador;
    public bool inimigoAtivado;

    // Start is called before the first frame update
    void Start()
    {
        inimigoAtivado = false;
        vidaAtualDoInimigo = vidaMaximaDoInimigo;
    }

    // Update is called once per frame
    void Update()
    {
        MovimentarInimigo();

        if (inimigoAtirador == true && inimigoAtivado == true)
        {
            AtirarLaser();
        }
    }

    public void AtivarInimigo()
    {
        inimigoAtivado = true;
    }

    private void MovimentarInimigo()
    {
        transform.Translate(Vector3.down * velocideDoInimigo * Time.deltaTime);
    }

    private void AtirarLaser()
    {
        tempoAtualDosLasers -= Time.deltaTime;

        if (tempoAtualDosLasers <= 0)
        {
            Instantiate(laserDoInimigo, localDoDisparo.position, Quaternion.Euler(0f, 0f, 90f));
            tempoAtualDosLasers = tempoMaximoEntreOsLasers;
        }
    }

    public void MachucarInimigo(int danoParaReceber)
    {
        vidaAtualDoInimigo -= danoParaReceber;

        if (vidaAtualDoInimigo <= 0)
        {
            GameManager.instance.AumentarPontuacao(pontosParaDar);
            Instantiate(efeitoDeExplosao, transform.position, transform.rotation);

            int numeroAleatorio = Random.Range(0, 100);
            if (numeroAleatorio <= chanceParaDropar)
            {
                Instantiate(itemParaDropar, transform.position, Quaternion.Euler(0f, 0f, 0f));
            }

            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<VidaDoJogador>().MachucarJogador(danoDaNave);
            Instantiate(efeitoDeExplosao, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
