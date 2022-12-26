using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1C.U
{
    public class Filter
    {
        //формирование списка учетных единиц по модели
        public static List<InventoryItem> FilterByModel(string query, List<InventoryItem> inventoryItems)
        {
            if (query == "" || query.Length>50)
                return null;
            var filteredList = new List<InventoryItem>();
            foreach (var item in inventoryItems)
                if (item.Model == query)
                    filteredList.Add(item);
            return filteredList;
        }

        //формирование списка учетных единиц по филиалу
        public static List<InventoryItem> FilterByBranch(string query, List<InventoryItem> inventoryItems)
        {
            if (query == "")
                return null;
            var filteredList = new List<InventoryItem>();
            foreach (var item in inventoryItems)
                if (item.Branch == query)
                    filteredList.Add(item);
            return filteredList;
        }
    }
}
