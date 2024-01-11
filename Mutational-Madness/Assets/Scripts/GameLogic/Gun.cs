using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Gun : MonoBehaviour
{
    //Gun using complex math functions
    public float offset;
    public GameObject bullet;
    public Transform shotPoint;
    public Player player;
    public AudioClip gunShotSound;
    public AudioSource audioSource;
    private float timeBtwShots;
    public float startTimeBtwShots;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        gunShotSound = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/gamesound/gun_shot.wav");
        audioSource.clip = gunShotSound;
        audioSource.volume = MusicManager.instance.GetGameVolume();
    }

    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (player.weapon == 2)
        {
            if (timeBtwShots <= 0)
            {
                if (Input.GetMouseButton(0))
                {
                    Instantiate(bullet, shotPoint.position, transform.rotation);
                    timeBtwShots = startTimeBtwShots;
                    audioSource.Play(); 
                }
            }

            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
    }
}
