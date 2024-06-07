using GameSystems.PlayerCharacter;
using UnityEngine;

public class EnergyTrigger : MonoBehaviour
{
    [SerializeField] private float addedEnergy = 10f;
    
    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<PlayerBuilder>().AddEnergy(addedEnergy);
    }
}
