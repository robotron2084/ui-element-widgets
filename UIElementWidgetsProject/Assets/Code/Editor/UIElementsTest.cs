using EnemyElements.UI;
using UnityEngine;
using UnityEngine.UIElements;

namespace DefaultNamespace
{
  public class UIElementsTest : UnityEditor.EditorWindow
  {
    [UnityEditor.MenuItem("Window/UI/Enemy Elements Test")]
    private static void ShowWindow()
    {
      var window = GetWindow<UIElementsTest>();
      window.titleContent = new UnityEngine.GUIContent("EnemyElements");
      window.Show();
    }

    
    private void OnEnable()
    {
      initView();
    }
    
    void initView()
    {
      var root = rootVisualElement;
      root.styleSheets.Add(Resources.Load<StyleSheet>("Styles"));
      var visualTree = Resources.Load<VisualTreeAsset>("Main");
      visualTree.CloneTree(root);
      PageController controller = new PageController(root);

      for (int i = 0; i < 3; i++)
      {
        new PageViewModel(controller);

      }
      
    }
  }
}