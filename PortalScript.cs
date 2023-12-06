using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{
    public string sceneToLoad; // Nome da cena para a qual você deseja trocar
    private Transform spawnPoint; // Ponto de spawn na nova cena

    public void SetSpawnPoint(Transform newSpawnPoint)
    {
        spawnPoint = newSpawnPoint;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TeleportPlayer();
        }
    }

    void TeleportPlayer()
    {
        SceneManager.LoadScene(sceneToLoad);

        // Posicione o jogador no ponto de spawn após a cena ser carregada
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (spawnPoint != null && player != null)
        {
            player.transform.position = spawnPoint.position;
        }
        else
        {
            Debug.LogError("Ponto de spawn ou jogador não encontrado.");
        }
    }
}
