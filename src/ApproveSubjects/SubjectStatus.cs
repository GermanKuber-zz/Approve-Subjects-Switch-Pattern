using System;

namespace ApproveSubjects
{
    public class SubjectStatus
    {
        private readonly SubjectStatusEnum _subjectStatus;

        [Flags]
        private enum SubjectStatusEnum
        {
            SubscribeSubject,
            HasPracticalWork,
            HasExamsApproved,
            IsRegular,
            HasFinalExamApproved
        }

        private SubjectStatus(SubjectStatusEnum subjectStatus)
        {
            _subjectStatus = subjectStatus;
        }

        public static SubjectStatus Suscribe() =>
            new SubjectStatus(SubjectStatusEnum.SubscribeSubject);



        public SubjectStatus DeliveredPracticalWorks() =>
            new SubjectStatus(_subjectStatus | SubjectStatusEnum.HasPracticalWork);
        public SubjectStatus ApproveExams() =>
            new SubjectStatus(_subjectStatus | SubjectStatusEnum.HasExamsApproved);


        public SubjectStatus DisapproveExam() =>
            new SubjectStatus(_subjectStatus & ~SubjectStatusEnum.HasExamsApproved);

        public SubjectStatus ApproveFinalExam() =>
            new SubjectStatus(_subjectStatus | SubjectStatusEnum.HasFinalExamApproved);
        public SubjectStatus DisapproveFinalExam() =>
            new SubjectStatus(_subjectStatus & ~SubjectStatusEnum.HasFinalExamApproved);


        public override int GetHashCode() => (int)_subjectStatus;
        public override bool Equals(object obj) => Equals(obj as SubjectStatus);
        public bool Equals(SubjectStatus other) =>
            other != null && _subjectStatus == other._subjectStatus;
    }
}