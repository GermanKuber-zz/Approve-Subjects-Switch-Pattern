using System;

namespace ApproveSubjects
{
    public class SubjectExamNote : SubjectNote
    {
        protected const int NoteToApprove = 4;

        private SubjectExamNote(int note) : base(note)
        {

        }
        public static SubjectNote Create(int note) =>
            new SubjectExamNote(note);

        public override SubjectStatus CheckNote(Func<SubjectStatus> approve, Func<SubjectStatus> disapprove)
        {
            if (Note > NoteToApprove)
               return approve();
            else
                return disapprove();
        }

    }
}