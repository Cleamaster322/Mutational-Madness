using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;




public class Enemy : Entity
{
    public GameObject meat;
    public Transform enemy;
    private int speed = 2;
    [Header("Enemy Animation Settings")]
    public Animator animator;
    public int damage;

    private float timeBtwShots;
    public float AttackSpeed;

    private AudioClip[] mobHurtSounds;
    private AudioClip[] mobDeathSounds;
    private AudioSource audioSourceHurt;
    private AudioSource audioSourceDeath;
    private Rigidbody2D rb2d;
    private CapsuleCollider2D cc2d;

    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>(); 
        cc2d = GetComponent<CapsuleCollider2D>();
        audioSourceHurt = gameObject.AddComponent<AudioSource>(); 
        audioSourceDeath = gameObject.AddComponent<AudioSource>(); mobHurtSounds = new AudioClip[]
        {
         AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/gamesound/mob_hurt1.wav"),
         AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/gamesound/mob_hurt2.wav"),
         AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/gamesound/mob_hurt3.wav")
        }; 
        mobDeathSounds = new AudioClip[]
        {
         AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/gamesound/mob_death1.wav"),
         AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/gamesound/mob_death2.wav")
        };

        audioSourceHurt.volume = 0.2f;
        audioSourceDeath.volume = 0.2f;
    }

    private void Update()
    {
        if (health > 0) 
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.player.transform.position, speed * Time.deltaTime);

            animator = GetComponent<Animator>();
            animator.SetFloat("moveX", transform.position.x - Player.player.transform.position.x);
        }


    }


    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        if (health > 0)
        {
            audioSourceHurt.PlayOneShot(mobHurtSounds[Random.Range(0, mobHurtSounds.Length)]); 
        }
        else { StartCoroutine(PlayDeathSoundAndDie()); }
    }
    IEnumerator PlayDeathSoundAndDie()
    {
        rb2d.isKinematic = true; 
        cc2d.enabled = false;
        damage = 0;
        audioSourceDeath.PlayOneShot(mobDeathSounds[Random.Range(0, mobDeathSounds.Length)]);
        yield return new WaitWhile(() => audioSourceDeath.isPlaying);
        gameObject.SetActive(false);
        Instantiate(meat, enemy.position, enemy.rotation);
    }


    public void OnCollisionStay2D(Collision2D other)
    {

        if (timeBtwShots <= 0)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.gameObject.GetComponent<Player>().TakeDamage(damage);
                timeBtwShots = AttackSpeed;
            }
        }

        else
        {
            timeBtwShots -= Time.deltaTime;
        }
        
    }

    public EnemyMemento SaveState()
    {
        EnemyMemento memento = new EnemyMemento
        {
            position = new SerializedVector3(transform.position),
            scale = new SerializedVector3(transform.localScale),
            health = health,
            damage = damage,
            isActive = gameObject.activeSelf ? 1 : 0
        };

        return memento;
    }

    public void RestoreState(EnemyMemento memento)
    {
        transform.position = memento.position.ToVector3();
        transform.localScale = memento.scale.ToVector3();
        health = memento.health;
        damage = memento.damage;
        gameObject.SetActive(memento.isActive == 1);
    }

}

[System.Serializable]
public struct SerializedVector3
{
    public float x;
    public float y;
    public float z;

    public SerializedVector3(Vector3 vector)
    {
        x = vector.x;
        y = vector.y;
        z = vector.z;
    }

    public Vector3 ToVector3()
    {
        return new Vector3(x, y, z);
    }
}

[System.Serializable]
public class EnemyMemento
{
    public SerializedVector3 position;
    public SerializedVector3 scale;
    public int health;
    public int damage;
    public int isActive;
}
