using UnityEngine;

namespace UIs.Core
{
    public static class RouterBase
    {
        public static ScreenState Current { private set; get; }

        public static void ResetCurrent() => Current = null;

        public static void ChangeState(ScreenState newState)
        {
            Current?.Hide();
            Current = newState;
            Current?.Show();
        }
    }
}
