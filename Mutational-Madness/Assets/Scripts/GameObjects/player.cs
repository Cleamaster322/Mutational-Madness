using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Entity
{
    public float speed = 5f;
    private Rigidbody2D rb;
    [Header("Player Animation Settings")]
    public Animator animator;
    public int weapon;
    public int radius;
    public float rot;
    public int flesh;
    public static Player player;
    public int isMoving;
    private AudioSource audioSourceWalk;
    private AudioSource audioSourceHurt;
    private AudioSource audioSourceSilence;
    private AudioClip[] damageSounds;
    private AudioClip walkSound;
    private AudioClip silenceSound;
    private AudioClip eatSound;
    private AudioSource audioSource;
    private SpriteRenderer render;
    

    private void Awake()
    {
        player = this;
    }

    void Start()
    {
        player = this;
        rb = GetComponent<Rigidbody2D>();
        weapon = 2;
        rot = 1;
        flesh = 0;
        render = GetComponent<SpriteRenderer>();
        LoadSound();
    }

    void Update()
    {
        //moving
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        if (moveX != 0 || moveY != 0)
        {
            isMoving = 1;
            if (!audioSourceWalk.isPlaying)
            {
                audioSourceWalk.loop = true;
                audioSourceWalk.Play();
                audioSourceSilence.Stop();
            }
        }
        else if (moveX == 0 || moveY == 0)
        {
            isMoving = 0;
            audioSourceWalk.Stop();
            if (!audioSourceSilence.isPlaying) 
            {
                audioSourceSilence.loop = true;
                audioSourceSilence.Play();
            }
        }

        if (Mathf.Abs(moveX) > 0)
        {
            rot = moveX;
        }
        Vector2 movement = new Vector2(moveX, moveY);
        rb.velocity = movement * speed;
        //animate
        animator = GetComponent<Animator>();
        animator.SetFloat("moveX", moveX);
        animator.SetFloat("moveY", moveY);
        animator.SetInteger("weapon", weapon);
        animator.SetInteger("moving", isMoving);
        animator.SetFloat("rot", rot);
        //collecting meat
        Collider2D[] meatColliders = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (Collider2D meatCollider in meatColliders)
        {
            if (meatCollider.gameObject.CompareTag("Meat"))
            {
                meatCollider.GetComponent<Magnet>().Attract(this);
            }
        }
    }
    //whole damage block
    public override void TakeDamage(int amount)
    {
        base.TakeDamage(amount);
        audioSourceHurt.PlayOneShot(damageSounds[Random.Range(0, damageSounds.Length)]);
        StartCoroutine(onDamageReaction());
        
    }
    IEnumerator onDamageReaction()
    {
        render.material.color = Color.HSVToRGB(0, 0.5f, 1);
        yield return new WaitForSeconds(0.1f);
        render.material.color = Color.white; 
    }

    
    public void Eat()
    {
        audioSource.PlayOneShot(eatSound);
        flesh++;
    }
    //sound block
    void LoadSound()
    {
        string[] paths = new string[]
     {
        "Assets/gamesound/gg_hurt1.wav",
        "Assets/gamesound/gg_hurt2.wav",
        "Assets/gamesound/gg_hurt3.wav"
     };

        damageSounds = new AudioClip[paths.Length];

        for (int i = 0; i < paths.Length; i++)
        {
            damageSounds[i] = AssetDatabase.LoadAssetAtPath<AudioClip>(paths[i]);
        }

        walkSound = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/gamesound/steps.ogg");
        audioSourceWalk = gameObject.AddComponent<AudioSource>();
        audioSourceWalk.clip = walkSound;

        silenceSound = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/gamesound/silence.ogg");
        audioSourceSilence = gameObject.AddComponent<AudioSource>();
        audioSourceSilence.clip = silenceSound;

        audioSourceHurt = gameObject.AddComponent<AudioSource>();

        audioSource = gameObject.AddComponent<AudioSource>();
        eatSound = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/gamesound/eating.ogg");

        audioSourceWalk.volume = MusicManager.instance.GetGameVolume();
        audioSourceSilence.volume = MusicManager.instance.GetGameVolume();
        audioSourceHurt.volume = MusicManager.instance.GetGameVolume();
        audioSource.volume = MusicManager.instance.GetGameVolume();
    }

    //memento saving block
    public PlayerMemento SaveState()
    {
        PlayerMemento memento = new PlayerMemento
        {
            health = health,
            weapon = weapon,
            flesh = flesh,
            x = transform.position.x,
            y = transform.position.y,
            z = transform.position.z
        };

        return memento;
    }

    public void RestoreState(PlayerMemento memento)
    {
        if (player != null)
        {
            health = memento.health;
            weapon = memento.weapon;
            flesh = memento.flesh;
            transform.position = new Vector3(memento.x, memento.y, memento.z);
        }
        else
        {
            Debug.LogError("Player object is null");
        }
    }
}

[System.Serializable]
public struct PlayerMemento
{
    public int health;
    public int weapon;
    public int flesh;
    public float x;
    public float y;
    public float z;
}
