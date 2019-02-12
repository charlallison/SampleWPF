using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Shared;
using StudentRecord.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRecord
{
    public class RecordModule : IModule
    {
        public RecordModule(IUnityContainer container, IRegionManager regionManager)
        {
            this.container = container;
            this.regionManager = regionManager;
        }

        public void Initialize()
        {
            regionManager.RegisterViewWithRegion(RegionNames.MenuRegion, typeof(MenuControl));
        }

        private IUnityContainer container;
        private IRegionManager regionManager;
    }
}
