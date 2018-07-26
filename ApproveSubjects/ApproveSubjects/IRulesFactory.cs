using System;

namespace ApproveSubjects
{
    public interface IRulesFactory
    {
        SubjectStatusActions Create(Action<decimal> approveSubject,
            Action<decimal> recoverySubject, Action<decimal> disapproveSubject);
    }
}