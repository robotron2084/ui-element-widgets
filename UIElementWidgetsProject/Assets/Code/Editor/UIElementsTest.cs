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

      var tabsContainer = root.Q<VisualElement>("tabs-container");
      var pagesContainer = root.Q<VisualElement>("pages-container");
      TabbedViewController tabbedViewController = new TabbedViewController();

      var tabTemplate = Resources.Load<VisualTreeAsset>("TabTemplate");
      var pageTemplate = Resources.Load<VisualTreeAsset>("PageTemplate");
      for (int i = 0; i < 3; i++)
      {
        VisualElement tab = tabTemplate.CloneTree().ElementAt(0);
        VisualElement page = pageTemplate.CloneTree().ElementAt(0);
        tabsContainer.Add(tab);
        pagesContainer.Add(page);
        TabbedView tabbedView = new TabbedView(tab, page);
        tabbedViewController.AddView(tabbedView);
      }
      
    }
  }
}