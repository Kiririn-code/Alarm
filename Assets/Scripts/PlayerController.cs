using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]

public class PlayerController : MonoBehaviour
{
    private Transform _transform;
    private SpriteRenderer _sprite;
    private Animator _animator;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _sprite = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        _animator.SetBool("IsRun", false);
        if (Input.GetKey(KeyCode.D))
        {
            _transform.Translate(new Vector3(2 * Time.deltaTime, 0, 0));
            _animator.SetBool("IsRun", true);
            _sprite.flipX = false;

        }
        if (Input.GetKey(KeyCode.A))
        {
            _transform.Translate(new Vector3(-2 * Time.deltaTime, 0, 0));
            _animator.SetBool("IsRun", true);
            _sprite.flipX = true;
        }
        if (Input.GetKey(KeyCode.E))
        {
            _animator.SetTrigger("Attack");
        }
    }
}
