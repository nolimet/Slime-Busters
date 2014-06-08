﻿using UnityEngine;
using System.Collections;

public class HammerControler
{
    private Transform creator;
    private GameObject hammer;
    private Animator animator;
    private RuntimeAnimatorController controler;
    public HammerControler(Transform _creator,RuntimeAnimatorController _controler)
    {
        creator = _creator;
        controler = _controler;
    }

    public void SetControler(RuntimeAnimatorController _controler)
    {
        controler = _controler;
    }
    
    public void Tick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hammer = new GameObject("hammer");
            hammer.AddComponent<SpriteRenderer>();
            animator = hammer.AddComponent<Animator>();
            animator.runtimeAnimatorController = controler;
            animator.SetTrigger("hit");
            Vector3 inputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hammer.transform.position = new Vector3(inputPos.x,inputPos.y,hammer.transform.position.z);
        }
    }
}
