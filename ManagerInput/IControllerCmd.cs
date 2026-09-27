using UnityEngine;

namespace Intoworld2dtd
{
    public interface IControllerCmd
    {
        void UpdateInput();
        void UpdateView();
        Vector2 GetDirection();
        bool IsMoving();
    }
}