using EnemyElements.UI;
using UnityEngine.UIElements;

namespace DefaultNamespace
{
  public class PageController
  {
    private TabbedViewController _tabbedViewController;


    public PageController(VisualElement root)
    {
      var tabsContainer = root.Q<VisualElement>("tabs-container");
      var pagesContainer = root.Q<VisualElement>("pages-container");

      _tabbedViewController = new TabbedViewController(tabsContainer, pagesContainer);
    }

    public void AddView(PageViewModel viewModel)
    {
      _tabbedViewController.AddView(viewModel.TabbedView);
    }

    public void SelectView(PageViewModel viewModel)
    {
      _tabbedViewController.SelectView(viewModel.TabbedView);
    }

    public void RemoveView(PageViewModel viewModel)
    {
      _tabbedViewController.RemoveView(viewModel.TabbedView);
    }
  }
}