using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTile : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject initialFlame;
    [SerializeField] private GameObject fire;

    float delay = 2.0f;
    public bool on;
    private Coroutine _spawnCoroutine = null;

    void Start()
    {
        on = false;
    }

    // Activates the tile upon contact with the player, and then begins coroutine to spawn the fire.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!on)
            {
                on = true;

                if (_spawnCoroutine == null)
                {
                    _spawnCoroutine = StartCoroutine("TrapDelay");
                }

                
            }

        }
    }

    // Delays the spawning of the fire for 2 seconds, then spawns the fire object to hurt the player.
    // Afterwards, waits another two seconds, then begins the TrapExit function to despawn the fire.
    IEnumerator TrapDelay()
    {
        Instantiate(initialFlame, this.transform.position, Quaternion.identity);

        yield return new WaitForSeconds(delay);

        Instantiate(fire, this.transform.position, Quaternion.identity);

        yield return new WaitForSeconds(delay);

        TrapExit();
    }

    //
    private void TrapExit()
    {
        StopCoroutine(_spawnCoroutine);
        _spawnCoroutine = null;

        on = false;
    }
}
