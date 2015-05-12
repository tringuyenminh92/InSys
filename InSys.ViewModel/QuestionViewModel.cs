using System;

namespace InSys.ViewModel
{
    public class QuestionViewModel
    {
        public System.Guid QuestionId { get; set; }
        public int LevelQuestionId { get; set; }
        public string LevelName { get; set; }
        public string CategoryName { get; set; }
        public string Type { get; set; }
        public string Skill { get; set; }
        public double Time { get; set; }
        public string ContentQuestion { get; set; }
        public Guid ApproveBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Valid { get; set; }
        public string ImagePath { get; set; }
        public string AudioPath { get; set; }
        public string VideoPath { get; set; }
        public bool IsDelete { get; set; }
        public string Code { get; set; }
        public double Point { get; set; }
        public string Tags { get; set; }
        public int CategoryId { get; set; }
        public int CreatedBy { get; set; }
        public string CreateByName { get; set; }
    }
}
