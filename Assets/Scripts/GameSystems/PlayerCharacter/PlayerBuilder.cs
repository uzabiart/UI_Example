using UnityEngine;

namespace GameSystems.PlayerCharacter
{
    public class PlayerBuilder : MonoBehaviour
    {
        [SerializeField] float placeDistance = 1f;
        [SerializeField] PlaceableController[] prefabsToPlace;
        int currentPrefab = 0;

        [Header("Place Settings")] 
        [SerializeField] LayerMask layerMask;

        [Header("Player Energy")]
        [SerializeField] float maxEnergy = 100f;

        [SerializeField] private float energy = 80f;
        [SerializeField] private StatusBar energyBar;

        readonly Collider[] overlapBoxResult = new Collider[1];
        
        enum State { Idle, Building }

        private State currentState = State.Idle;

        public Vector3 DebugCheckPosition;
        public bool DebugIsCheckPositionFree;

        private void Awake()
        {
            energyBar.UpdateBar(energy, maxEnergy);
        }

        private void Update()
        {
            SelectCorrectState();
            SelectPrefabToPlace();
            if (currentState == State.Building)
            {
                BuildingUpdate();
            }
        }

        private void SelectCorrectState()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                currentState = currentState == State.Idle ? State.Building : State.Idle;
            }
        }

        private void SelectPrefabToPlace()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                var prefabAmount = prefabsToPlace.Length;
                currentPrefab = currentPrefab + 1 <= prefabAmount - 1 ? currentPrefab + 1 : 0;
            }
        }

        private void BuildingUpdate()
        {
            var placePosition = Vector3Int.FloorToInt(transform.position + Vector3.up * 0.5f + transform.forward * placeDistance);
            var boxCastPosition = placePosition + Vector3.up * 0.5f;
            var collidersCount = Physics.OverlapBoxNonAlloc(boxCastPosition, Vector3.one * 0.49f,
                overlapBoxResult, Quaternion.identity, layerMask, QueryTriggerInteraction.Ignore);

            var hasEnergyToPlace = energy >= prefabsToPlace[currentPrefab].PlaceableCost;
            
            // DEBUG ----
            DebugIsCheckPositionFree = collidersCount == 0 && hasEnergyToPlace;
            DebugCheckPosition = boxCastPosition;
            // ------

            if (collidersCount > 0)
            {
                return;
            }

            if (Input.GetKeyDown(KeyCode.Space) && hasEnergyToPlace)
            {
                energy -= prefabsToPlace[currentPrefab].PlaceableCost;
                Instantiate(prefabsToPlace[currentPrefab], placePosition, Quaternion.identity);
                energyBar.UpdateBar(energy, maxEnergy);
            }
        }

        private void OnDrawGizmos()
        {
            if (currentState == State.Building)
            {
                Gizmos.color = DebugIsCheckPositionFree ? Color.green : Color.red;
                Gizmos.DrawMesh(
                    prefabsToPlace[currentPrefab].PlaceableMesh, 0, 
                    DebugCheckPosition, Quaternion.identity, 
                    Vector3.one);
            }
        }

        public void AddEnergy(float addedEnergy)
        {
            energy = energy + addedEnergy <= maxEnergy ? energy + addedEnergy : maxEnergy; 
            energyBar.UpdateBar(energy, maxEnergy);
        }
    }
}
