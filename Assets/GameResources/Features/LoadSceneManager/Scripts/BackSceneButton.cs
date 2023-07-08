namespace LoadImages.Features.LoadSceneManager
{
    using UnityEngine;
    /// <summary>
    /// ����� �� ���������� ����� �� ��������� ������
    /// </summary>
    public class BackSceneButton : MonoBehaviour
    {
        [SerializeField]
        private string _prevScene = default;

        private void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                LoadSceneManager.Instance.LoadSceneByName(_prevScene);
            }
        }
    }
}