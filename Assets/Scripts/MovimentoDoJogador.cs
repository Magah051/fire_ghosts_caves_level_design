using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoDoJogador : MonoBehaviour
{
    [Header("Referências Gerais")]
    private Rigidbody2D oRigidbody2D;

    [Header("Movimento Horizontal")]
    [SerializeField] private float velocidadeHorizontal;
    private float inputHorizontal;
    private bool indoParaDireita;

    public Animator playerAnimator;
    bool isWalking = false;

    [Header("Pulo")]
    [SerializeField] private float alturaDoPulo;
    [SerializeField] private float tamanhoDoRaioDeVerificacaoDeChao;
    [SerializeField] private Transform verificadorDeChao;
    [SerializeField] private LayerMask layersDoChao;
    private bool estaNoChao;
    private bool podePular;

    private void Awake()
    {
        oRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        indoParaDireita = true;
    }

    private void Update()
    {
        VerificarAmbiente();
        VerificarSePodePular();
        ReceberInputs();
        VerificarDirecaoDoMovimento();
        EspelharNaHorizontal();
    }

    private void FixedUpdate()
    {
        AplicarMovimento();
    }

    private void VerificarAmbiente()
    {
        estaNoChao = Physics2D.OverlapCircle(verificadorDeChao.position, tamanhoDoRaioDeVerificacaoDeChao, layersDoChao);
    }

    private void VerificarSePodePular()
    {
        if (estaNoChao)
        {
            podePular = true;
        }
        else
        {
            podePular = false;
        }
    }

    private void ReceberInputs()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        isWalking = (inputHorizontal != 0);

        if (isWalking)
        {
            playerAnimator.SetBool("isWalking", true);
        }
        else
        {
            playerAnimator.SetBool("isWalking", false);
        }

        if (Input.GetButtonDown("Jump"))
        {
            Pular();
        }
    }

    private void VerificarDirecaoDoMovimento()
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

    private void EspelharNaHorizontal()
    {
        if (indoParaDireita)
        {
            transform.localScale = new Vector3(6.5f, 6.5f, 6.5f);
        }
        else
        {
            transform.localScale = new Vector3(-6.5f, 6.5f, 6.5f);
        }
    }

    private void AplicarMovimento()
    {
        oRigidbody2D.velocity = new Vector2(inputHorizontal * velocidadeHorizontal, oRigidbody2D.velocity.y);
    }

    private void Pular()
    {
        if (podePular)
        {
            oRigidbody2D.velocity = new Vector2(oRigidbody2D.velocity.x, alturaDoPulo);
        }
    }
}