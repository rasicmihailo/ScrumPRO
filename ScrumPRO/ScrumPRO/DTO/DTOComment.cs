using AutoMapper;
using ScrumPRO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScrumPRO.DTO
{
    [Serializable]
    public class DTOComment
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public byte Id { get; set; }
        public String Text { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public Sprint Sprint { get; set; }
        public byte SprintId { get; set; }
        public Story Story { get; set; }
        public byte StoryId { get; set; }
        public StoryTask StoryTask { get; set; }
        public byte StoryTaskId { get; set; }
        public int DailyReportId { get; set; }
        public DailyReport DailyReport { get; set; }


        public DTOComment GetById(int id)
        {
            var comment = db.Stories.Find(id);
            return Mapper.Map<DTOComment>(comment);
        }
    }
}