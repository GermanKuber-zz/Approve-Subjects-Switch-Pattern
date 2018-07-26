using System;
using System.Collections.Generic;

namespace ApproveSubjects
{
    public class SubjectStatusActions
    {
        private readonly Dictionary<SubjectStatus, Action<decimal>> _subjectStatusActions;

        public SubjectStatusActions(Dictionary<SubjectStatus, Action<decimal>> subjectStatusActions)
        {
            _subjectStatusActions = subjectStatusActions;
        }

        public Action<decimal> Execute(SubjectStatus status) => _subjectStatusActions[status];

    }
}