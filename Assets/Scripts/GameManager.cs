using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [Header("References")]
    [SerializeField] private List<GameObject> entityPrefabPool;
    [SerializeField] private GameObject baseGameObject;
    [SerializeField] private GameObject enemyBaseGameObject;
    public InputHandler inputHandler;
    public EntityData entityData;
    private IEnumerator coroutine;
    private int entityCount = 0;
    private int entityCap = 50;
    
    [SerializeField] private PlayerMovement testEntity;
    [SerializeField] private Enemy enemyEntity;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(this);
        }
        
        StartCoroutine(nameof(SpawnEntityEndlessly),5f);
    }

    private void SpawnEntity(Entity entity)
    {
        if (entityCount < entityCap)
        {
            if (entity.fraction == Entity.Fraction.Player)
                Instantiate(entity, baseGameObject.transform.position - Vector3.left * 3f, entity.transform.rotation);
            else
                Instantiate(entity, enemyBaseGameObject.transform.position - Vector3.right * 3f, entity.transform.rotation);
            entityCount++;
        }
    }

    private IEnumerator SpawnEntityEndlessly(float timeInterval)
    {
        while (true)
        {
            yield return new WaitForSeconds(timeInterval);
            SpawnEntity(entityPrefabPool[0].GetComponent<Entity>());
            SpawnEntity(entityPrefabPool[1].GetComponent<Entity>());
        }
    }
    
    [ContextMenu("Spawn Entity")]
    void SpawnEntity()
    {
        //Entity e = testEntity;
        SpawnEntity(testEntity);
    }

}
