using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PREFINAL_QUIZ1.Models
{
    public class TitlesModel
    {
        [Key]    
        public int titleID { get; set; }

        [Display(Name = "Publisher")]
        [Required]
        public int pubID { get; set; }

        public List<SelectListItem>  publisherNames { get; set; }

        [Display(Name = "Publisher")]
        [Required]
        public string pubName { get; set; }

        [Display(Name = "Author")]
        [Required]
        public int authorID { get; set; }

        public List<SelectListItem> authorNames { get; set; }

        [Display(Name = "Author")]
        [Required]
        public string authorFN { get; set; }

        [Display(Name = " ")]
        [Required]
        public string authorLN { get; set; }

        [Display(Name = "Title Name")]
        [Required]
        [MaxLength(100)]       
        public string titleName { get; set; }

         [Display(Name = "Price")]
        [Required]               
        public string titlePrice { get; set; }

        [Display(Name = "Publication Date")]
        [Required]
        [DataType(DataType.Date)]
         public DateTime titlePubDate { get; set; }

        [Display(Name = "Notes")]
        [Required]
        [MaxLength(200)]
        public string titleNotes { get; set; }
    }
   }
