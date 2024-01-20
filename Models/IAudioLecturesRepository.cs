using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace mvccore.Models
{
    public interface IAudioLecturesRepository
    {
        AudioLectures GetLecture(string Id);

        IEnumerable<AudioLectures> GetAllLectures();
        AudioLectures Add(AudioLectures lecture);
        AudioLectures Update(AudioLectures lectureChange);

        AudioLectures Delete(string id);

        AudioLectures GetByTopic (string Book);

    }


    public interface ICommentaryRepository
    {
        Commentary GetCommentary(int Id);

        Commentary Update(Commentary commentChange);
    }

}