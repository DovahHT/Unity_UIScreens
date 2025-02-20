using UnityEngine;

namespace UIs.Core
{
    public abstract class ScreenState<TState, TView> : ScreenState where TState : ScreenState where TView : MonoBehaviour
    {
        protected const string VIEWS_ADDRESS_IN_RESOURCE = "";

        #region Singleton
        private static TState instance;
        public static TState Instance => instance ?? InitInstance();

        private static TState InitInstance()
        {
            instance = new GameObject(typeof(TState).Name).AddComponent<TState>();
            instance.Initialize();
            return instance;
        }

        private void OnDestroy()
        {
            instance = null;
        }
        #endregion

        protected TView view;
        protected bool isActive;

        protected virtual string ViewAddress => VIEWS_ADDRESS_IN_RESOURCE + typeof(TView).Name;

        public override void Initialize()
        {
            view = Instantiate(Resources.Load<GameObject>(ViewAddress), transform).GetComponent<TView>();

        }
        public override void Show() { view.gameObject.SetActive(true); isActive = true; }
        public override void Hide() { view.gameObject.SetActive(false); isActive = false; }
    }
}
