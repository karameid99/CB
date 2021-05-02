using CB.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB.Models.Entities.FAQ
{
   public class FrequentlyAskedQuestion : BaseEntity
    {
        public string TitleAr { get; set; }
        public string TitleEn { get; set; }
        public string AnswerAr { get; set; }
        public string AnswerEn { get; set; }
        public QuestionType QuestionType { get; set; }
    }
}
