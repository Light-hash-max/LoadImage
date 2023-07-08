namespace LoadImages.Features.Orientation
{
    using UnityEngine;

    /// <summary>
    /// ���������� ������
    /// </summary>
    public class CustomScreenOrientation : MonoBehaviour
    {
        [SerializeField]
        private ScreenOrientation _screenOrientation = default;

        private void Start() => SetOrientation();

        private void SetOrientation() => Screen.orientation = _screenOrientation;
    }
}
