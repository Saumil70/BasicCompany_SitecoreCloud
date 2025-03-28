﻿using Sitecore.Data.Items;
using System.Linq;

namespace BasicCompany.Feature.Navigation.Services
{
    public class NavigationRootResolver : INavigationRootResolver
    {
        public Item GetNavigationRoot(Item contextItem)
        {
            if (contextItem == null)
            {
                return null;
            }
            return contextItem.DescendsFrom(Templates.NavigationRoot.Id)
                ? contextItem
                : contextItem.Axes.GetAncestors().LastOrDefault(x => x.DescendsFrom(Templates.NavigationRoot.Id));
        }
    }
}