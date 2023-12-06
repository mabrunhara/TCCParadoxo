using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollectableItem : MonoBehaviour
{
   
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Adicione qualquer lógica necessária para a coleta do item

            // Chama o método CollectItem do QuestManager
            QuestManager.Instance.CollectItem();

            // Destroi o objeto do item coletável
            Destroy(gameObject);
        }
    }
}
