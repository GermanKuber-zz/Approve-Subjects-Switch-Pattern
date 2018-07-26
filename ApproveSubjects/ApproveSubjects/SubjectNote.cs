using System;

namespace ApproveSubjects
{
    public abstract class SubjectNote
    {
        public int Note { get; protected set; }

        protected SubjectNote(int note)
        {
            Note = note;
        }

        public abstract SubjectStatus CheckNote(Func<SubjectStatus> approve, Func<SubjectStatus> disapprove);
    }
}