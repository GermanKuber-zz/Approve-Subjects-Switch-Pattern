using System;
using System.Collections.Generic;

namespace ApproveSubjects
{
    public class RulesFactory : IRulesFactory
    {
        public SubjectStatusActions Create(Action<decimal> approveSubject, Action<decimal> recoverySubject, Action<decimal> disapproveSubject) =>
            new SubjectStatusActions(new Dictionary<SubjectStatus, Action<decimal>>
            {
                [SubjectStatus.Suscribe().ApproveExams().DeliveredPracticalWorks().ApproveFinalExam()] = approveSubject,
                [SubjectStatus.Suscribe().DeliveredPracticalWorks().ApproveExams()] = recoverySubject,
                [SubjectStatus.Suscribe().DeliveredPracticalWorks()] = recoverySubject,
                [SubjectStatus.Suscribe()] = disapproveSubject,
            });
    }
}