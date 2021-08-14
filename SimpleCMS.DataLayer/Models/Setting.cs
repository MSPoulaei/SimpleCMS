using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.DataLayer.Models
{
    class Setting
    {
        public int ProfileId { get; set; }
        public bool IsActivated { get; set; }
        public string ProfileName { get; set; }
        public LanguageNames LanguageName { get; set; }
        public int SliderPostsCount { get; set; }
        public int PostsFontSize { get; set; }
        public string SiteName { get; set; }
        public string SiteDescription { get; set; }
        public int PagePostsCount { get; set; }

    }
    enum LanguageNames
    {
        Persian=1,
        English
    }
}
