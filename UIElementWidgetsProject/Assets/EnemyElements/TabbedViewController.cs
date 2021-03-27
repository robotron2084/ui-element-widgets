using System.Collections.Generic;
using UnityEngine.UIElements;

namespace EnemyElements.UI
{
  public class TabbedViewController
  {
    private VisualElement _tabsContainer;
    private VisualElement _pagesContainer;
    
    private List<TabbedView> _tabbedViews = new List<TabbedView>();
    private TabbedView _currentView;

    public void TabbedView(VisualElement tabsContainer, VisualElement pagesContainer)
    {
      _tabsContainer = tabsContainer;
      _pagesContainer = pagesContainer;
    }

    public void AddView(TabbedView tabbedView)
    {
      _tabbedViews.Add(tabbedView);
      if (_currentView == null)
      {
        _currentView = tabbedView;
      }
      tabbedView.OnSelected(_currentView == tabbedView);
    }

    public void SelectView(TabbedView tabbedView)
    {
      if (tabbedView == _currentView)
      {
        return;
      }
      if (_currentView != null)
      {
        _currentView.OnSelected(false);
      }

      _currentView = tabbedView;
      _currentView.OnSelected(true);
      
    }
  }
}