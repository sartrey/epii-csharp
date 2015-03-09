using System;
using System.Collections.Generic;

namespace EPII.Area
{
    public class AreaHub
    {
        private List<Area> _Areas
            = new List<Area>();

        public AreaHub()
        {
        }

        public int Count
        {
            get { return _Areas.Count; }
        }

        public AreaContext this[string name]
        {
            get
            {
                foreach (var area in _Areas)
                    if (area.Name == name)
                        return area.CreateContext();
                return null;
            }
        }

        public AreaContext this[Guid id]
        {
            get
            {
                foreach (var area in _Areas)
                    if (area.Id == id)
                        return area.CreateContext();
                return null;
            }
        }

        public void Add(Area area)
        {
            if (this[area.Id] == null)
                _Areas.Add(area);
        }

        public void Remove(Area area)
        {
            _Areas.Remove(area);
        }
    }
}