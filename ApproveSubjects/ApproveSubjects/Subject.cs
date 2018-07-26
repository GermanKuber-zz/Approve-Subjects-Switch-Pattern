using System;
using System.Collections.Generic;

namespace ApproveSubjects
{
    public class Subject
    {
        private SubjectStatus _status;
        private int _note ;
        private readonly Dictionary<SubjectStatus, Action<decimal>> _subjectStatusActions;
        public Subject(Action<decimal> approveSubject, Action<decimal> recoverySubject, Action<decimal> disapproveSubject)
        {
            _status = SubjectStatus.Suscribe();
            _subjectStatusActions = new Dictionary<SubjectStatus, Action<decimal>>
            {
                [SubjectStatus.Suscribe().ApproveExams().DeliveredPracticalWorks().ApproveFinalExam()] = approveSubject,
                [SubjectStatus.Suscribe().DeliveredPracticalWorks().ApproveExams()] = recoverySubject,
                [SubjectStatus.Suscribe().DeliveredPracticalWorks()] = recoverySubject,
                [SubjectStatus.Suscribe()] = disapproveSubject,
            };
        }

        public void GivePracticalWork()
        {
            _status = _status.DeliveredPracticalWorks();
        }
        public void GiveExam(SubjectNote note)
        {
            _note += note.Note;
            _status = note.CheckNote(_status.ApproveExams, _status.DisapproveExam);
        }
        public void GiveFinalExam(SubjectNote note)
        {
            _note += note.Note;
            _status = note.CheckNote(_status.ApproveFinalExam, _status.DisapproveFinalExam);
        }
        public void CloseSubject()
        {
            _subjectStatusActions[_status].Invoke(_note);
        }
    }
}