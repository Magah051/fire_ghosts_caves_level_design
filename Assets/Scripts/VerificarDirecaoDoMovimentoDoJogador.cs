using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerificarDirecaoDoMovimentoDoJogador : MonoBehaviour
{
    private float inputHorizontal;
    public bool indoParaDireita;

    private void Start()
    {
        indoParaDireita = true;
    }

    private void Update()
    {
        ReceberInputs();
        VerificarDirecaoDoInput();
    }

    private void ReceberInputs()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
    }

    private void VerificarDirecaoDoInput()
    {
        if (inputHorizontal > 0)
        {
            indoParaDireita = true;
        }
        else if (inputHorizontal < 0)
        {
            indoParaDireita = false;
        }
    }
}
