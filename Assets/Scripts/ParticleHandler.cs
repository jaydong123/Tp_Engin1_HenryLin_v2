using UnityEngine;

public class ParticleHandler : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private ParticleSystem smokeParticle;
    private Entity entity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if (!entity)
            entity = GetComponent<Entity>();
        //if (!smokeParticle)
           // smokeParticle = transform.Find("Smoke").GetComponent<ParticleSystem>();
    }

    private void OnEnable()
    {
        entity.OnVelocityChanged += UpdateParticle;
    }

    private void OnDisable()
    {
        entity.OnVelocityChanged -= UpdateParticle;
    }

    private void UpdateParticle(float playerVelocityX)
    {
        playerVelocityX = Mathf.Abs(playerVelocityX);
        if (playerVelocityX > 0.1f)
        {
  
            //Debug.Log("Play");
            smokeParticle.gameObject.SetActive(true);
            //smokeParticle.Play();
        }
        else
        {
            //Debug.Log("Stop");
            smokeParticle.gameObject.SetActive(false);
            //smokeParticle.Pause();
        }
    }
}
