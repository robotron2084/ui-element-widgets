using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace EnemyElements.UI
{
  public class TabbedViewController
  {
    public delegate void OnViewChangedEvent(TabbedViewController tabbedViewController);

    public OnViewChangedEvent OnViewChanged;
    
    private VisualElement _tabsContainer;
    private VisualElement _pagesContainer;
    
    private List<TabbedView> _tabbedViews = new List<TabbedView>();
    private TabbedView _currentView;

    public TabbedView CurrentView => _currentView;

    public int CurrentViewIndex
    {
      get
      {
        if (_currentView == null)
        {
          return 0;
        }
        return _tabbedViews.IndexOf(_currentView);
      }
    }

    public TabbedViewController(VisualElement tabsContainer, VisualElement pagesContainer)
    {
      _tabsContainer = tabsContainer;
      _pagesContainer = pagesContainer;
    }

    public void AddView(TabbedView tabbedView)
    {
      _tabbedViews.Add(tabbedView);
      _tabsContainer.Add(tabbedView.TabView);
      _pagesContainer.Add(tabbedView.PageView);
      if (_currentView == null)
      {
        _currentView = tabbedView;
      }
      tabbedView.OnSelected(_currentView == tabbedView);
    }

    /// <summary>
    /// Selects a view. Views can be unselected by choosing 'null'.
    /// </summary>
    /// <param name="tabbedView"></param>
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
      if (_currentView != null)
      {
        _currentView.OnSelected(true);
      }
      OnViewChanged?.Invoke(this);
      
    }

    public void SelectView(int index)
    {
      Mathf.Clamp(index, 0, _tabbedViews.Count - 1);
      TabbedView tabbedView = _tabbedViews[index];
      SelectView(tabbedView);
    }

    public void RemoveView(TabbedView tabbedView)
    {
      if (tabbedView == null)
      {
        return;
      }
      if (_currentView == tabbedView)
      {
        //get the next view...
        if (_tabbedViews.Count > 1)
        {
          // we have other views...select one of them.
          foreach (var view in _tabbedViews)
          {
            if (view != tabbedView)
            {
              SelectView(view);
              break;
            }
          }
        }
        else
        {
          SelectView(null);
        }
      }
      _tabbedViews.Remove(tabbedView);
      tabbedView.DetachFromParent();
      
    }
  }
}