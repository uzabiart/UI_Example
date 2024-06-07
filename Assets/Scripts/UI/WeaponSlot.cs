using System.Collections;
using System.Collections.Generic;
using GameScripts.Weapons;
using UnityEngine;

namespace GameScripts.UI
{
    public class WeaponSlot : MonoBehaviour
    {
        [SerializeField] private Weapon weapon;

        public Weapon _Weapon => weapon;

    }
}