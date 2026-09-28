using UnityEngine;

namespace Intoworld2dtd
{
     /// <summary>
    /// Contract interface implementing the Command Pattern to decouple input fetching from rendering logic.
    /// </summary>
    public interface IControllerCmd
    {
        void UpdateInput();
        void UpdateView();
        Vector2 GetDirection();
        bool IsMoving();
    }
}