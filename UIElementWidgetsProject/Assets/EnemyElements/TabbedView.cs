using UnityEngine.UIElements;

namespace EnemyElements.UI
{
  public class TabbedView
  {
    private static string TabActiveStyle = "tab-active";
    private static string TabInactiveStyle = "tab-inactive";
    
    private VisualElement _tabView;
    private VisualElement _pageView;

    public TabbedView(VisualElement tabView, VisualElement pageView)
    {
      _tabView = tabView;
      _pageView = pageView;
    }

    public void OnSelected(bool enable)
    {
      string styleToAdd = enable ? TabActiveStyle : TabInactiveStyle;
      string styleToRemove = enable ? TabInactiveStyle : TabActiveStyle;
      _tabView.AddToClassList(styleToAdd);
      _tabView.RemoveFromClassList(styleToRemove);
      //_pageView.AddToClassList(styleToAdd);
      //_pageView.RemoveFromClassList(styleToRemove);
    }
    
    

  }
}