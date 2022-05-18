using System;
using System.Collections.Generic;
using System.Text;

namespace a5pwt_ctvrtek.Domain.Entities.Settings
{
    public class Setting : Entity
    {
        public bool showRelated { get; set; }
        public bool showRelatedFromSameArea { get; set; }
        public bool showHotPicks { get; set; }
        public string areaOfRelated { get; set; }
    }
}
