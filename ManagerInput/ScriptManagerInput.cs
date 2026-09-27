using UnityEngine;
using System;

namespace Intoworld2dtd
{
    /// <summary>
    /// Centralized Singleton gateway that handles active controller states and acts as an event observer.
    /// </summary>
    public class ScriptManagerInput : ScriptAbstractPausable
    {
        public static ScriptManagerInput Instance { get; private set; }

        private IControllerCmd controllerCmd;

        public bool IsPlayerInputActive => controllerCmd is ClassControllerPlayerInput;

        void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;

            ResetToPlayerController();
        }

        private void OnEnable()
        {
            ScriptGate.OnCollisionGateEvent += HandleCollisionWithGate;
        }

        private void OnDisable()
        {
            ScriptGate.OnCollisionGateEvent -= HandleCollisionWithGate;
        }

        public void HandleCollisionWithGate(ScriptGate gate) => SetController(null);

        protected override void OnUpdate()
        {
            base.OnUpdate();

            controllerCmd?.UpdateInput();
        }

        protected override void OnLateUpdate()
        {
            base.OnLateUpdate();

            if (controllerCmd != null) controllerCmd.UpdateView();
        }

        public void SetController(IControllerCmd newController)
        {
            controllerCmd = newController;
        }

        public void ResetToPlayerController()
        {
            controllerCmd = new ClassControllerPlayerInput();
        }
    }
}