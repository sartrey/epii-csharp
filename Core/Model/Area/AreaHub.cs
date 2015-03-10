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
                        return new AreaContext(area);
                return null;
            }
        }

        public AreaContext this[Guid id]
        {
            get
            {
                foreach (var area in _Areas)
                    if (area.Id == id)
                        return new AreaContext(area);
                return null;
            }
        }

        public void Add(Area area)
        {
            var exist = _Areas.Exists(
                (e) => { return e.Id == area.Id; });
            if (!exist)
                _Areas.Add(area);
        }

        public void Remove(Area area)
        {
            var old = _Areas.Find(
                (e) => { return e.Id == area.Id; });
            if (old != null)
                _Areas.Remove(old);
        }
    }
}