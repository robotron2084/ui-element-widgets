using UnityEngine.UIElements;

namespace EnemyElements.UI
{
  public class TabbedView
  {
    private static string TabActiveStyle = "tab-active";
    private static string TabInactiveStyle = "tab-inactive";
    
    private static string PageActiveStyle = "page-active";
    private static string PageInactiveStyle = "page-inactive";

    private VisualElement _tabView;
    public VisualElement TabView
    {
      get { return _tabView; }
    }
    private VisualElement _pageView;

    public VisualElement PageView
    {
      get { return _pageView; }
    }

    public TabbedView(VisualElement tabView, VisualElement pageView)
    {
      _tabView = tabView;
      _pageView = pageView;
    }

    public void OnSelected(bool enable)
    {
      toggleClasses(_tabView, enable, TabActiveStyle, TabInactiveStyle);
      toggleClasses(_pageView, enable, PageActiveStyle, PageInactiveStyle);
    }

    public void DetachFromParent()
    {
      _tabView.RemoveFromHierarchy();
      _pageView.RemoveFromHierarchy();
    }

    void toggleClasses(VisualElement view,bool isActive, string activeStyle, string inactiveStyle)
    {
      string styleToAdd = isActive ? activeStyle : inactiveStyle;
      string styleToRemove = isActive ? inactiveStyle : activeStyle;
      view.AddToClassList(styleToAdd);
      view.RemoveFromClassList(styleToRemove);

    }
    
    

  }
}