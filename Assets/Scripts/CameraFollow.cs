using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // Refer�ncia ao transform do jogador
    public Vector3 offset;    // Dist�ncia entre a c�mera e o jogador

    void Update()
    {
        if (player != null)
        {
            // Atualiza a posi��o da c�mera com base na posi��o do jogador
            transform.position = player.position + offset;
        }
    }
}
