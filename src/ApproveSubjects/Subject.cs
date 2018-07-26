namespace ApproveSubjects
{
    public class Subject
    {
        private SubjectStatus _status;
        private readonly SubjectNoContainer _note = new SubjectNoContainer();
        private readonly SubjectStatusActions _subjectStatusActions;
        public Subject(SubjectStatusActions subjectStatusActions)
        {
            _status = SubjectStatus.Suscribe();
            _subjectStatusActions = subjectStatusActions;
        }

        public void GivePracticalWork()=>
            _status = _status.DeliveredPracticalWorks();

        public void GiveExam(SubjectNote note) =>
            _status = _note.Add(note, () => note.CheckNote(_status.ApproveExams, _status.DisapproveExam));

        public void GiveFinalExam(SubjectNote note) =>
            _status = _note.Add(note, () => note.CheckNote(_status.ApproveFinalExam, _status.DisapproveFinalExam));

        public void CloseSubject() => _subjectStatusActions.Execute(_status).Invoke(_note.Note);
    }
}