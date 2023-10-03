using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItensColetaveis : MonoBehaviour
{
    public bool itemDeEscudo;
    public bool itemDeLaserDuplo;
    public bool itemDeVida;

    public int vidaParaDar;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (itemDeEscudo == true)
            {
                collision.gameObject.GetComponent<VidaDoJogador>().AtivarEscudo();
            }
            
            if (itemDeLaserDuplo == true) 
            {
                collision.gameObject.GetComponent<ControleDoJogador>().temLaserDuplo = false;
                collision.gameObject.GetComponent<ControleDoJogador>().tempoAtualDosLasersDuplos = collision.gameObject.GetComponent<ControleDoJogador>().tempoMaximoDosLasersDuplos;
                collision.gameObject.GetComponent<ControleDoJogador>().temLaserDuplo = true;
            }

            if (itemDeVida == true) 
            {
                collision.gameObject.GetComponent<VidaDoJogador>().GanharVida(vidaParaDar);
            }

            Destroy(this.gameObject);
        }
    }

}
