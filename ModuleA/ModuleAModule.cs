using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ModuleA.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace ModuleA
{
    public class ModuleAModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public ModuleAModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
 
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            IRegion region = _regionManager.Regions["ContentRegion"];

            var view1 = containerProvider.Resolve<ViewA>();
            region.Add(view1);

            var view2 = containerProvider.Resolve<ViewA>();
            view2.Content = new TextBlock()
            {
                Text = "Hi from View 2",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            region.Add(view2);
            region.Activate(view2);

            region.Activate(view1);

            region.Deactivate(view1);

            region.Activate(view2);

            region.Remove(view2);

            region.Activate(view1);
        }
    }
}
