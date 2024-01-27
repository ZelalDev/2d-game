using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 1.0f;
    public Rigidbody2D r2d;
    public Animator _animator;
    private Vector3 charpos;
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private GameObject _camera;
    private int sayi;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        r2d = GetComponent<Rigidbody2D>(); // chaching r2d
        _animator = GetComponent<Animator>(); // chasing Anim
        charpos = transform.position;
        sayi = 1;
    }

    private void FixedUpdate() // 50 fps
    {
        Debug.Log("Fixed" + sayi);
        //r2d.velocity = new Vector2(speed, 0f);
        sayi = 2;
    }

    void Update() // per frame
    {
        charpos = new Vector3(charpos.x + (Input.GetAxis("Horizontal") * speed * (Time.deltaTime)), charpos.y);
        transform.position = charpos; // hesapladığım pozisyon karakterime işlensin
        if (Input.GetAxis("Horizontal") == 0.0f)
        {
            _animator.SetFloat("speed", 0.0f);
        }
        else
        {
            _animator.SetFloat("speed", 1.0f);
        }

        if (Input.GetAxis("Horizontal") > 0.01f)
        {
            _spriteRenderer.flipX = false;
        }
        else if (Input.GetAxis("Horizontal") < -0.01f)
        {
            _spriteRenderer.flipX = true;
        }
        
        sayi = 3;
    }

    private void LateUpdate()
    {
        //_camera.transform.position = new Vector3(charpos.x, charpos.y, charpos.z - 1.0f); 
        sayi = 4;
    }
}
