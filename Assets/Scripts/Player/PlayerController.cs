using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct ActionData
{
    public float time;
    public string key;
}
public class PlayerController : MonoBehaviour
{
    // chua fix clear bong khi du so luong
    public static Action<float> EvenCurTime;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private PlayerControlData playerControlData;
    [SerializeField] private GameObject playerPrefab;

    private Rigidbody2D rd;
    private Animator animator;
    [SerializeField] private int angle;
    private float distance;
    private float rayLength;
    private LayerMask groundLayer;
    [SerializeField] private float timeSpawnShadow;

    // Key di chuyen
    private KeyCode keyA;
    private KeyCode keyS;
    private KeyCode keyW;
    private KeyCode keyD;
    // Key chieu
    private KeyCode keyU;
    private KeyCode keyI;
    private KeyCode keyO;
    private KeyCode keyP;

    private KeyCode keySpace;

    private bool isRun;
    private bool isGround;
    private SpriteRenderer spriteRenderer;
    private Color colorSprite;

    [SerializeField] private bool isPlayer;

    private bool beforeJump;
    private bool isDie;

    private AudioSource audio;
    public List<AudioClip> clipList;

    private void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();
        colorSprite = spriteRenderer.color;
        colorSprite.a = 0.8f;
        GetKeyControl();
        distance = playerData.distance;
        rayLength = playerData.rayLength;
        groundLayer = playerData.groundLayer;
        timeSpawnShadow = playerData.timeSpawnShadow;
        angle = 1;
        isPlayer = true;
        isRun = false;
        beforeJump = false;
        isDie = false;
    }

    private void GetKeyControl()
    {
        keyA = playerControlData.keyA;
        keyS = playerControlData.keyS;
        keyW = playerControlData.keyW;
        keyD = playerControlData.keyD;
        keyU = playerControlData.keyU;
        keyI = playerControlData.keyI;
        keyO = playerControlData.keyO;
        keyP = playerControlData.keyP;
        keySpace = playerControlData.keySpace;
    }

    private void Update()
    {
        if (isPlayer)
        {
            if (!isDie)
            {
                ControllPlayer();
            }
        }
        else
        {
            spriteRenderer.color = colorSprite;
            animator.enabled = false;
        }
        if (beforeJump == false)
        {
            if (isGround)
            {
                animator.SetBool("jump", false);
            }
        }
        if (isGround)
        {
            beforeJump = true;
        }
        else
        {
            beforeJump = false;
        }
    }

    private void ControllPlayer()
    {
        if (Input.GetKey(keyA))
        {
            PressKeyA();
        }
        if (Input.GetKey(keyD))
        {
            PressKeyD();
        }
        if (Input.GetKeyDown(keyW))
        {
            PressKeyW();
        }
        if (Input.GetKeyDown(keyU))
        {
            Gameplay.dungchieu += DungChieu;
        }
        if (Input.GetKeyDown(keyI))
        {
            Gameplay.dungchieu += DungChieu;
        }
        if (!Input.GetKey(keyA) && !Input.GetKey(keyD))
        {
            isRun = false;
            animator.SetBool("run", false);
        }
        if (Input.GetKeyDown(keySpace))
        {
            if (transform.parent.childCount == 1)
            {
                playerData.startSpawnShadow = true;
                playerData.posRespawn = transform.position;
            }
        }
        if (playerData.startSpawnShadow)
        {
            if (isPlayer)
            {
                if (transform.parent.childCount == playerData.countShadow)
                {
                    playerData.startSpawnShadow = false;
                }
                else
                {
                    timeSpawnShadow -= Time.deltaTime;
                    if (timeSpawnShadow <= 0)
                    {
                        timeSpawnShadow = playerData.timeSpawnShadow;
                        //transform.position = playerData.posRespawn;
                        GameObject obj = Instantiate(playerPrefab, transform.parent);
                        obj.transform.position = playerData.posRespawn;
                        isPlayer = false;
                    }
                }
            }
        }
    }

    public void DungChieu(string key)
    {
        if (key == "KeyU")
        {
            PressKeyU();
        }
        else
        {
            PressKeyI();
        }
    }
    private void PressKeyI()
    {
        print("dich chuyen");
        if (playerData.isTele)
        {
            Vector3 pos = transform.position;
            pos.x += angle * distance / 3.5f;
            transform.position = pos;
        }
    }

    private void PressKeyU()
    {
        Move(new Vector2(distance * angle * 2.5f, rd.velocity.y));
    }

    private void PressKeyW()
    {
        if (isGround)
        {
            Move(new Vector2(rd.velocity.x, playerData.jump));
            animator.SetTrigger("jump");
            audio.clip = clipList[1];
            audio.Play();
        }
    }

    private void PressKeyD()
    {
        angle = 1;
        Move(new Vector2(playerData.speed * angle, rd.velocity.y));
        transform.rotation = Quaternion.Euler(0, 0, 0);
        if (!isRun)
        {
            animator.SetBool("run", true);
            audio.clip = clipList[2];
            audio.Play();
        }
    }

    private void PressKeyA()
    {
        angle = -1;
        Move(new Vector2(playerData.speed * angle, rd.velocity.y));
        transform.rotation = Quaternion.Euler(0, 180, 0);
        if (!isRun)
        {
            animator.SetBool("run", true);
            audio.clip = clipList[2];
            audio.Play();
        }
    }

    private void Move(Vector2 cur)
    {
        rd.velocity = cur;
    }

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position + Vector2.down * 1.07f, Vector2.down, rayLength, groundLayer);
        RaycastHit2D hitLeft = Physics2D.Raycast((Vector2)transform.position + Vector2.right * 0.35f + Vector2.down * 1.07f, Vector2.down, rayLength, groundLayer);
        RaycastHit2D hitRight = Physics2D.Raycast((Vector2)transform.position - Vector2.right * 0.35f + Vector2.down * 1.07f, Vector2.down, rayLength, groundLayer);
        isGround = hit.collider != null || hitLeft.collider != null || hitRight.collider != null;
         //Debug.DrawRay((Vector2)transform.position + Vector2.down * 1.1f , Vector2.down * rayLength * 1.5f, isGround ? Color.red : Color.green);

        RaycastHit2D hit1 = Physics2D.Raycast((Vector2)transform.position + Vector2.right * 0.47f + (angle == -1 ? Vector2.left * 0.97f : Vector2.zero), angle == 1 ? Vector2.right : Vector2.left, distance, groundLayer);
        RaycastHit2D hitLeft1 = Physics2D.Raycast((Vector2)transform.position + Vector2.up * 0.35f + Vector2.right * 0.47f + (angle == -1 ? Vector2.left * 0.97f : Vector2.zero), angle == 1 ? Vector2.right : Vector2.left, distance, groundLayer);
        RaycastHit2D hitRight1 = Physics2D.Raycast((Vector2)transform.position - Vector2.down * 0.35f + Vector2.right * 0.47f + (angle == -1 ? Vector2.left * 0.97f : Vector2.zero), angle == 1 ? Vector2.right : Vector2.left, distance, groundLayer);
        playerData.isTele = hit1.collider == null && hitLeft1.collider == null && hitRight1.collider == null;
        //Debug.DrawRay((Vector2)transform.position + Vector2.right * 0.48f + (angle == -1 ? Vector2.left * 0.97f : Vector2.zero), angle == 1 ? Vector2.right * distance : Vector2.left * distance, playerData.isTele ? Color.red : Color.green);

        if (!isPlayer)
        {
            return;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            if (!isDie)
            {
                isDie = true;
                StartCoroutine(IsDie());
            }
        }
    }

    IEnumerator IsDie()
    {
        animator.SetTrigger("die");
        audio.clip = clipList[0];
        audio.Play();
        yield return new WaitForSeconds(1.2f);
        animator.SetTrigger("die");
        gameObject.SetActive(false);
    }

}
