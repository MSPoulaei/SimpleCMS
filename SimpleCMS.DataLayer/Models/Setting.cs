using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.DataLayer.Models
{
    public class Setting
    {
        public int ProfileId { get; set; }
        public bool IsActivated { get; set; }
        public string ProfileName { get; set; }
        public string SiteTitle { get; set; }
        public string SiteDescription { get; set; }
        public Language Language { get; set; }
        public int SliderPostsCount { get; set; }
        public int PostsFontSize { get; set; }
        public int PagePostsCount { get; set; }
        public bool ShowDescriptionInPost { get; set; }
        
    }
   public enum Language
    {
        [Display(Name ="فارسی")]
        Persian=1,
        English
    }
}
