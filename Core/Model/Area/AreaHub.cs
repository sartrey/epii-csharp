using System;
using System.Collections.Generic;

namespace EPII.Area
{
    public class AreaHub
    {
        private List<Area> areas_
            = new List<Area>();

        public AreaHub()
        {
        }

        public int Count
        {
            get { return areas_.Count; }
        }

        public Area this[string name]
        {
            get
            {
                return areas_.Find(
                    (e) => { return e.Name == name; });
            }
        }

        public Area this[Guid id]
        {
            get
            {
                return areas_.Find(
                    (e) => { return e.Id == id; });
            }
        }

        public void Add(Area area)
        {
            var exist = areas_.Exists(
                (e) => { return e.Id == area.Id; });
            if (!exist)
                areas_.Add(area);
        }

        public void Remove(Area area)
        {
            var old = areas_.Find(
                (e) => { return e.Id == area.Id; });
            if (old != null)
                areas_.Remove(old);
        }
    }
}