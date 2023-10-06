using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivadorDeInimigos : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Inimigo"))
        {
            collision.gameObject.GetComponent<Inimigos>().AtivarInimigo();
        }
    }
}
