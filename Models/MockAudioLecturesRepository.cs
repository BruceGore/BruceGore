using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace mvccore.Models
{
    public class MockAudioLecturesRepository : IAudioLecturesRepository
    {

        private List<AudioLectures> _audioLecturesList;

        public MockAudioLecturesRepository()
        {
            _audioLecturesList = new List<AudioLectures>()
            {
                //new AudioLectures(){ ID = 1000, Class = Class.Bible, Topic = "Genesis"},
                //new AudioLectures(){ ID = 2000, Class = Class.Bible, Topic = "Exodus"},
                //new AudioLectures(){ ID = 3000, Class = Class.Bible, Topic = "Levicitus"},
                //new AudioLectures(){ ID = 4000, Class = Class.Bible, Topic = "Matthew", Title = "Matthew 1", Book = "Matthew", Chapter = 1, Verse = 10, Comment = "Here is a comment1.", Hyperlink = "http://www.brucegore.com/brucewgore/Audio/Apo57.mp3", VideoLink = "https://www.youtube.com/watch?v=Xb-1hFXrJkg"},
                //new AudioLectures(){ ID = 5000, Class = Class.Bible, Topic = "Matthew", Title = "Matthew 2", Book = "Matthew", Chapter = 2, Verse = 20, Comment = "Here is a comment2.", Hyperlink = "here is hyperlink2", VideoLink = null},
                //new AudioLectures(){ ID = 6000, Class = Class.Bible, Topic = "Matthew", Title = "Matthew 3", Book = "Matthew", Chapter = 3, Verse = 30, Comment = "Here is a comment3.", Hyperlink = "here is hyperlink3", VideoLink = "here is videolink3"},
                //new AudioLectures(){ ID = 7000, Class = Class.Bible, Topic = "Mark", Title = "Introduction to Mark", Book = "Mark", Chapter = 1, Verse = 10, Comment = "Here is a comment on Mark", Hyperlink = "http://www.brucegore.com/brucewgore/Audio/Apo57.mp3", VideoLink = "https://www.youtube.com/watch?v=Xb-1hFXrJkg"},
                //new AudioLectures(){ ID = 8000, Class = Class.Bible, Topic = "Titus", Title = "Introduction to Titus", Book = "Titus", Chapter = 1, Verse = 20, Comment = "Here is a comment on Titus", Hyperlink = "http://www.brucegore.com/brucewgore/Audio/Apo57.mp3", VideoLink = "https://www.youtube.com/watch?v=Xb-1hFXrJkg"},
                //new AudioLectures(){ ID = 9000, Class = Class.Bible, Topic = "Philippians", Title = "xx", Book = "Philippians", Chapter = 1, Verse = 20, Comment = "Here is a comment on Titus", Hyperlink = "http://www.brucegore.com/brucewgore/Audio/Apo57.mp3", VideoLink = "https://www.youtube.com/watch?v=Xb-1hFXrJkg"}
            };            
        }

        public AudioLectures Add(AudioLectures lecture)
        {
            lecture.ID = _audioLecturesList.Max(e => e.ID) + 1;
            _audioLecturesList.Add(lecture);
            return lecture;
        }

        public AudioLectures Delete(string id)
        {
            AudioLectures lecture = _audioLecturesList.FirstOrDefault(e => e.ID == id);
            if(lecture != null)
            {
                _audioLecturesList.Remove(lecture);
            }
            return lecture;
        }

        public IEnumerable<AudioLectures> GetAllLectures()
        {
            return _audioLecturesList;
        }

        public AudioLectures GetByTopic(string Book)
        {            
            throw new NotImplementedException();
            //try returning IEnumerable and do the sort in c#
        }

        public AudioLectures GetLecture(string Id)
        {
            return _audioLecturesList.FirstOrDefault(e => e.ID == Id);
        }

        public AudioLectures Update(AudioLectures lectureChange)
        {
            AudioLectures lecture = _audioLecturesList.FirstOrDefault(e => e.ID == lectureChange.ID);
            if(lecture != null)
            {
                //lecture.Class = lectureChange.Class;
                //lecture.Topic = lectureChange.Topic;
                //lecture.Title = lectureChange.Title;
                //lecture.Book = lectureChange.Book;
                //lecture.Chapter = lectureChange.Chapter;
                //lecture.Verse = lectureChange.Verse;
                //lecture.Date = lectureChange.Date;
                //lecture.Format = lectureChange.Format;
                //lecture.Presentation = lectureChange.Presentation;
                //lecture.Comment = lectureChange.Comment;
                //lecture.Hyperlink = lectureChange.Hyperlink;
                //lecture.LogicalOrder = lectureChange.LogicalOrder;
                //lecture.VideoLink = lectureChange.VideoLink;
                
            }
            return lecture;
        }
    }
}