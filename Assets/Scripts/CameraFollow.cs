using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // Referência ao transform do jogador
    public Vector3 offset;    // Distância entre a câmera e o jogador

    void Update()
    {
        if (player != null)
        {
            // Atualiza a posição da câmera com base na posição do jogador
            transform.position = player.position + offset;
        }
    }
}
