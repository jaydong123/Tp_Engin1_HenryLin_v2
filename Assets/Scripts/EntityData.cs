using UnityEngine;

[CreateAssetMenu(fileName = "EntityData", menuName = "EntityData")]
public class EntityData : ScriptableObject
{
    public float maxSpeed = 10f;
    public float acceleration = 15f;
    public float deceleration = 10f;
    public float jumpForce = 500f;
    public float moveForce = 200f;
}
