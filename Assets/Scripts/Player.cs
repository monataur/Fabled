using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    PlayerControls ctrl;
    Animator ani;
    public float num;
    public Enums.CharacterType chr;
    public string currentState;
    public Vector2 move;
    public Rigidbody2D rb;
    public Enums.MoveDirection dir;
    public GameObject partyobj;
    public Enums.PartyStatus status;
    private void Awake()
    {
        ctrl = new PlayerControls();
        ctrl.Map.Movement.performed += ctx => move = (ctx.ReadValue<Vector2>());
        ctrl.Map.Movement.canceled += ctx => move = (ctx.ReadValue<Vector2>());
    }
    private void OnEnable()
    {
        ctrl.Enable();
    }
    private void OnDisable()
    {
        ctrl.Disable();
    }
    private void Start()
    {
        ani = GetComponent<Animator>();
        StartCoroutine(DelayInput(num));
    }
    void Update()
    {
        status = partyobj.GetComponent<Party>().status;

        switch(chr)
        {
            case Enums.CharacterType.Player:
                break;

            case Enums.CharacterType.NPC:
                var party1 = GameObject.Find("Party1");
                var neg = new Vector3(party1.transform.position.x - 1, party1.transform.position.y - 1, party1.transform.position.z - 1);
                gameObject.transform.position = Vector3.MoveTowards(transform.position, party1.transform.position - neg, 0.5f);
                break;
        }
        if(status == Enums.PartyStatus.Map)
        {
            if (move == Vector2.zero)
            {
                dir = Enums.MoveDirection.None;
            }
            else if (move == Vector2.left)
            {
                dir = Enums.MoveDirection.Left;
            }
            else if (move == Vector2.right)
            {
                dir = Enums.MoveDirection.Right;
            }
            else if (move == Vector2.up)
            {
                dir = Enums.MoveDirection.Up;
            }
            else if (move == Vector2.down)
            {
                dir = Enums.MoveDirection.Down;
            }

            switch (dir)
            {
                case Enums.MoveDirection.None:
                    ani.StartPlayback();
                    break;

                case Enums.MoveDirection.Up:
                    ChangeAnimationState("WalkW");
                    ani.StopPlayback();
                    break;

                case Enums.MoveDirection.Down:
                    ChangeAnimationState("WalkS");
                    ani.StopPlayback();
                    break;

                case Enums.MoveDirection.Right:
                    ChangeAnimationState("WalkD");
                    ani.StopPlayback();
                    break;

                case Enums.MoveDirection.Left:
                    ChangeAnimationState("WalkA");
                    ani.StopPlayback();
                    break;
            }
        }
    }

    void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        ani.Play(newState);

        currentState = newState;
    }

    IEnumerator DelayInput(float del)
    {
        yield return new WaitForSeconds(del);
        if(status == Enums.PartyStatus.Map)
        {
            rb.AddForce(move);
        }
        StartCoroutine(DelayInput(num));
    }
}