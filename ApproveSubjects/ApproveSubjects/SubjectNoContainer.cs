using System;

namespace ApproveSubjects
{
    public class SubjectNoContainer
    {
        public int Note { get; private set; } = 0;

        public TReturnEntity Add<TReturnEntity>(SubjectNote note, Func<TReturnEntity> callback)
        {
            Note += note.Note;
            return callback();
        }
        public TReturnEntity Subtract<TReturnEntity>(SubjectNote note, Func<TReturnEntity> callback)
        {
            Note -= note.Note;
            return callback();
        }
    }
}