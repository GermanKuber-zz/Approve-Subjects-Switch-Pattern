using System;

namespace ApproveSubjects
{
    public class SubjectFinalExamNote : SubjectNote
    {
        protected const int NoteToApprove = 6;
        private SubjectFinalExamNote(int note) : base(note)
        {

        }
        public static SubjectNote Create(int note) =>
            new SubjectFinalExamNote(note);

        public override SubjectStatus CheckNote(Func<SubjectStatus> approve, Func<SubjectStatus> disapprove)
        {
            if (Note > NoteToApprove)
                return approve();
            else
                return disapprove();
        }
    }
}