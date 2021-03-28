using EnemyElements.UI;
using UnityEngine;
using UnityEngine.UIElements;

namespace DefaultNamespace
{
  public class PageViewModel
  {
    private TabbedView _tabbedView;

    public TabbedView TabbedView
    {
      get {
        return _tabbedView;
      }
    }
    public PageViewModel(PageController parent)
    {
      // first, we load our templates and get the visual elements within.
      var tabTemplate = Resources.Load<VisualTreeAsset>("TabTemplate");
      var pageTemplate = Resources.Load<VisualTreeAsset>("PageTemplate");
      VisualElement tab = tabTemplate.CloneTree().ElementAt(0);
      VisualElement page = pageTemplate.CloneTree().ElementAt(0);
      // randomize the page bg color.
      page.style.backgroundColor = new StyleColor(new Color(Random.Range(0f, 1f),Random.Range(0f, 1f),Random.Range(0f, 1f)));
      //create a tabbed view
      _tabbedView = new TabbedView(tab, page);

      // add listeners to our buttons.
      Button tabButton = tab.Q<Button>("TabButton");
      tabButton.clicked += () => parent.SelectView(this);
      Button closeButton = tab.Q<Button>("CloseButton");
      closeButton.clicked += () => parent.RemoveView(this);

      Button addPageButton = page.Q<Button>("AddPageButton");
      addPageButton.clicked += () => parent.AddView(new PageViewModel(parent));

      // add ourself to our parent.
      parent.AddView(this);
      
      
    }
  }
}