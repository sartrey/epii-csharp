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

        public Area this[string name]
        {
            get
            {
                return _Areas.Find(
                    (e) => { return e.Name == name; });
            }
        }

        public Area this[Guid id]
        {
            get
            {
                return _Areas.Find(
                    (e) => { return e.Id == id; });
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