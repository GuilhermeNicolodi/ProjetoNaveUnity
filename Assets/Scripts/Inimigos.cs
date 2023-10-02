using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Inimigos : MonoBehaviour
{
    
    public GameObject laserDoInimigo;
    public Transform localDoDisparo;

    public float velocideDoInimigo;
    public float tempoMaximoEntreOsLasers;
    public float tempoAtualDosLasers;
    public bool inimigoAtirador;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovimentarInimigo();

        if (inimigoAtirador == true)
        {
            AtirarLaser();
        }
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
}