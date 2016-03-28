namespace Handle_Data
{
    internal class Question
    {
        public Question()
        {
             
        }
        public string questionID { get; set; }
        public string questionNo { get; set; }
        public string content { get; set; }
        public string questionType { get; set; }
        public string rightAnswer { get; set; }

        public string answerExplain { get; set; }
        public string difficulty { get; set; }
        public string rightRate { get; set; }
        public string isCollect { get; set; }
        public string isOut { get; set; }
        //public string groupInfo { get; set; }
        public string hot { get; set; }
       // public string questionAudio { get; set; }
    }
}