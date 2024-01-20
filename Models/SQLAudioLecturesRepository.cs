using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace mvccore.Models
{
    public class SQLAudioLecturesRepository : IAudioLecturesRepository
    {

        private readonly AppDbContext context;

        private List<AudioLectures> _audioLecturesList;

        public SQLAudioLecturesRepository(AppDbContext context)
        {
            this.context = context;
        }



        public AudioLectures Add(AudioLectures lecture)
        {
            _audioLecturesList = new List<AudioLectures>();
            //lecture.ID = _audioLecturesList.Max(e => e.ID) + 1;
            context.AudioLectures.Add(lecture);
            context.SaveChanges();
            return lecture;
        }

        public AudioLectures Delete(string id)
        {
            AudioLectures lecture = context.AudioLectures.Find(id);
            if (lecture != null)
            {
                context.AudioLectures.Remove(lecture);
                context.SaveChanges();
            }
            return lecture;
        }

        public IEnumerable<AudioLectures> GetAllLectures()
        {
            return context.AudioLectures;
        }

        public AudioLectures GetByTopic(string Book)
        {
            throw new NotImplementedException();
        }

        public AudioLectures GetLecture(string Id)
        {
            return context.AudioLectures.Find(Id);
        }

        public AudioLectures Update(AudioLectures lectureChange)
        {
            var lecture = context.AudioLectures.Attach(lectureChange);
            lecture.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return lectureChange;
        }
    }

    public class SQLCommentaryRepository : ICommentaryRepository 
    {
        private readonly AppDbContext comment;

        public SQLCommentaryRepository(AppDbContext comment)
        {
            this.comment = comment;
        }


        public Commentary GetCommentary(int Id)
        {
            return comment.Commentary.Find(Id);
        }

        public Commentary Update(Commentary commentChange)
        {
            var cmt = comment.Commentary.Attach(commentChange);
            cmt.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            comment.SaveChanges();
            return commentChange;
        }
    }
}
