using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoBoo : MonoBehaviour
{
    [Header("Verificação do Andar")]
    private bool podeAndar;
    private VerificarDirecaoDoMovimentoDoJogador oVerificarDirecaoDoMovimentoDoJogador;

    [Header("Movimento do Inimigo")]
    [SerializeField] private float velocidadeDoInimigo;
    [SerializeField] private bool indoParaDireita;
    private GameObject oJogador;

    private void Awake()
    {
        oJogador = GameObject.FindGameObjectWithTag("Player");
        oVerificarDirecaoDoMovimentoDoJogador = oJogador.GetComponent<VerificarDirecaoDoMovimentoDoJogador>();
    }

    private void Start()
    {
        podeAndar = true;
    }

    private void Update()
    {
        VerificarSePodeAndar();
        SeguirJogador();
        EspelharNaHorizontal();
    }

    private void VerificarSePodeAndar()
    {
        if (indoParaDireita)
        {
            if (oVerificarDirecaoDoMovimentoDoJogador.indoParaDireita)
            {
                podeAndar = true;
            }
            else
            {
                podeAndar = false;
            }
        }
        else
        {
            if (oVerificarDirecaoDoMovimentoDoJogador.indoParaDireita)
            {
                podeAndar = false;
            }
            else
            {
                podeAndar = true;
            }
        }
    }

    private void SeguirJogador()
    {
        if (podeAndar)
        {
            transform.position = Vector2.MoveTowards(transform.position, oJogador.transform.position, velocidadeDoInimigo * Time.deltaTime);
        }
    }

    private void EspelharNaHorizontal()
    {
        if (oJogador.transform.position.x > transform.position.x)
        {
            indoParaDireita = true;
            transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
        }
        else
        {
            indoParaDireita = false;
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
    }
}
