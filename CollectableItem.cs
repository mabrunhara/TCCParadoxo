using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollectableItem : MonoBehaviour
{
   
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Adicione qualquer l�gica necess�ria para a coleta do item

            // Chama o m�todo CollectItem do QuestManager
            QuestManager.Instance.CollectItem();

            // Destroi o objeto do item colet�vel
            Destroy(gameObject);
        }
    }
}
