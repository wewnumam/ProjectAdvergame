using Agate.MVC.Base;
using NaughtyAttributes;
using ProjectAdvergame.Utility;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ProjectAdvergame.Module.Health
{
    public class HealthView : ObjectView<IHealthModel>
    {
        public TMP_Text healthText;
        public Transform playerTransform;
        public GameObject healthPrefab;
        public int poolSize;
        public float distanceMultiplier;
        [ReadOnly] public List<GameObject> healthObjects;

        [Header("Debug")] public bool isImmortal;

        private void Start()
        {
            for (int i = 0; i < poolSize; i++)
                Spawn(i);
        }

        private void Spawn(int index)
        {
            GameObject obj = Instantiate(healthPrefab, new Vector3(0, .5f, (-index - 1) * distanceMultiplier), Quaternion.identity, playerTransform);
            healthObjects.Add(obj);
        }

        protected override void InitRenderModel(IHealthModel model)
        {
        }

        protected override void UpdateRenderModel(IHealthModel model)
        {
            healthText.SetText(model.CurrentHealth.ToString());

            if (model.CurrentHealth > poolSize)
            {
                poolSize = model.CurrentHealth;
                Spawn(poolSize);
            }

            for (int i = 0; i < healthObjects.Count; i++)
                healthObjects[i].SetActive(i < model.CurrentHealth);
        }
    }
}