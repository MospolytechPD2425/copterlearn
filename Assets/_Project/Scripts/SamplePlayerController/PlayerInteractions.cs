using UnityEngine;
using NaughtyAttributes;
using HInteractions;
using System;

namespace HPlayer
{
    public class PlayerInteractions : MonoBehaviour, IObjectHolder
    {
        [Header("Select")]
        [SerializeField, Required] private Transform playerCamera;
        [SerializeField] private float selectRange = 10f;
        [SerializeField] private LayerMask selectLayer;
        [field: SerializeField, ReadOnly] public Interactable SelectedObject { get; private set; } = null;

        public event Action OnSelect;
        public event Action OnDeselect;

        private void Update()
        {
            UpdateSelectedObject();
        }

        #region -selected object-

        private void UpdateSelectedObject()
        {
            Interactable foundInteractable = null;
            if (Physics.SphereCast(playerCamera.position, 0.2f, playerCamera.forward, out RaycastHit hit, selectRange, selectLayer))
                foundInteractable = hit.collider.GetComponent<Interactable>();

            if (SelectedObject == foundInteractable)
                return;

            if (SelectedObject)
            {
                SelectedObject.Deselect();
                OnDeselect?.Invoke();
            }

            SelectedObject = foundInteractable;

            if (foundInteractable && foundInteractable.enabled)
            {

                foundInteractable.Select();
                OnSelect?.Invoke();
            }
        }

        #endregion
    }
}