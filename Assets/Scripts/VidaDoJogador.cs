using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaDoJogador : MonoBehaviour
{
    public Slider barraDeVidaDoJogador;
    public GameObject escudoDoJogador;
    public int vidaMaximaDoJogador;
    public int vidaAtualDoJogador;
    public int vidaMaximaDoEscudo;
    public int vidaAtualDoEscudo;
    public bool temEscudo;

    // Start is called before the first frame update
    void Start()
    {
        vidaAtualDoJogador = vidaMaximaDoJogador;
        vidaAtualDoEscudo = vidaMaximaDoEscudo;

        barraDeVidaDoJogador.maxValue = vidaMaximaDoJogador;
        barraDeVidaDoJogador.value = vidaAtualDoJogador;

        escudoDoJogador.SetActive(false);
        temEscudo = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AtivarEscudo()
    {
        vidaAtualDoEscudo = vidaMaximaDoEscudo;

        escudoDoJogador.SetActive(true);
        temEscudo = true;
    }

    public void GanharVida(int vidaParaReceber) 
    {
        if (vidaAtualDoJogador + vidaParaReceber <= vidaMaximaDoJogador)
        {
            vidaAtualDoJogador += vidaParaReceber;
        }
        else 
        {
            vidaAtualDoJogador = vidaMaximaDoJogador;
        }

        barraDeVidaDoJogador.value = vidaAtualDoJogador;
    }

    public void MachucarJogador(int danoParaReceber) 
    { 
        if (temEscudo == false) 
        { 
            vidaAtualDoJogador -= danoParaReceber;
            barraDeVidaDoJogador.value = vidaAtualDoJogador;

            if (vidaAtualDoJogador <= 0)
            {
                Debug.Log("Game Over");
            }
        } 
        else 
        { 
            vidaAtualDoEscudo -= danoParaReceber;

            if (vidaAtualDoEscudo <= 0)
            {
                escudoDoJogador.SetActive(false);
                temEscudo = false;
            }
        }
    }
}
